using LibraryManagement.API.Attributes;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Enums;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        


        [HttpGet]
        [IdentityFilter(Permission.GetAllProduct)]
        public async Task<List<Product>> GetAll()
        {
            var result = await _productService.GetAll();

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByName)]
        public async Task<List<Product>> GetByName(string Name)
        {
            var result = await _productService.GetByName(Name);

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByCategory)]
        public async Task<List<Product>> GetByCategory(string catergory)
        {
            return await _productService.GetByCategory(catergory);
        }


        [HttpGet]
        [IdentityFilter(Permission.GetByPrice)]
        public async Task<List<Product>> GetByPrice(double price)
        {
            return await _productService.GetByPrice(price);
        }



    }
}
