using System.Collections.Generic;

namespace AlimentoMascotas.Entities
{
    public class EAditivo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EAditivoEnAlimento> Alimentos { get; set; }
    }
}
