namespace AlimentoMascotas.Models
{
    public class AditivoEnAlimentoInput
    {
        public int AditivoId { get; set; }
        public int QuantityUI { get; set; }
        public decimal QuantityGra { get; set; }
    }

    public class AditivoEnAlimentoOutput
    {
        public string Name { get; set; }
        public int QuantityUI { get; set; }
        public decimal QuantityGra { get; set; }
    }
}
