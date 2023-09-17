namespace CourseCatalogAPI.Models.Courses
{
    public class CourseUpdateCommand
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int? ProfessorId { get; set; }
        public int? RoomId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
