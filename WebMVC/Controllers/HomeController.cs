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
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;         
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
        public async Task<IActionResult> PostUser(
            string cpf, 
            string nome, 
            string rg,
            string dataExpedicao,
            string orgaoExpedicao,
            string orgaoUf,
            string dataNascimento,
            string sexo,
            string estadoCivil,
            string cep,
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cidade,
            string ufEstado
            )
        {           
            string cpfFormatado = cpf.Replace(".", "").Replace("-", "");
            var userRequest = new UserFrontRequest
            {
                Nome = nome,
                CPF = cpfFormatado,
                RG = rg,
                Data_Expedicao = DateTime.Parse(dataExpedicao),
                Orgao_Expedicao = orgaoExpedicao,
                UF = orgaoUf,
                DataNascimento = DateTime.Parse(dataNascimento),
                Sexo = sexo,
                Estado_Civil = estadoCivil,
                    Endereco = new DadosEnderecoRequest
                    {
                        CEP = cep,
                        Logradouro = logradouro,
                        Numero = numero,
                        Complemento= complemento,
                        Bairro = bairro,
                        Cidade = cidade,
                        UF = ufEstado
                    }

            };

            var result = await _userService.CreateUserAsync(userRequest);

            if (result == null)
                return BadRequest(result);
            
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DeleteUser(UserFront userId)
        {
            
            var result = await _userService.DeleteUserAsync(userId);

            if (result == null)
                return BadRequest();
           
            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> EditarUsuario(string id)
        {
            
            var response = await _userService.GetAllUserAsync();
            var listUsers = JsonConvert.DeserializeObject<List<UserFront>>(response);

            var user = listUsers.FirstOrDefault(user => user.Id == int.Parse(id));

            var userFront = new UserFront
            {
                Nome = user.Nome,
               // Email = user.Email,
                Id = user.Id,
                //CpfCnpj = user.CpfCnpj
            };   

            return PartialView("~/Views/Home/EditarPessoa.cshtml", userFront);
        }
        public async Task<IActionResult> SalvarEdicaoUsuario(string nome, string email, string id, string cpfCnpj)
        {
            var userRequest = new UserFrontRequest
            {
                //id = int.Parse(id),
               //nome = nome,
                //email = email,
               // cpfCnpj = cpfCnpj,               
               // updateAt = DateTime.UtcNow,
            };
            var response = await _userService.PutUserAsync(userRequest);

            if(response == null)
                return BadRequest(response);

            return RedirectToAction("Index", "Home");
        }

    }
}