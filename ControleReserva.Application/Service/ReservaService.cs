using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Interface.HttpClient;
using ControleReserva.Domain.Interface.Service;
using ControleReserva.Domain.Model;
using ControleReservaDomain.Enum;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ControleReserva.Application.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaHttpClient _reservaHttpClient;
        private readonly ILogger<ReservaService> _logger;

        public ReservaService(IReservaHttpClient reservaHttpClient,
            ILogger<ReservaService> logger)
        {
            _reservaHttpClient = reservaHttpClient;
            _logger = logger;
        }

        public async Task ChangeStatus(int id, Status status)
        {
            _logger.LogInformation("Atualizando status da reserva {Id} para {Status}", id, status);
            var result = await _reservaHttpClient.ChangeStatus(id, status);
        }

        public async Task Create(ReservaInputModel entity)
        {
            _logger.LogInformation("Criando reserva");
            var reserva = Reserva.Map(entity);
            var result = await _reservaHttpClient.Create(reserva);
        }

        public async Task Delete(int id)
        {
            _logger.LogInformation("Removendo reserva: {Id}", id);
            var result = await _reservaHttpClient.Delete(id);
        }

        public async Task<ReservaViewModel> Get(int id)
        {
            var result = await _reservaHttpClient.Get(id);            
            return (ReservaViewModel)result.Result;
        }

        public async Task<List<ReservaViewModel>> GetAll()
        {
            var result = await _reservaHttpClient.GetAll();
            if (result.Success)
            {
                return JsonConvert.DeserializeObject<List<ReservaViewModel>>(JsonConvert.SerializeObject(result.Result));
            }
            return [];
        }

        public async Task Update(ReservaInputModel entity)
        {
            var reserva = Reserva.Map(entity);
            var result = await _reservaHttpClient.Update(reserva);
        }
    }
}
