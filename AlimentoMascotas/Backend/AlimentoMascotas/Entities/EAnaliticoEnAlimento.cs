using System.ComponentModel.DataAnnotations.Schema;

namespace AlimentoMascotas.Entities
{
    public class EAnaliticoEnAlimento
    {
        public int AnaliticoId { get; set; }
        public int AlimentoId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal QuantityPer { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal QuantityGra { get; set; }
        [ForeignKey("AnaliticoId")]
        public EAnalitico Analitico { get; set; }
        [ForeignKey("AlimentoId")]
        public EAlimento Alimento { get; set; }
    }
}
