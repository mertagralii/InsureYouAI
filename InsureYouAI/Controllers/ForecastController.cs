using InsureYouAI.Context;
using InsureYouAI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class ForecastController : Controller
    {
        private readonly InsureContext _context;
        private readonly ForecastService _forecastService;

        public ForecastController(InsureContext context)
        {
            _context = context;
            _forecastService = new ForecastService();
        }
        public ActionResult Index()
        {
            var salesData = _context.Policies
                .GroupBy(p=>new {p.StartDate.Year, p.StartDate.Month})
                .Select(ps => new 
                {
                    Year = ps.Key.Year, 
                    Mount = ps.Key.Month,
                    Count = ps.Count()
                })
                .AsEnumerable()
                .Select(ps => new PolicySalesData
                {
                    Date = new DateTime(ps.Year, ps.Mount, 1),
                    SaleCount = ps.Count
                })
                .OrderBy(ps => ps.Date)
                .ToList();
            var forecast = _forecastService.GetForecast(salesData,3);
            ViewBag.Forecast = forecast;
            return View(salesData);
        }

    }
}
