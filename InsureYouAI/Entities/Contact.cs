namespace InsureYouAI.Entities;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}