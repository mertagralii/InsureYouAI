namespace InsureYouAI.Entities;

public class PricinPlanItem
{
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid PricingPlanId { get; set; }
    public PricingPlan PricingPlan { get; set; }
    
}