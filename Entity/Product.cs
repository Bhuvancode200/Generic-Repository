using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Generic_Repository.Entity
{
    public class Product
    {
        [Key] // ✅ Ensure Primary Key is Explicitly Defined
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        // ✅ Navigation Property
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
