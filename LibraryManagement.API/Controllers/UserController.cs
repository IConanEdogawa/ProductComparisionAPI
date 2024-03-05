using LibraryManagement.API.Attributes;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Application.Services.BookService;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public UserController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }




        [HttpPost]
        [IdentityFilter(Permission.CreateUser)]
        public async Task<string> CreateUser([FromForm] UserDTO userDTO)
        {
            return await _userService.CreateUser(userDTO);
        }

        [HttpPost]
        [IdentityFilter(Permission.AddProduct)]
        public async Task<string> AddProduct(ProductDTO model)
        {
            var result = await _productService.Add(model);

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permission.GetById)]
        public async Task<Product> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetAllUser)]
        public async Task<List<UserViewModel>> GetAll()
        {
            return await _userService.GetAll();
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByUserId)]
        public async Task<UserViewModel> GetByUserId(int id)
        {
            return await _userService.GetById(id);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByUserEmail)]
        public async Task<UserViewModel> GetByEmail(string email)
        {
            return await _userService.GetByEmail(email);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByRole)]
        public async Task<List<UserViewModel>> GetByRole(string role)
        {
            return await _userService.GetByRole(role);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByUserFullName)]
        public async Task<List<UserViewModel>> GetByUserFullName(string fullname)
        {
            return await _userService.GetByName(fullname);
        }
        [HttpPut]
        [IdentityFilter(Permission.UpdateUser)]
        public async Task<string> UpdateUser(int id, UserDTO userDTO)
        {
            return await _userService.UpdateUser(id, userDTO);
        }
        [HttpPut]
        [IdentityFilter(Permission.UpdateProduct)]
        public async Task<string> UpdateProduct(int id, ProductDTO bookDTO)
        {
            return await _productService.Update(id, bookDTO);
        }
        [HttpDelete]
        [IdentityFilter(Permission.DeletePproduct)]
        public async Task<string> DeletePproduct(int id)
        {
            return await _productService.Delete(id);
        }
        [HttpDelete]
        [IdentityFilter(Permission.DeleteUser)]
        public async Task<string> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
        [HttpGet("download")]
        [IdentityFilter(Permission.GetUserPDF)]
        public async Task<IActionResult> DownloadFile()
        {
            // Replace this with the path to the file you want to download
            var filePath = await _userService.GetPdfPath();

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");


            var fileBytes = System.IO.File.ReadAllBytes(filePath);


            var contentType = "application/octet-stream";

            var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();


            // Send the file as a response
            return File(fileBytes, contentType, Path.GetFileName(filePath));



        }



    }
}
