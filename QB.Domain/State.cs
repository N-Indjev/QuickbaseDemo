using System.Collections.Generic;

namespace QB.Domain
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}