using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Data;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;

namespace TeclaT.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _categoryRepository.GetAllAsync());

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
            => Ok(_categoryRepository.SearchByName(name));

        [HttpPost("create/{name}")]
        public async Task<IActionResult> CreateCategory(string name)
        {
            var entity = new Category
            {
                Name = name
            };

            await _categoryRepository.Save(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryRepository.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
