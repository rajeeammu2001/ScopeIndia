namespace ScopeIndia.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }  // E.g., "Data Science", "Software"

        public string? Duration { get; set; }          // e.g., "6 Month + 3 Month OJT"
        public string? Timing { get; set; }            // e.g., "Mon–Fri Offline 4 hrs. / Online 2 hrs."
        public string? BatchDate { get; set; }         // e.g., "14th July, 2025"
        public string? LongDescription { get; set; }   // Full course description
        public string? Syllabus { get; set; }          // Comma-separated string of topics

        public decimal? Fee { get; set; }

        // Navigation property (optional)
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
