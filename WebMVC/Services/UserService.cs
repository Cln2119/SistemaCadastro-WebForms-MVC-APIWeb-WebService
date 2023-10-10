using Newtonsoft.Json;
using System.Text;
using WebMVC.Domain.Entity;
using WebMVC.Domain.Entity.request;
using WebMVC.Domain.Interfaces.Services;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserService(IConfiguration configuration, ILogger<UserService> logger)
        {
            _configuration = configuration;
            _logger = logger;
            LogId = Guid.NewGuid().ToString();
        }
        public string LogId { get; set; }
        public async Task<string> CreateUserAsync(UserFrontRequest user)
        {
            string retornoErroStatusCode = string.Empty;
            string retornoErroPhrase = string.Empty;
            HttpResponseMessage response = new HttpResponseMessage();
            Credentials dados = new Credentials();

            _logger.LogInformation("{0} - Montanto dados da chamada...", LogId);
            dados.BaseUrl = _configuration.GetSection("BaseUrl").Value;

            try
            {
               
                string json = JsonConvert.SerializeObject(user);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var handler = new HttpClientHandler();

                using (HttpClient client = new HttpClient(handler))
                {
                    _logger.LogInformation("{0} - Verificação do certificado", LogId);
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                    _logger.LogInformation("{0} - Adicionando Content...", LogId);

                    _logger.LogInformation("{0} - Realizando chamada do servico....", LogId);
                    response = await client.PostAsync(dados.BaseUrl, content);
                    _logger.LogInformation("{0} - retorno dos dados do servico... " + response.StatusCode + response.ReasonPhrase, LogId);

                    string stringData = string.Empty;
                    retornoErroStatusCode = response.StatusCode.ToString();
                    retornoErroPhrase = response.ReasonPhrase;

                    if (response.IsSuccessStatusCode)
                    {
                        stringData = response.Content.ReadAsStringAsync().Result;
                        _logger.LogInformation("{0} - retorno dos dados com sucesso. Response: " + response.RequestMessage + " Url: " + dados.BaseUrl, LogId);
                    }
                    else
                    {
                        stringData = response.ReasonPhrase;
                        _logger.LogInformation("{0} - Falha ao retornar dados. Mais detalhes: " + " Status Code: " + response.StatusCode + " Descrição: " + response.ReasonPhrase + " Url: " + dados.BaseUrl, LogId);
                    }

                    return stringData;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{0} - falha ao retornar dados. Mais detalhes: "
                    + response.ReasonPhrase);             

                return "Falha ao montar ou retornar dados. Mais detalhes: " + ex.Message;
            }

        }
        public async Task<string> GetAllUserAsync()
        {
            string retornoErroStatusCode = string.Empty;
            string retornoErroPhrase = string.Empty;
            HttpResponseMessage response = new HttpResponseMessage();
            Credentials dados = new Credentials();

            _logger.LogInformation("{0} - Montanto dados da chamada...", LogId);
            dados.BaseUrl = _configuration.GetSection("BaseUrl").Value;

            try
            {
                var handler = new HttpClientHandler();

                using (HttpClient client = new HttpClient(handler))
                {
                    _logger.LogInformation("{0} - Verificação do certificado", LogId);
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                    _logger.LogInformation("{0} - Adicionando Content...", LogId);

                    _logger.LogInformation("{0} - Realizando chamada do servico....", LogId);
                    response = await client.GetAsync(dados.BaseUrl);
                    _logger.LogInformation("{0} - retorno dos dados do servico... " + response.StatusCode + response.ReasonPhrase, LogId);

                    string stringData = string.Empty;
                    retornoErroStatusCode = response.StatusCode.ToString();
                    retornoErroPhrase = response.ReasonPhrase;

                    if (response.IsSuccessStatusCode)
                    {
                        stringData = response.Content.ReadAsStringAsync().Result;
                      
                    }
                    else
                    {
                        stringData = response.ReasonPhrase;
                        
                    }

                    return stringData;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{0} - falha ao retornar dados. Mais detalhes: "
                    + response.ReasonPhrase);

                return "Falha ao montar ou retornar dados. Mais detalhes: " + ex.Message;
            }

        }

        public async Task<string> DeleteUserAsync(UserFront user)
        {
            string retornoErroStatusCode = string.Empty;
            string retornoErroPhrase = string.Empty;
            HttpResponseMessage response = new HttpResponseMessage();
            Credentials dados = new Credentials();

            _logger.LogInformation("{0} - Montanto dados da chamada...", LogId);
            dados.BaseUrl = _configuration.GetSection("BaseUrl").Value + $"/{user.Id}";

            try
            {
                var handler = new HttpClientHandler();

                using (HttpClient client = new HttpClient(handler))
                {
                    _logger.LogInformation("{0} - Verificação do certificado", LogId);
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                    _logger.LogInformation("{0} - Adicionando Content...", LogId);

                    _logger.LogInformation("{0} - Realizando chamada do servico....", LogId);
                    response = await client.DeleteAsync(dados.BaseUrl);
                    _logger.LogInformation("{0} - retorno dos dados do servico... " + response.StatusCode + response.ReasonPhrase, LogId);

                    string stringData = string.Empty;
                    retornoErroStatusCode = response.StatusCode.ToString();
                    retornoErroPhrase = response.ReasonPhrase;

                    if (response.IsSuccessStatusCode)
                    {
                        stringData = response.Content.ReadAsStringAsync().Result;

                    }
                    else
                    {
                        stringData = response.ReasonPhrase;

                    }

                    return stringData;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{0} - falha ao retornar dados. Mais detalhes: "
                    + response.ReasonPhrase);

                return "Falha ao montar ou retornar dados. Mais detalhes: " + ex.Message;
            }

        }
    }
}
