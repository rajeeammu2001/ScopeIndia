using System.ComponentModel.DataAnnotations;

namespace ScopeIndia.Models
{
    //Registaration form
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string EducationalQualification { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string GuardianName { get; set; }
        public string GuardianOccupation { get; set; }
        public string GuardianMobile { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string TrainingMode { get; set; }

        [Required]
        public string ScopeLocation { get; set; }

        
        public string PreferredTimingsDb { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinZipCode { get; set; }

        
        public string EmailConfirmationToken { get; set; }
        public bool EmailConfirmed { get; set; } = false;

        // Navigation property
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
