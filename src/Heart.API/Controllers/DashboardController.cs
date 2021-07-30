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
            try
            {
                var allUsers = await _userService.GetAll();
                
                return Ok(new ResultViewModel
                {
                    Message = "Resultados retornados",
                    Sucess = true,
                    Data = allUsers
                });
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        
    }
}