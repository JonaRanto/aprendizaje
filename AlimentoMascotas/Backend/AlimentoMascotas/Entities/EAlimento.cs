using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlimentoMascotas.Entities
{
    public class EAlimento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Size { get; set; }
        public int MarcaId { get; set; }
        public int EspecieId { get; set; }
        public int EtapaId { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<EIngredienteEnAlimento> Ingredientes { get; set; }
        public List<EAditivoEnAlimento> Aditivos { get; set; }
        public List<EAnaliticoEnAlimento> Analiticos { get; set; }
        [ForeignKey("MarcaId")]
        public EMarca Marca { get; set; }
        [ForeignKey("EspecieId")]
        public EEspecie Especie { get; set; }
        [ForeignKey("EtapaId")]
        public EEtapa Etapa { get; set; }
    }
}
