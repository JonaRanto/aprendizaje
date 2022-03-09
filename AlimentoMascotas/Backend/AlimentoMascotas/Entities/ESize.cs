using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlimentoMascotas.Entities
{
    public class ESize
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Size { get; set; }
        public List<ESizeEnAlimento> Alimentos { get; set; }
    }
}
