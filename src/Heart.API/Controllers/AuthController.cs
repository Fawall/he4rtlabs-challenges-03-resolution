using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Heart.API.ViewModels;
using Heart.Services.DTO;
using Heart.Services.Interfaces;
using Heart.Infra.Interfaces;
using Heart.Core.Exceptions;
using Heart.API.Utilities;
using Heart.API.Token;
using Microsoft.Extensions.Configuration;
using System;

namespace Heart.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, ITokenGenerator tokenGenerator, IConfiguration configuration) 
        {
            _tokenGenerator = tokenGenerator;
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("/api/auth/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            if(await _authRepository.Login(loginViewModel.Email, loginViewModel.Password) != true)
                return StatusCode(401, Responses.UnathorizedErrorMessage());
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário autenticado com sucesso",
                Data = new 
                {
                    Token = _tokenGenerator.GenerateToken(loginViewModel.Email),
                    TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                },
                Sucess = true
            });




        }


    }
}