using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repo
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
