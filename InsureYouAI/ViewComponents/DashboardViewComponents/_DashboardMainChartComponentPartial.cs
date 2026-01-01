using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardMainChartComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _DashboardMainChartComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        //Revenue
        var revenueData = _context.Revenue.GroupBy(r => r.ProcessDate.Month).Select(g => new
        {
            Month = g.Key,
            Total = g.Sum(r => r.Amount)
        }).OrderBy(x=>x.Month).ToList();
        
        //Expense
        var expenseData = _context.Expenses.GroupBy(r => r.ProcessDate.Month).Select(g => new
        {
            Month = g.Key,
            Total = g.Sum(r => r.Amount)
        }).OrderBy(x=>x.Month).ToList();
        
        var allMonths = revenueData.Select(x=> x.Month)
            .Union(expenseData.Select(x=> x.Month))
            .OrderBy(x=>x)
            .ToList();
        
        var model = new RevenueExpenseChartViewModel()
        {
            Months = allMonths.Select(d =>
                System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d)).ToList(),
            RevenueTotals = allMonths.Select(m=>
                revenueData.FirstOrDefault(r=>r.Month == m)?.Total ?? 0).ToList(),
            ExpenceTotals = allMonths.Select(m=>
                expenseData.FirstOrDefault(r=>r.Month == m)?.Total ?? 0).ToList()
        };
        ViewBag.v1 = _context.Revenue.Sum(r => r.Amount);
        ViewBag.v2 = _context.Expenses.Sum(e => e.Amount);
        
        return View(model);
    }
    
}