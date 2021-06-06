using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;
using TeclaT.Repository.Interfaces;
using TeclaT.Requests;

namespace TeclaT.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
            => Ok(await _productRepository.GetAllAsyncProjected());

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
            => Ok(_productRepository.SearchByName(name));

        [HttpPut("search/product")]
        public IActionResult Search([FromBody] SearchProductRequest request)
            => Ok(_productRepository.SearchProduct(request));

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var entity = new Product
            {
                Name = request.Name,
                Price = request.Price,
                SKUCode = request.SKUCode,
                SubCategoryId = request.SubCategoryId,
                Description = request.Description,
            };

            await _productRepository.Save(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productRepository.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
