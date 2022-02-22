namespace AlimentoMascotas.Models
{
    public class ApiResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

        public ApiResponse()
        {
            Error = false;
            Message = null;
            Data = null;
        }
    }
}
