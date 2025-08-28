using Microsoft.EntityFrameworkCore;
using ScopeIndia.Models;

namespace ScopeIndia.Data
{
    public class MVCDBContext:DbContext
    {
        public MVCDBContext(DbContextOptions<MVCDBContext> options) : base(options) { }

        //public DbSet<Hero> Heroes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<AboutUsSection> AboutUsSections { get; set; }
        public DbSet<AboutUsStats> AboutUsStats { get; set; }

        public DbSet<ContactLocation> ContactLocations { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentLogin> StudentLogins { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AboutUsSection>().HasData(
                new AboutUsSection
                {
                    Id = 1,
                    SectionName = "Intro",
                    Title = "SCOPE INDIA, your career partner!",
                    Content = "One of India's best Training destinations...",
                    ImageUrl = "images/aboutus/google-rating.png",
                    Position = "center"
                },
                new AboutUsSection
                {
                    Id = 2,
                    SectionName = "Story",
                    Title = "Founded in 2007",
                    Content = "With over two decades of experience...",
                    ImageUrl = "images/aboutus/team-animation.gif",
                    Position = "right"
                },
                new AboutUsSection
                {
                    Id = 3,
                    SectionName = "Evolution",
                    Title = "Evolution",
                    Content = "SCOPE INDIA was launched in 2015...",
                    ImageUrl = "",
                    Position = "left"
                },
                new AboutUsSection
                {
                    Id = 4,
                    SectionName = "Growth",
                    Title = "Growth",
                    Content = "SCOPE INDIA began its journey...",
                    ImageUrl = "",
                    Position = "left"
                },
                new AboutUsSection
                {
                    Id = 5,
                    SectionName = "Present Day Impact",
                    Title = "Present Day Impact",
                    Content = "SCOPE INDIA has helped 15,000+ students...",
                    ImageUrl = "",
                    Position = "right"
                },
                new AboutUsSection
                {
                    Id = 6,
                    SectionName = "Mission",
                    Title = "Our Mission",
                    Content = "SCOPE INDIA seeks to close the knowledge gap...",
                    ImageUrl = "",
                    Position = "left"
                },
                new AboutUsSection
                {
                    Id = 7,
                    SectionName = "Vision",
                    Title = "Our Vision",
                    Content = "We aspire to become the most respected...",
                    ImageUrl = "",
                    Position = "right"
                }
            );

            modelBuilder.Entity<AboutUsStats>().HasData(
                new AboutUsStats { Id = 1, Label = "Students are Placed", Value = "15000+" },
                new AboutUsStats { Id = 2, Label = "Partner Companies", Value = "500+" },
                new AboutUsStats { Id = 3, Label = "Placement Assistance", Value = "100%" }
            );

          

            //  ContactLocations
            modelBuilder.Entity<ContactLocation>().HasData(
                new ContactLocation
                {
                    Id = 1,
                    Title = "SCOPE INDIA Trivandrum, Kerala",
                    Address = "TC 25/1403/3, Athens Plaza, KS Kovil Road, Thampanoor, Trivandrum, Kerala 695001",
                    Phone = "9745936073",
                    Email = "info@scopeindia.org",
                    RouteLink = "Location Route Map"
                },
                new ContactLocation
                {
                    Id = 2,
                    Title = "SCOPE INDIA Technopark, Kerala",
                    Address = "Phase 1, Main Gate, Diamond Arcade, Near Technopark, Trivandrum",
                    Phone = "9745936073",
                    Email = "technopark@scopeindia.org",
                    RouteLink = "Location Route Map"
                },
                new ContactLocation
                {
                    Id = 3,
                    Title = "SCOPE INDIA Kochi, Kerala",
                    Address = "Vasanth Nagar Rd, near JLN Metro Station, Kaloor, Kochi, Kerala 682025",
                    Phone = "7592939481",
                    Email = "kochi@scopeindia.org",
                    RouteLink = "Location Route Map"
                },
                new ContactLocation
                {
                    Id = 4,
                    Title = "SCOPE INDIA Nagercoil 1, Tamil Nadu",
                    Address = "Near WCC College, Palace Road, Nagercoil, Tamil Nadu 629001",
                    Phone = "8075536185",
                    Email = "ngl@scopeindia.org",
                    RouteLink = "Location Route Map"
                },
                new ContactLocation
                {
                    Id = 5,
                    Title = "SCOPE INDIA Nagercoil 2, Tamil Nadu",
                    Address = "Pharma Street, 5/2 Ward 28, Distillery Road, WCC Jn, Nagercoil",
                    Phone = "8075536185",
                    Email = "ngl@scopeindia.org",
                    RouteLink = "Location Route Map"
                }
            );

            // Configure StudentCourse relationships
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => sc.Id);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);











        }
       




    }
}
