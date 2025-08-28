using Microsoft.EntityFrameworkCore;

namespace ScopeIndia.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime SignedUpDate { get; set; } = DateTime.Now;

      
    }
}
//to store which student signed up for which course
