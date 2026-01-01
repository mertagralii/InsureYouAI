namespace InsureYouAI.Models;

public class RevenueExpenseChartViewModel
{
    public List<string> Months { get; set; }
    public List<decimal> RevenueTotals { get; set; }
    public List<decimal> ExpenceTotals { get; set; }
}