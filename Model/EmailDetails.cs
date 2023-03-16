namespace EmailSender.Model;

public class EmailDetails
{
    public string sender { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string receiver { get; set; } = string.Empty;
    public string subject { get; set; } = string.Empty;
    public string message { get; set; } = string.Empty;
}
