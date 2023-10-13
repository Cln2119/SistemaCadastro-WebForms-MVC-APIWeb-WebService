using GTI.Domain.Entity;
using GTI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public IClienteService _service { get; set; }
        public IEnderecoServices _enderecoService { get; set; }

        public UsersController(IClienteService service, IEnderecoServices enderecoServices)
        {
            _service = service;
            _enderecoService = enderecoServices;
        }

        /// <summary>
        /// Realiza a busca da media
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// ///
        /// 
        ///    GET/Users    
        ///    
        ///
        /// </remarks>
        /// <param name="media"></param>
        /// <response code="200">Retorna lista de todos os usuários</response>
        /// <response code="400">Retorna as informações em relação aos campos obrigatórios </response>
        /// <response code="404">Retorna que a pagina não foi encontrada </response>
        /// /// <response code="500">Erro no servidor </response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]     
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var cliente = await _service.GetAll();
                var enderecoCliente = await _enderecoService.GetAll();

                var consulta = from t1 in cliente
                               join t2 in enderecoCliente
                               on t1.Id equals t2.Id_Cliente
                               select new DadosClienteCompleto
                               {
                                   Id = t1.Id,
                                   CPF = t1.CPF,
                                   Nome = t1.Nome,
                                   RG = t1.RG,
                                   Data_Expedicao = t1.Data_Expedicao,
                                   Orgao_Expedicao = t1.Orgao_Expedicao,
                                   UF = t1.UF,
                                   DataNascimento = t1.DataNascimento,
                                   Sexo = t1.Sexo,
                                   Estado_Civil = t1.Estado_Civil,
                                   Endereco = new DadosEndereco
                                   {
                                       Id = t2.Id,
                                       CEP = t2.CEP,
                                       Logradouro = t2.Logradouro,
                                       Numero = t2.Numero,
                                       Complemento = t2.Complemento,
                                       Cidade = t2.Cidade,
                                       Bairro = t2.Bairro,
                                       UF = t2.UF,
                                       Id_Cliente = t2.Id_Cliente,
                                   }
                               };

                var resultado = consulta.ToList();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// Realiza a busca da media
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// ///
        /// 
        ///     POST/Users
        ///     {
        ///      "Nome": "Teste",
        ///      "Email": "teste@email.com",
        ///      "CpfCnpj: "00000000000"
        ///     }
        ///    
        ///
        /// </remarks>
        /// <param name="media"></param>
        /// <response code="200">Retorna os dados salvos no banco</response>
        /// <response code="400">Retorna as informações em relação aos campos obrigatórios </response>
        /// <response code="404">Retorna que a pagina não foi encontrada </response>
        /// /// <response code="500">Erro no servidor </response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ClienteEntity user)
        {
            try
            {
                var result = await _service.Post(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        /// <summary>
        /// Realiza a busca da media
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// ///
        /// 
        ///    GET/Users/1    
        ///    
        ///
        /// </remarks>
        /// <param name="media"></param>
        /// <response code="200">Retorna doados de um usuário</response>
        /// <response code="400">Retorna as informações em relação aos campos obrigatórios </response>
        /// <response code="404">Retorna que a pagina não foi encontrada </response>
        /// /// <response code="500">Erro no servidor </response>

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _service.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza a busca da media
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// ///
        /// 
        ///    DELETE/Users/1    
        ///    
        ///
        /// </remarks>
        /// <param name="media"></param>
        /// <response code="200">Retorna se o usuário foi deletado</response>
        /// <response code="400">Retorna as informações em relação aos campos obrigatórios </response>
        /// <response code="404">Retorna que a pagina não foi encontrada </response>
        /// /// <response code="500">Erro no servidor </response>

        [HttpDelete("{id}")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza a busca da media
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// ///
        /// 
        ///     PUT/Users
        ///     {
        ///      "Nome": "Teste",
        ///      "Email": "teste@email.com",
        ///      "CpfCnpj: "00000000000"
        ///     }
        ///    
        ///
        /// </remarks>
        /// <param name="media"></param>
        /// <response code="200">Retorna os dados alterados no banco</response>
        /// <response code="400">Retorna as informações em relação aos campos obrigatórios </response>
        /// <response code="404">Retorna que a pagina não foi encontrada </response>
        /// /// <response code="500">Erro no servidor </response>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(ClienteEntity user)
        {
            try
            {
                var result = await _service.Put(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}