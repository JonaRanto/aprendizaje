using System.ComponentModel.DataAnnotations.Schema;

namespace AlimentoMascotas.Entities
{
    public class EAditivoEnAlimento
    {
        public int AditivoId { get; set; }
        public int AlimentoId { get; set; }
        public int QuantityUI { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal QuantityGra { get; set; }
        [ForeignKey("AditivoId")]
        public EAditivo Aditivo { get; set; }
        [ForeignKey("AlimentoId")]
        public EAlimento Alimento { get; set; }
    }
}
