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
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
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
                        Complemento = complemento,
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
            else
            {
                return Ok();
            }
           
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
            HttpContext.Session.SetInt32("UserID", int.Parse(id));

            var response = await _userService.GetAllUserAsync();
            var cliente = JsonConvert.DeserializeObject<List<UserFront>>(response);

            var filtroCliente = cliente.FirstOrDefault(x => x.Id == int.Parse(id));
            var formatarDataExpedicao = DateTime.Parse(filtroCliente.Data_Expedicao);
            var formatarDataNascimento = DateTime.Parse(filtroCliente.DataNascimento);

            var userFront = new UserFront
            {
               Id = filtroCliente.Id,
                CPF = filtroCliente.CPF,
                Nome = filtroCliente.Nome,
                RG = filtroCliente.RG,
                Data_Expedicao = formatarDataExpedicao.ToString("yyyy-MM-dd"),
                Orgao_Expedicao = filtroCliente.Orgao_Expedicao,
                UF = filtroCliente.UF,
                DataNascimento = formatarDataNascimento.ToString("yyyy-MM-dd"),
                Sexo = filtroCliente.Sexo,
                Estado_Civil = filtroCliente.Estado_Civil,
                Endereco = new DadosEndereco
                    {
                        Id = filtroCliente.Endereco.Id,
                    CEP = filtroCliente.Endereco.CEP,
                    Logradouro = filtroCliente.Endereco.Logradouro,
                    Numero = filtroCliente.Endereco.Numero,
                    Complemento = filtroCliente.Endereco.Complemento,
                    Cidade = filtroCliente.Endereco.Cidade,
                    Bairro = filtroCliente.Endereco.Bairro,
                    UF = filtroCliente.Endereco.UF,
                    Id_Cliente = filtroCliente.Endereco.Id_Cliente,
                }
            };

            return PartialView("~/Views/Home/EditarPessoa.cshtml", userFront);
        }
        public async Task<IActionResult> SalvarEdicaoUsuario(
            string id,
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
            string ufEstado)
        {
            string cpfFormatado = cpf.Replace(".", "").Replace("-", "");

            var response = await _userService.GetAllUserAsync();

            var listUsers = JsonConvert.DeserializeObject<List<UserFront>>(response);

            var clienteId = listUsers.FirstOrDefault(x => x.Endereco.Id_Cliente == int.Parse(id)); 

            var userRequest = new UserFrontAtualizacaoRequest
            {        
                Id = int.Parse(id),
                Nome = nome,
                CPF = cpfFormatado,
                RG = rg,
                Data_Expedicao = DateTime.Parse(dataExpedicao),
                Orgao_Expedicao = orgaoExpedicao,
                UF = orgaoUf,
                DataNascimento = DateTime.Parse(dataNascimento),
                Sexo = sexo,
                Estado_Civil = estadoCivil,
                Endereco = new DadosAtualizaEnderecoRequest
                {
                    Id = clienteId.Endereco.Id,
                    CEP = cep,
                    Logradouro = logradouro,
                    Numero = numero,
                    Complemento = complemento,
                    Bairro = bairro,
                    Cidade = cidade,
                    UF = ufEstado,
                    id_cliente = clienteId.Endereco.Id.ToString()
                }

            };

            var result = await _userService.PutUserAsync(userRequest);

            if(result == null)
                return BadRequest(result);

            return RedirectToAction("Index", "Home");
        }

    }
}