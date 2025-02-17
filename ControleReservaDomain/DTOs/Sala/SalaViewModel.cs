using ControleReserva.Domain.DTOs.Reserva;

namespace ControleReserva.Domain.DTOs.Sala
{
    public class SalaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReservaViewModel> ReservaViews { get; set; }
    }
}
