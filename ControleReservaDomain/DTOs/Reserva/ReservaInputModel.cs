using ControleReservaDomain.DTOs.InputModel;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.DTOs.Reserva
{
    public class ReservaInputModel
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public UsuarioInputModel Usuario { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; } = Status.Confirmada;
    }
}
