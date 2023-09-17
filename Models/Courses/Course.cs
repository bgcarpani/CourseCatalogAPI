using CourseCatalogAPI.Models.Professors;
using CourseCatalogAPI.Models.Rooms;

namespace CourseCatalogAPI.Models.Courses
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Professor? Professor { get; set; }
        public Room? Room { get; set; }
    }
}
