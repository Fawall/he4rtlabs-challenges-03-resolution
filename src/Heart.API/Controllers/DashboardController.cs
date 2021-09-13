using System.Threading.Tasks;
using Heart.API.ViewModels;
using Heart.Infra.Interfaces;
using Heart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Heart.API.Utilities;

namespace Heart.API.Controllers
{
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUserService _userService;
        public DashboardController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/api/dashboard/get-all")]
        public async Task<IActionResult> GetAll()
        {
            var allUsers = await _userService.GetAll();

            if (allUsers != null)
            {
                return Ok(new ResultListViewModel
                {
                    Message = "Resultados retornados",
                    Sucess = true,
                    Data = allUsers,
                    UsersQuantity = allUsers.Count

                });
            }
        
            else
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }
        
    }
}