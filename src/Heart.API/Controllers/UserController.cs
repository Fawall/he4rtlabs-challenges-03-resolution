using Microsoft.AspNetCore.Mvc;
using Heart.Services.DTO;
using Heart.API.ViewModels;
using Heart.Services.Interfaces;
using System.Threading.Tasks;
using Heart.Core.Exceptions;
using Heart.API.Utilities;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Heart.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = new UserDTO(userViewModel.Email, userViewModel.Password);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Sucess = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


    }
}