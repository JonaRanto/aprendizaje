namespace AlimentoMascotas.Entities
{
    public class EMarca
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EAlimento Alimento { get; set; }
    }
}
