namespace QB.Services.Models
{
    public sealed record CountryPopulation(string CountryName, int Population)
    {
        public CountryPopulation() : this(string.Empty, 0)
        {
        }
        
        public bool Equals(CountryPopulation? other)
        {
            return string.Equals(CountryName, other?.CountryName);
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(CountryName) ? 0 : CountryName.GetHashCode();
        }
    }
}