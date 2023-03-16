using EmailSender.Model;

namespace EmailSender.Services;

public interface IEmailSenderService
{
    int SendEmail(EmailDetails emailDetails);
}
