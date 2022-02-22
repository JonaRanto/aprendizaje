namespace AlimentoMascotas.Models
{
    public class AnaliticoEnAlimentoInput
    {
        public int AnaliticoId { get; set; }
        public decimal QuantityPer { get; set; }
        public decimal QuantityGra { get; set; }
    }

    public class AnaliticoEnAlimentoOutput
    {
        public string Name{ get; set; }
        public decimal QuantityPer { get; set; }
        public decimal QuantityGra { get; set; }
    }
}
