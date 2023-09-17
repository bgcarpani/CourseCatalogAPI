using CourseCatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/email")]
public class EmailController : ControllerBase
{
    private readonly EmailService emailService;

    public EmailController(EmailService emailService)
    {
        this.emailService = emailService;
    }

    [HttpPost]
    public IActionResult SendEmail([FromBody] SendEmailCommand emailRequest)
    {
        try
        {
            emailService.SendEmail(emailRequest.ToAddress, emailRequest.Subject, emailRequest.Message);
            return Ok("Email sent successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error sending email: {ex.Message}");
        }
    }
}