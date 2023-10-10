using GTI.Domain.Entity;
using GTI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public IUserService _service { get; set; }
        public UsersController(IUserService service)
        {
            _service = service;
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
                var user = await _service.GetAll();

                return Ok(user);
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
        public async Task<IActionResult> Post(UserEntity user)
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

    }
}