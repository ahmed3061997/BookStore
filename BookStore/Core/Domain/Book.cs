using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CoverImg { get; set; }

        public virtual Author Author { get; set; }
    }
}
