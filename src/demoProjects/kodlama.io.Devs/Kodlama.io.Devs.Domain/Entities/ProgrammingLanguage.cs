using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }

        public ProgrammingLanguage() { }

        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
