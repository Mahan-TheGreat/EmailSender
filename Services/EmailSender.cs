using EmailSender.Model;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender.Services;

public class EmailSenderService: IEmailSenderService
{
    public int SendEmail(EmailDetails emailDetails)
    {
        try
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender Name", emailDetails.sender));
            message.To.Add(new MailboxAddress("Recipient Name", emailDetails.receiver));
            message.Subject = emailDetails.subject;
            message.Body = new TextPart("plain")
            {
                Text = emailDetails.message
            };

            using(SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Authenticate(emailDetails.sender, emailDetails.password);
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }

            return 200;
        }
        catch(Exception ex)
        {
            return 400;
        }
    }

}
