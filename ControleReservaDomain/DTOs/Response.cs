namespace ControleReserva.Domain.DTOs
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Result { get; set; }
        public bool  Success { get; set; }
    }
}
