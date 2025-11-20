namespace InsureYouAI.Entities;

public class Message
{
    public Guid Id { get; set; }
    public string NameSurname{ get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string MessageDetail { get; set; }
    public DateTime SendDate { get; set; }
    public bool IsRead { get; set; }
}