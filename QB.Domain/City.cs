namespace QB.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Population { get; set; }
        
        public int StateId { get; set; }
        public State? State { get; set; }
    }
}