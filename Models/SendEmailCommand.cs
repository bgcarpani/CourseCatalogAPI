namespace CourseCatalogAPI.Models
{
    public class SendEmailCommand
    {
        public string ToAddress { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
