﻿using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            // check if user is authenticated
            // check username and password
            var user = await userRepository.AuthenticateAsync(
                loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                // generate a JWT TOken
                var token = await tokenHandler.CreeateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect!");

        }
    }
}
