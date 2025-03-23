using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generic_Repository.Entity
{
    public class Order
    {
        [Key] // ✅ Ensure Primary Key
        public int Id { get; set; }

        [ForeignKey("Product")] // ✅ Foreign Key
        public int ProductId { get; set; }

        public required Product Product { get; set; }
    }
}
