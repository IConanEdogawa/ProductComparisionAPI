﻿using LibraryManagement.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Application.Services.AuthService;
using LibraryManagement.Application.Abstractions.IService;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.API.Attributes;
using LibraryManagement.Application.Services.UserService;
using LibraryManagement.Domain.Entities.Enums;
using System.ComponentModel.Design;
namespace LibraryManagement.API.Controllers.Indentity
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class AuthController : ControllerBase
    {
        private readonly IAuthSevice _authSevice;
        public AuthController(IAuthSevice authService)
        {
            _authSevice = authService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Login([FromForm]RequestLogin model)
        {
            var result = await _authSevice.GenerateToken(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task<string> Help()
        {
            string res = "admin@gmail.com";
            return res;
        }



    }
}
