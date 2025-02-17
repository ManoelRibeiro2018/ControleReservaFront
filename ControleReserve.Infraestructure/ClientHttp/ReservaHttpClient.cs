using AutoFixture;
using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Sala;
using ControleReserva.Domain.Interface.HttpClient;
using ControleReserva.Domain.Model;
using ControleReservaDomain.Enum;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace ControleReserve.Infraestructure.ClientHttp
{
    public class ReservaHttpClient : IReservaHttpClient
    {
        private readonly ILogger<ReservaHttpClient> _logger;
        private readonly HttpClient _httpClient;
        private readonly Fixture _fixture;
        public ReservaHttpClient(ILogger<ReservaHttpClient> logger, Fixture fixture)
        {
            _fixture = fixture;
            _logger = logger;
            _httpClient = new()
            {
                BaseAddress = new Uri("http://controlereserva-api.azurewebsites.net/reserva/")
            };
        }
        public async Task<Response> ChangeStatus(int id, Status status)
        {
            try
            {
                var obj = new { status, id };
                var jsonData = JsonSerializer.Serialize(obj);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseJson = await _httpClient.PostAsync("ChangeStatus", content);

                string responseBody = await responseJson.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<Response>(responseBody);
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                    nameof(ReservaHttpClient),
                    nameof(ChangeStatus),
                    ex.Message);

                return Response.Fail("Erro ao atualizar status", false);
            }
        }

        public async Task<Response> Create(Reserva entity)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(entity);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseJson = await _httpClient.PostAsync("Create", content);

                string responseBody = await responseJson.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<Response>(responseBody);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                    nameof(ReservaHttpClient),
                    nameof(Create),
                    ex.Message);

                return Response.Fail("Erro ao atualizar status", false);
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                var responseJson = await _httpClient.DeleteAsync(string.Format("delete={0}", id));

                string responseBody = await responseJson.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<Response>(responseBody);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                    nameof(ReservaHttpClient),
                    nameof(Delete),
                    ex.Message);

                return Response.Fail("Erro ao atualizar status", false);
            }
        }

        public async Task<Response> Get(int id)
        {
            try
            {
                var responseJson = await _httpClient.GetAsync("Get");

                string responseBody = await responseJson.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<Response>(responseBody);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                    nameof(ReservaHttpClient),
                    nameof(Get),
                    ex.Message);

                return Response.Fail("Erro ao atualizar status", false);
            }
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var result = _fixture.Create<Response>();
                var content = _fixture.CreateMany<SalaViewModel>().ToList();
                result.Result = content;
                return result;
                //var responseJson = await _httpClient.GetAsync("GetAll");

                //string responseBody = await responseJson.Content.ReadAsStringAsync();
                //var response = JsonSerializer.Deserialize<Response>(responseBody);
                //return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                    nameof(ReservaHttpClient),
                    nameof(ChangeStatus),
                    ex.Message);

                return Response.Fail("Erro ao atualizar status", false);
            }
        }

        public async Task<Response> Update(Reserva entity)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(entity);
                var stringContext = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseJson = await _httpClient.PostAsync(jsonData, stringContext);

                string responseBody = await responseJson.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<Response>(responseBody);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                    nameof(ReservaHttpClient),
                    nameof(Update),
                    ex.Message);

                return Response.Fail("Erro ao atualizar status", false);
            }
        }
    }
}
