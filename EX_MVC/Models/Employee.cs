using System.ComponentModel.DataAnnotations;

namespace EX_MVC.Models
{
    public class Employee
    {
       public int Id { get; set; }
        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        [Display(Name= "Emp Name")]
        public string Name { get; set; } = null!;
        [EmailAddress]
        [MaxLength(50)]
        [Required]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
