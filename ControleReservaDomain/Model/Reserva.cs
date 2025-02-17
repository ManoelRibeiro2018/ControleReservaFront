using ControleReserva.Domain.DTOs.Reserva;
using ControleReservaDomain.DTOs.InputModel;
using ControleReservaDomain.Enum;

namespace ControleReserva.Domain.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public UsuarioInputModel Usuario { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }

        public static Reserva Map(ResevaInputModel entity) => new()
        {
            Id = entity.Id,
            SalaId = entity.SalaId,
            Usuario = entity.Usuario,
            Data = entity.Data,
            Status = entity.Status,
        };
    }
}
