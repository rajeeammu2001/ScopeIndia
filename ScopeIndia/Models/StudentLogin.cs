using System.ComponentModel.DataAnnotations;

namespace ScopeIndia.Models
{
    public class StudentLogin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Password { get; set; }  

        public string? TempPassword { get; set; } 

        public bool IsTempPassword { get; set; } = false;

        
        
    }
}
