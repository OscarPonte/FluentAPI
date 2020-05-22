using System.Collections.Generic;

namespace FluentAPI
{
    public class Tag
    {
        public Tag()
        {
            Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}