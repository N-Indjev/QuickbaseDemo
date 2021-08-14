using System.Collections.Generic;

namespace QB.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<State> States { get; set; } = new HashSet<State>();
    }
}