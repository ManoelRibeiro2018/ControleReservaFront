using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Interface.HttpClient;
using ControleReserva.Domain.Interface.Service;
using ControleReserva.Domain.Model;
using ControleReservaDomain.Enum;
using Microsoft.Extensions.Logging;

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

        public async Task<Response> ChangeStatus(int id, Status status)
        {
            _logger.LogInformation("Atualizando status da reserva {Id} para {Status}", id, status);
            var result = await _reservaHttpClient.ChangeStatus(id, status);
            return result;
        }

        public async Task<Response> Create(ResevaInputModel entity)
        {
            _logger.LogInformation("Criando reserva");
            var reserva = Reserva.Map(entity);
            var result = await _reservaHttpClient.Create(reserva);
            return result;
        }

        public async Task<Response> Delete(int id)
        {
            _logger.LogInformation("Removendo reserva: {Id}", id);
            var result = await _reservaHttpClient.Delete(id);
            return result;
        }

        public async Task<Response> Get(int id)
        {
            return await _reservaHttpClient.Get(id);
        }

        public async Task<Response> GetAll()
        {
            return await _reservaHttpClient.GetAll();
        }

        public async Task<Response> Update(ResevaInputModel entity)
        {
            var reserva = Reserva.Map(entity);
            var result = await _reservaHttpClient.Update(reserva);
            return result;
        }
    }
}
