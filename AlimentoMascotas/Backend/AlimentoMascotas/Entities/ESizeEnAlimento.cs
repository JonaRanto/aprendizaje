using System.ComponentModel.DataAnnotations.Schema;

namespace AlimentoMascotas.Entities
{
    public class ESizeEnAlimento
    {
        public int SizeId { get; set; }
        public int AlimentoId { get; set; }
        [ForeignKey("SizeId")]
        public ESize Size { get; set; }
        [ForeignKey("AlimentoId")]
        public EAlimento Alimento { get; set; }
    }
}
