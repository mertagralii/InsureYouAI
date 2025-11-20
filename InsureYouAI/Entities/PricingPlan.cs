namespace InsureYouAI.Entities;

public class PricingPlan
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public bool IsFeature { get; set; }
}