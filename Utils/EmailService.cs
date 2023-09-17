using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly string _fromName;
    private readonly string _fromAddress;
    private readonly string _connectionAddress;
    private readonly string _connectionPort;
    private readonly string _authEmail;
    private readonly string _authPassword;

    public EmailService(IConfiguration configuration)
    {
        _fromName = configuration.GetSection("SMTPSettings:MailBoxAdress:FromName").Value ?? "";
        _fromAddress = configuration.GetSection("SMTPSettings:MailBoxAdress:FromAddress").Value ?? "";
        _connectionAddress = configuration.GetSection("SMTPSettings:SMTPConection:ConnectionAddress").Value ?? "";
        _connectionPort = configuration.GetSection("SMTPSettings:SMTPConection:ConnectionPort").Value ?? "";
        _authEmail = configuration.GetSection("SMTPSettings:SMTPAuthentication:AuthEmail").Value ?? "";
        _authPassword = configuration.GetSection("SMTPSettings:SMTPAuthentication:AuthPassword").Value ?? "";
    }
    public void SendEmail(string toAddress, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_fromName, _fromAddress));
        message.To.Add(new MailboxAddress("Receiver", toAddress));
        message.Subject = subject;

        var builder = new BodyBuilder();
        builder.TextBody = body;
        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect(_connectionAddress, int.Parse(_connectionPort), false);
            client.Authenticate(_authEmail, _authPassword);
            client.Send(message);
            client.Disconnect(true);
        }
    }

}