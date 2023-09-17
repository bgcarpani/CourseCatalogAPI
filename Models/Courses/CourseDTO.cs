using System.Globalization;

namespace CourseCatalogAPI.Models.Courses
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
        public string ProfessorName { get; set; } = "TBD";
        public string ProfessorEmail { get; set; } = "TBD";
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = "TBD";
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
