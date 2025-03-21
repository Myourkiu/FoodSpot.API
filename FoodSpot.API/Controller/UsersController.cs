﻿using Microsoft.AspNetCore.Mvc;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.Services.Interfaces;
using FoodSpot.DTOs.Response.Users;

namespace FoodSpot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        [HttpGet("GetByEmail")]
        public async Task<ActionResult<UserWithoutPasswordResponse>> GetUserByEmail(string email)
        {
            return await _userService.GetByEmail(email);          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserWithoutPasswordResponse>> GetUserByEmail(Guid id)
        {
            return await _userService.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserWithoutPasswordResponse>> PutUser(Guid id, EditUserRequest request)
        {
            return await _userService.EditUser(id, request);
        }

        [HttpPost]
        public async Task<ActionResult<UserWithoutPasswordResponse>> PostUser(CreateUserRequest request)
        {
           return await _userService.CreateUser(request);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest request) 
        {
            return await _userService.Login(request);
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        
    }
}
