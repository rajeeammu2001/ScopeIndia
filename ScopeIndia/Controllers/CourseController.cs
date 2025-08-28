using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScopeIndia.Data;
using ScopeIndia.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScopeIndia.Controllers
{
    public class CourseController : Controller
    {
        private readonly MVCDBContext _context;

        public CourseController(MVCDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                // Seed initial data if empty
                if (!_context.Courses.Any())
                {
                    _context.Courses.AddRange(
                        new Course
                        {
                            Title = "Data Science & AI Course",
                            Category = "Data Science",
                            Description = "AI and ML",
                            Duration = "6 Month + 3 Month OJT",
                            Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                            BatchDate = "14th July, 2025",
                            LongDescription = "This comprehensive program equips you with the skills to excel in data–driven fields, mastering tools like Python 3.12, MySQL, and Django. Dive deep into data processing with Pandas, NumPy, and advanced data visualization using Matplotlib, Seaborn, and Tableau. You'll also gain expertise in machine learning including supervised, unsupervised, and reinforcement learning, plus deep learning & AI with live projects.\n\nMaster the fundamentals of REST services, GIT version control, and web hosting techniques. Real-world exposure comes through live projects with Suffix E Solutions, helping you apply what you’ve learned. The program also emphasizes logical reasoning and includes interview preparation and on-the-job training, ensuring you’re ready to hit the ground running in any data science role.",
                            Syllabus = "Python 3.12,MySQL,SQLite,Django,REST Services,Regular Expressions,Excel Basics,Power BI,Pandas,NumPy,Matplotlib and Seaborn,Data Visualisation using Tableau,Data Distribution,Machine Learning (Supervised, Unsupervised, Reinforcement Learning),Deep Learning & AI,GIT Version Control,Web Hosting Techniques,Logical Reasoning,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,Placement Support",
                            Fee = 35000M

                        },
                        new Course
                        {
                            Title = "Data Analytics Course",
                            Category = "Data Science",
                            Description = "Analytics with Python & Excel",
                            Duration = "4 Month + 3 Month OJT",
                            Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                            BatchDate = "14th July, 2025",
                            LongDescription = "Begin your journey into the world of data with our Data Analytics Course & Internship! This program is designed to equip you with essential data analysis skills using tools like Python 3.12, MySQL, and popular libraries such as Pandas, NumPy, and Matplotlib. You'll learn how to process, analyze, and visualize data, converting complex information into actionable insights effortlessly.\r\n\r\nGain valuable real-world experience through live projects in partnership with Suffix E Solutions, where you'll apply your skills in real business scenarios and sharpen your expertise. The course also includes interview preparation, on-the-job training, and tailored placement support, ensuring you're fully prepared to secure a role in the data analytics field\r\n\r\nBy completing this program, you'll develop the ability to extract insights, make data-driven decisions, and present your findings effectively, skills highly sought after across industries. With a blend of technical training and practical experience, this course empowers you to confidently advance in your career in data analytics.",
                            Syllabus = "Python 3.12,SQL,Data Processing using Pandas,NumPy,Data Visualisation using Matplotlib,Data Visualisation using Tableau,Corporate Culture & Ethics,Interview Preparation,Excel Basics,Power BI,AI Tools,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,Placement Support",
                            Fee = 25000M
                        },
                        new Course
                        {
                            Title = "Microsoft Power BI Course",
                            Category = "Data Science",
                            Description = "BI dashboard",
                            Duration = "3 Month + 3 Month OJT",
                            Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                            BatchDate = "14th July, 2025",
                            LongDescription = "This all-inclusive program is designed to provide learners with essential skills in data analysis, Microsoft Excel, SQL, and Power BI. Participants will also explore Power Query for seamless data transformation and gain hands-on experience through live projects with Suffix E Solutions, applying their knowledge to practical business scenarios.\r\n\r\nDesigned with career success in mind, the course offers interview preparation, on-the-job training, and personalized placement support, ensuring a smooth transition into roles in data analytics and reporting. Through learning Power BI, participants will acquire the ability to create impactful dashboards, extract actionable insights, and enable data-driven decision-making in professional environments.\r\n\r\nPerfect for those eager to enhance their analytical skills and advance their careers in data visualization, this program equips learners with the tools and knowledge necessary to become Power BI specialists. Take the first step toward achieving your goals!",
                            Syllabus = "Data Analysis,Microsoft Excel,SQL,Power BI,Power Query,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,\r\nPlacement Support",
                            Fee = 5000M
                        },

                        new Course
                        {
                            Title = "Java Full Stack Course",
                            Category = "Software",
                            Description = "Java, Spring Boot, Angular",
                            Duration = "5 Month + 3 Month OJT",
                            Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                            BatchDate = "14th July, 2025",
                            LongDescription = "Our Java Full Stack Course & Internship Program is designed to elevate your career by offering comprehensive training in both front-end and back-end development. The curriculum includes key areas such as Java programming, advanced frameworks like Spring Boot and Hibernate, object-oriented programming, database management, API integration, cloud deployment, and front-end technologies like HTML, CSS, and JavaScript. By the end of the program, participants will possess the expertise required to manage the entire web application development lifecycle. The internship component enhances the learning experience by providing hands-on exposure to real-world projects, guided by industry professionals, ensuring participants are well-prepared to face workplace challenges with confidence.\r\n\r\nThis program opens up diverse career opportunities, including roles such as Java Developer, Full Stack Developer, Software Engineer, Technical Architect, and Web Developer. Full-stack developers remain highly sought after and benefit from excellent career advancement prospects. Entry-level professionals in India can expect salaries between ₹4-₹7 LPA, while experienced developers may earn ₹12-₹20 LPA or more. Globally, salaries for full-stack developers range from $70,000 to $120,000 annually, with even higher earning potential in leading IT hubs like the US, UK, and Australia. Alongside acquiring a versatile skill set, participants will build a robust portfolio, giving them a competitive advantage in the evolving job market.",
                            Syllabus = "Java,J2EE,Spring (MVC),Spring Boot,MySQL,HTML 6,CSS 4,Bootstrap 5 / SASS,JavaScript ES 7,JQuery,React JS/Angular,\r\nREST Services,SEO Basics,GIT Version Control,Web Hosting,Logic Enhancement,AI Tools,Photoshop Graphic Designing,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,\r\nPlacement Support",
                            Fee = 25000M
                        },
                        new Course
                        {
                            Title = "Python Full Stack Course",
                            Category = "Software",
                            Description = "Python, Django, React",
                            Duration = "5 Month + 3 Month OJT",
                            Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                            BatchDate = "14th July, 2025",
                            LongDescription = "The Python Full Stack Course & Internship equips students with extensive skills for end-to-end web development. The course covers front-end technologies like HTML 6 , CSS 4, JavaScript ES 7, and Bootstrap 5 to create dynamic user interfaces, and back-end development with Django to build robust server-side applications. Students also explore database management using SQL and NoSQL tools like MySQL and MongoDB, API integration for seamless data exchange, and deployment. Through real-world projects in the internship, participants gain practical experience and a strong portfolio to boost career prospects. Python's versatility ensures opportunities in web development, AI, and data science, with roles such as Python Full Stack Developer, Web Developer, and Machine Learning Engineer. Freshers in India can expect salaries ranging from ₹3,50,000 to ₹8,00,000 per annum, with experienced professionals earning over ₹20,00,000. The course emphasizes project-based learning, boosting industry-relevant skills and flexibility, with Python's popularity ensuring high demand and competitive salaries across multiple fields.",
                            Syllabus = "Python 3.12,Django,SQLite,MySQL,HTML 6,CSS 4,Bootstrap 5 / SASS,JavaScript ES 7,JQuery,React JS,Regular Expressions,REST Services,SEO Basics,GIT Version Control,Web Hosting,Logic Enhancement,AI Tools,Photoshop Graphic Designing,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,\r\nPlacement Support",
                            Fee = 35000M
                        },
                         new Course
                         {
                             Title = "PHP Full Stack Course",
                             Category = "Software",
                             Description = "PHP, MySQL, Laravel",
                             Duration = "5 Month + 3 Month OJT",
                             Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                             BatchDate = "14th July, 2025",
                             LongDescription = "Our PHP Full Stack Development Internship Program is tailored to help aspiring developers, students, and recent graduates build successful careers in web development. This program covers front-end and back-end technologies, with PHP as the core language. Participants will master HTML6, CSS4, JavaScript, and frameworks like React.js , as well as PHP fundamentals, object-oriented programming (OOP), frameworks like Laravel and CodeIgniter, and RESTful APIs for robust server-side applications. The program also prioritizes database management with tools like MySQL and MongoDB, along with version control tools like Git and GitHub to streamline collaboration. Live projects guided by expert mentors ensure hands-on experience, creating a professional portfolio that stands out to employers.\r\n\r\nGraduates gain career readiness through resources like resume support, interview preparation, and certification, positioning them for roles such as PHP Full Stack Developer, Web Developer, or Application Developer. This internship combines technical expertise with industry insights and networking opportunities, enabling participants to thrive in the evolving digital sector. Whether you're new to web development or looking to enhance your skills, this program equips you with the practical knowledge and confidence needed to achieve your career aspirations.",
                             Syllabus = "PHP 8,Codeigniter 4 / Laravel 11,WordPress,SQLite,MySQL,HTML 6,CSS 4,Bootstrap 5 / SASS,JavaScript ES 7,JQuery,React JS,Regular Expressions,REST Services,SEO Basics,GIT Version Control,Web Hosting,Logic Enhancement,AI Tools,Photoshop Graphic Designing,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,\r\nPlacement Support",
                             Fee = 20000M
                         },
                          new Course
                          {
                              Title = ".Net Core Full Stack Course",
                              Category = "Software",
                              Description = ".Net Core, MVC, EF Core",
                              Duration = "5 Month + 3 Month OJT",
                              Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                              BatchDate = "14th July, 2025",
                              LongDescription = "The .NET Core Full Stack Course equips learners with essential skills to excel in full-stack development, focusing on dynamic and scalable web applications. It covers both front-end technologies such as HTML, CSS, JavaScript, and React for crafting interactive user interfaces, and back-end development using C# programming, ASP.NET Core, and RESTful APIs to create robust server-side applications. The program also emphasizes database management with tools like SQL Server for efficient data handling and cloud deployment techniques using Azure. Through practical learning and live projects, participants develop a strong portfolio that enhances career prospects across industries such as IT, healthcare, banking, and e-commerce.\r\n\r\nGraduates gain access to various roles, including .NET Core Full Stack Developer, Web Developer, Software Engineer, Application Developer, and Solutions Architect. These positions offer promising career growth, with entry-level salaries in India ranging from ₹3,50,000 to ₹8,00,000 per annum, and experienced professionals earning ₹10,00,000 to ₹22,00,000+ per annum. Globally, compensation spans $70,000 to $120,000 annually, with even higher packages available in IT hubs like the US, UK, and Australia. The course fosters versatility, scalability, and problem-solving skills, positioning learners as competitive and in-demand professionals in the tech industry.",
                              Syllabus = "C# .Net,.Net 6 Core MVC,Razor Coding\r\n,MySQL,HTML 6,CSS 4,Bootstrap 5 / SASS,JavaScript ES 7,JQuery,React JS,Regular Expressions,REST Services,SEO Basics,GIT Version Control,Web Hosting,Logic Enhancement,AI Tools,Photoshop Graphic Designing,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,\r\nPlacement Support",
                              Fee = 35000M
                          },
                           new Course
                           {
                               Title = "MERN Full Stack Course",
                               Category = "Software",
                               Description = "MongoDB, Express, React, Node.js",
                               Duration = "5 Month + 3 Month OJT",
                               Timing = "Mon–Fri Offline 4 hrs. / Online 2 hrs.",
                               BatchDate = "14th July, 2025",
                               LongDescription = "Maximize your full-stack development skills with our exclusive MERN Stack Training Program. This course covers every aspect of full-stack development, enabling you to build scalable and reliable web applications while gaining hands-on experience and industry-relevant skills. The curriculum includes MongoDB for efficient NoSQL database management, Express JS for powerful back-end development, React JS for dynamic user interfaces, and Node JS for seamless server-side logic. You will also explore JavaScript ES7 for optimized coding, MySQL for relational databases, HTML 6, CSS 4, and Bootstrap 5 for visually appealing and responsive designs. Additional topics like regular expressions, RESTful APIs, SEO basics, and version control tools such as Git prepare you for modern development practices.\r\n\r\nBeyond technical training, the program highlights practical exposure through live projects in collaboration with Suffix E Solutions, helping you build real-world experience. You will also benefit from interview preparation, on-the-job training, and placement support to seamlessly transition into professional roles. Whether you are new to web development or looking to enhance your skills, this course blends theoretical knowledge with practical application, empowering you to innovate and excel as a versatile full-stack developer in a competitive industry. Achieve your career aspirations with confidence and expertise.",
                               Syllabus = "MongoDB,Express JS,React JS,Node JS\r\n,MySQL,HTML 6,CSS 4,Bootstrap 5 / SASS,JavaScript ES 7,JQuery,React JS,Regular Expressions,REST Services,SEO Basics,GIT Version Control,Web Hosting,Logic Enhancement,AI Tools,Photoshop Graphic Designing,English Language Training,Corporate Culture & Ethics,Interview Preparation,On the Job Training,Live Projects with Suffix E Solutions,\r\nPlacement Support",
                               Fee = 30000M
                           },





                       
                        new Course { Title = "MEAN Full Stack Course", Category = "Software", Description = "MongoDB, Express, Angular, Node.js" },
                        new Course { Title = "Android/iOS Mobile App Course in Google Flutter Course", Category = "Software", Description = "Flutter, Dart" },
                        new Course { Title = "Website Designing Course", Category = "Software", Description = "HTML, CSS, Bootstrap" },
                        new Course { Title = "UI/UX Design Course", Category = "Software", Description = "Figma, Prototyping, Wireframes" },

                        new Course { Title = "DevOps Engineer Course", Category = "DevOps", Description = "CI/CD, Jenkins, Docker" },
                        new Course { Title = "AWS Architect Associate Course", Category = "DevOps", Description = "Cloud Solutions" },
                        new Course { Title = "Cisco Certified Network Associate(CCNA) Course", Category = "DevOps", Description = "Networking Basics" },
                        new Course { Title = "MS Azure Cloud Administrator Course", Category = "DevOps", Description = "Azure Administration" },
                        new Course { Title = "Red Hat Certified System Administrator (RHCSA) Course", Category = "DevOps", Description = "Linux Admin" },
                        new Course { Title = "Red Hat Certified Engineer (RHCE) Course", Category = "DevOps", Description = "Linux Certification" },
                        new Course { Title = "Networking, Server, & Cloud Administration Course", Category = "DevOps", Description = "Comprehensive training" },

                        new Course { Title = "ISTQB Manual Testing Course", Category = "Testing", Description = "Manual testing foundation" },
                        new Course { Title = "Software Testing Advanced Course", Category = "Testing", Description = "Advanced manual & automation" },
                        new Course { Title = "Software Automation Testing Course", Category = "Testing", Description = "Selenium, JMeter" },

                        new Course { Title = "Salesforce", Category = "Other", Description = "CRM Platform" },
                        new Course { Title = "Digital Marketing Expert Course", Category = "Other", Description = "SEO, SEM, SMM, Email & Content Marketing" }
                    );
                    _context.SaveChanges();
                }

                var data = _context.Courses.ToList();

                ViewBag.DataScience = data.Where(c => c.Category == "Data Science").ToList();
                ViewBag.Software = data.Where(c => c.Category == "Software").ToList();
                ViewBag.DevOps = data.Where(c => c.Category == "DevOps").ToList();
                ViewBag.Testing = data.Where(c => c.Category == "Testing").ToList();
                ViewBag.Other = data.Where(c => c.Category == "Other").ToList();

                return View(data);
            }
            catch (Exception ex)
            {
                return Content("ERROR: " + ex.Message);
            }
        }

        // Dynamic course details page
        public IActionResult Details(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            // Auto-add to picked courses if student is logged in
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId != null)
            {
                bool alreadyPicked = _context.StudentCourses
                    .Any(sc => sc.StudentId == studentId.Value && sc.CourseId == course.Id);
                if (!alreadyPicked)
                {
                    _context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = studentId.Value,
                        CourseId = course.Id
                    });
                    _context.SaveChanges();
                }
            }

            return View("Details", course); // Single dynamic view




            // If it's the Data Science course, use custom view
            if (course.Title == "Data Science & AI Course")
                return View("DataScienceAI", course);

            if (course.Title == "Data Analytics Course")
                return View("DataAnalytics", course);

            if (course.Title == "Microsoft Power BI Course")
                return View("PowerBI", course);

            if (course.Title == "Java Full Stack Course")
                return View("JavaStack", course);

            if (course.Title == "Python Full Stack Course")
                return View("PythonStack", course);


            if (course.Title == "PHP Full Stack Course")
                return View("PHPStack", course);

            if (course.Title == ".Net Core Full Stack Course")
                return View(".NetStack", course);

            if (course.Title == "MERN Full Stack Course")
                return View("MERNStack", course);

            // Default view for other courses (can create CourseDetails.cshtml)
            return View("CourseDetails", course);





        }

    }
}
