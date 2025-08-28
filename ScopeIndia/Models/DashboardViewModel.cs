namespace ScopeIndia.Models
{
    public class DashboardViewModel
    {
        public string StudentName { get; set; }
        public string Email { get; set; }
        public List<Course> AvailableCourses { get; set; }
        public List<Course> PickedCourses { get; set; }
    }
}
