using Core.Entities;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
