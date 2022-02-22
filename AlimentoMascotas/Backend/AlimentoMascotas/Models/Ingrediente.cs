namespace AlimentoMascotas.Models
{
    public class IngredienteInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class IngredienteOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
