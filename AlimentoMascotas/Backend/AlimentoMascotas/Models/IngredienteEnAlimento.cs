namespace AlimentoMascotas.Models
{
    public class IngredienteEnAlimentoInput
    {
        public int IngredienteId { get; set; }
        public decimal QuantityPer { get; set; }
    }

    public class IngredienteEnAlimentoOutput
    {
        public string Name { get; set; }
        public decimal QuantityPer { get; set; }
    }
}
