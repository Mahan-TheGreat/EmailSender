using EmailSender.Model;
using EmailSender.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private IEmailSenderService _emailSenderService;
    public EmailController(IConfiguration configuration, IEmailSenderService emailSenderService)
    {
        _configuration = configuration;
        _emailSenderService = emailSenderService;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(EmailDto email)
    {
        EmailDetails emailDetails = new EmailDetails();
        emailDetails.sender = _configuration.GetValue<string>("EmailConfiguration:Sender");
        emailDetails.password = _configuration.GetValue<string>("EmailConfiguration:Password");
        emailDetails.receiver = email.receiver;
        emailDetails.subject = email.subject;
        emailDetails.message = email.message;

        var response = _emailSenderService.SendEmail(emailDetails);
        if(response == 200)
        {
            return Ok(new {message = "Email Sent Successfully!" });
        }
        else
        {
            return BadRequest();
        }
    }
}
