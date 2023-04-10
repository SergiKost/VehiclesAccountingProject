using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace VehiclesAccountingProject.Controllers
{
    public class RefuelingPriceController : Controller
    {
        private readonly IRefuelingPriceService _refuelingPriceService;

        public RefuelingPriceController(IRefuelingPriceService refuelingPriceService)
        {
            _refuelingPriceService = refuelingPriceService;
        }

        public IActionResult Index()
        {
            var prices = _refuelingPriceService.GetRefuelingPriceDtos();
            return View(prices);
        }
    }
}
