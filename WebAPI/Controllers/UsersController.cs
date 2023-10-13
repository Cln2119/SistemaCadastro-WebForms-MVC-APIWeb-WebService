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
        public async Task<IActionResult> Post(DadosClienteCompleto user)
        {
            try
            {
                var cliente = new ClienteEntity
                {
                    CPF = user.CPF,
                    Nome = user.Nome,
                    RG = user.RG,
                    Data_Expedicao = user.Data_Expedicao,
                    Orgao_Expedicao = user.Orgao_Expedicao,
                    UF = user.UF,
                    DataNascimento = user.DataNascimento,
                    Sexo = user.Sexo,
                    Estado_Civil = user.Estado_Civil,
                };

                var result = await _service.Post(cliente);

                var enderencoCliente = new EnderecoClienteEntity
                {
                    CEP = user.Endereco.CEP,
                    Logradouro = user.Endereco.Logradouro,
                    Numero = user.Endereco.Numero,
                    Complemento = user.Endereco.Complemento,
                    Cidade = user.Endereco.Cidade,
                    Bairro = user.Endereco.Bairro,
                    UF = user.Endereco.UF,
                    Id_Cliente = result.Id
                };

                var resultEndereco = await _enderecoService.Post(enderencoCliente);
                
                return Ok(resultEndereco);
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
                var cliente = await _service.Get(id);
                var enderecoCliente = await _enderecoService.Get(id);

                var consulta = new DadosClienteCompleto
                                {
                                    Id = cliente.Id,
                                    CPF = cliente.CPF,
                                    Nome = cliente.Nome,
                                    RG = cliente.RG,
                                    Data_Expedicao = cliente.Data_Expedicao,
                                    Orgao_Expedicao = cliente.Orgao_Expedicao,
                                    UF = cliente.UF,
                                    DataNascimento = cliente.DataNascimento,
                                    Sexo = cliente.Sexo,
                                    Estado_Civil = cliente.Estado_Civil,
                                    Endereco = new DadosEndereco
                                    {
                                        Id = enderecoCliente.Id,
                                        CEP = enderecoCliente.CEP,
                                        Logradouro = enderecoCliente.Logradouro,
                                        Numero = enderecoCliente.Numero,
                                        Complemento = enderecoCliente.Complemento,
                                        Cidade = enderecoCliente.Cidade,
                                        Bairro = enderecoCliente.Bairro,
                                        UF = enderecoCliente.UF,
                                        Id_Cliente = enderecoCliente.Id_Cliente,
                                    }
                                };

                return Ok(consulta);
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
                var resultClientes = await _enderecoService.GetAll();

                var filtroCliente = resultClientes.FirstOrDefault(cliente => cliente.Id_Cliente == id);

                var resultDelete = await _enderecoService.Delete(filtroCliente.Id);
                
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
        public async Task<IActionResult> Put(DadosClienteCompleto user)
        {
            try
            {
                var dadosCliente = new ClienteEntity
                {
                    Id = user.Id,
                    CPF = user.CPF,
                    Nome = user.Nome,
                    RG = user.RG,
                    Data_Expedicao = user.Data_Expedicao,
                    Orgao_Expedicao = user.Orgao_Expedicao,
                    UF = user.UF,
                    DataNascimento = user.DataNascimento,
                    Sexo = user.Sexo,
                    Estado_Civil = user.Estado_Civil,
                };

                var resultCliente = await _service.Put(dadosCliente);

                var result = await _enderecoService.GetAll();

                var clienteEnderecoId = result.FirstOrDefault(cliente => cliente.Id_Cliente == user.Id);

                var dadosEndereco = new EnderecoClienteEntity
                {
                    Id = clienteEnderecoId.Id,
                    CEP = user.Endereco.CEP,
                    Logradouro = user.Endereco.Logradouro,
                    Numero = user.Endereco.Numero,
                    Complemento = user.Endereco.Complemento,
                    Cidade = user.Endereco.Cidade,
                    Bairro = user.Endereco.Bairro,
                    UF = user.Endereco.UF,
                    Id_Cliente = clienteEnderecoId.Id,
                };

                var resultEndereco = await _enderecoService.Put(dadosEndereco);

                return Ok(dadosCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}