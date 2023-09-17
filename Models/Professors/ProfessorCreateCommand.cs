using System.ComponentModel.DataAnnotations;

namespace CourseCatalogAPI.Models.Professors
{
    public class ProfessorCreateCommand
    {
        public string ProfessorName { get; set; } = string.Empty;

        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Invalid email format.")]
        public string? ProfessorEmail { get; set; }
    }
}
