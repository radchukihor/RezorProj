using System.ComponentModel.DataAnnotations;

namespace RazorProjectWeb.Model
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Order Name")]
        public string Name { get; set; }

        [Display(Name ="Display order")]
        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100.")]
        public int DisplayOrder { get; set; }
    }
}
