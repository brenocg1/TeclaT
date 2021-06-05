using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;

namespace TeclaT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository, ICategoryRepository categoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _subCategoryRepository.GetAllAsyncProjected());

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
            => Ok(_subCategoryRepository.SearchByName(name));

        [HttpPost("create/{name}/{categoryName}")]
        public async Task<IActionResult> CreateSubCategory(string name, string categoryName)
        {

            var category = _categoryRepository.SearchByName(categoryName).FirstOrDefault();

            if(category == null)
            {
                return NotFound("Category not found");
            }

            var entity = new SubCategory
            {
                CategoryId = category.Id,
                Name = name
            };

            await _subCategoryRepository.Save(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subCategoryRepository.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
