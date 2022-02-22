using System.Collections.Generic;

namespace AlimentoMascotas.Entities
{
    public class EIngrediente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EIngredienteEnAlimento> Alimentos { get; set; }
    }
}
