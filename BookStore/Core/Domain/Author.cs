using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Image { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
