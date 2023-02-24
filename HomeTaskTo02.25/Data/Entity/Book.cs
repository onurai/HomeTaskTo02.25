using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace HomeTaskTo02._25.Data.Entity
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime PurchasedDate { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author? Author { get; set; } 
    }
}
