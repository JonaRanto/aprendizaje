using System.Collections.Generic;

namespace AlimentoMascotas.Entities
{
    public class EAnalitico
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EAnaliticoEnAlimento> Alimentos { get; set; }
    }
}
