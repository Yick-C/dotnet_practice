using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDo_Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")] // Shows the given text rather than the property name
        [Range(1, 100, ErrorMessage="Display Order must be between 1 and 100")] // Error message if number is not in this range
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
