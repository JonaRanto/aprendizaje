using System;
using System.Collections.Generic;

namespace AlimentoMascotas.Models
{
    public class AlimentoInput
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public int MarcaId { get; set; }
        public int EspecieId { get; set; }
        public int EtapaId { get; set; }
    }

    public class AlimentoOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string Marca { get; set; }
        public string Especie { get; set; }
        public string Etapa { get; set; }
        public List<IngredienteEnAlimentoOutput> Ingredientes { get; set; }
        public List<AditivoEnAlimentoOutput> Aditivos { get; set; }
        public List<AnaliticoEnAlimentoOutput> Analiticos { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
