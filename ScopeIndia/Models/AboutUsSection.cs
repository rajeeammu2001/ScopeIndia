namespace ScopeIndia.Models
{
    public class AboutUsSection
    {

        public int Id { get; set; }
        public string SectionName { get; set; } // e.g. Mission, Vision, Our Story
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; } // for logo, gif, etc.
        public string Position { get; set; } // "left" or "right"

       
    }
}
