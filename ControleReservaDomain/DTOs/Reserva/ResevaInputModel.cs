using ControleReservaDomain.DTOs.InputModel;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.DTOs.Reserva
{
    public class ResevaInputModel
    {
        public SalaInputModel Sala { get; set; }
        public UsuarioInputModel Usuario { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; } = Status.Confirmada;
    }
}
