using System.ComponentModel.DataAnnotations.Schema;

namespace AlimentoMascotas.Entities
{
    public class EIngredienteEnAlimento
    {
        public int IngredienteId { get; set; }
        public int AlimentoId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal QuantityPer { get; set; }
        [ForeignKey("IngredienteId")]
        public EIngrediente Ingrediente { get; set; }
        [ForeignKey("AlimentoId")]
        public EAlimento Alimento { get; set; }
    }
}
