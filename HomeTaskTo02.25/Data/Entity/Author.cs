using System.ComponentModel.DataAnnotations;

namespace HomeTaskTo02._25.Data.Entity
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
