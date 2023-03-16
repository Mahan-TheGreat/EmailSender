namespace EmailSender.Model;

public class EmailDto
{
    public string receiver { get; set; } = string.Empty;
    public string subject { get; set; } = string.Empty;
    public string message { get; set; } = string.Empty;
}
