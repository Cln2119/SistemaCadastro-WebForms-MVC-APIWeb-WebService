using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebMVC.Domain.Entity.request;
using WebMVC.Domain.Interfaces.Services;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserFront _userFront;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserFront userFront, IUserService userService)
        {
            _logger = logger;
            _userFront = userFront;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _userService.GetAllUserAsync();

                if (response == null)
                    return NotFound();

                var user = new UserFront();
                var listUsers = JsonConvert.DeserializeObject<List<UserFront>>(response);

                var dados = new Tuple<List<UserFront>, UserFront>(listUsers, user);
                return View(dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<IActionResult> PostUser(string nome, string email, string cpfCnpj)
        {
            var userRequest = new UserFrontRequest
            {
                nome = nome,
                email = email,
                cpfCnpj = cpfCnpj,
                createAt = DateTime.UtcNow,
                updateAt = DateTime.UtcNow,
            };

            var result = await _userService.CreateUserAsync(userRequest);

            if (result == null)
                return BadRequest();

            var response = await _userService.GetAllUserAsync();

            if (response == null)
                return NotFound();

            var user = new UserFront();
            var listUsers = JsonConvert.DeserializeObject<List<UserFront>>(response);

            var dados = new Tuple<List<UserFront>, UserFront>(listUsers, user);
            return View(dados);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var userRequest = new UserFrontRequest
            {
                nome = nome,
                email = email,
                cpfCnpj = cpfCnpj,
                createAt = DateTime.UtcNow,
                updateAt = DateTime.UtcNow,
            };

            var result = await _userService.CreateUserAsync(userRequest);

            if (result == null)
                return BadRequest();

            var response = await _userService.GetAllUserAsync();

            if (response == null)
                return NotFound();

            var user = new UserFront();
            var listUsers = JsonConvert.DeserializeObject<List<UserFront>>(response);

            var dados = new Tuple<List<UserFront>, UserFront>(listUsers, user);
            return View(dados);
        }

    }
}