﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.eCommerce.Core.DTOs;
using UserService.eCommerce.Core.ServiceContract;


namespace UserService.eCommerce.API.Controllers
{
    [Route("api/[controller]")] // api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // endpoint for user registration
        [HttpPost("register")]  // api/auth/register
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        { 
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }

            // call the UsersService to handle registration
            AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }


        [HttpPost("login")] // api/auth/login
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        { 
            if (loginRequest == null)
            {
                return BadRequest("Invalid login data");
            }

            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
