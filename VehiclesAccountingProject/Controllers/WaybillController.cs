using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs.WaybillViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace VehiclesAccountingProject.Controllers
{
    public class WaybillController : Controller
    {
        private readonly IWaybillService _waybillService;

        public WaybillController(IWaybillService waybillService)
        {
            this._waybillService = waybillService;
        }

        public IActionResult Index()
        {
            var waybills = _waybillService.GetWaybillDetailsDtos();
            return View(waybills);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddNewWaybillViewModel waybillViewModel = new AddNewWaybillViewModel()
            {
                RpSimpleModels = _waybillService.GetRPSimpleList(),
                EmployeeSimpleModels = _waybillService.GetEmployeeSimpleList(),
                VehicleSimplesModels = _waybillService.GetVehicleSimpleList(),
            };
           
            return View(waybillViewModel);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewWaybillViewModel waybillViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _waybillService.SaveAsync(waybillViewModel);
                if (result != null)
                {
                    RedirectToAction("Index", "Home");
                }
            }
            // edit
            waybillViewModel.EmployeeSimpleModels = _waybillService.GetEmployeeSimpleList();
            waybillViewModel.RpSimpleModels = _waybillService.GetRPSimpleList();
            waybillViewModel.VehicleSimplesModels= _waybillService.GetVehicleSimpleList();

            return View(waybillViewModel);
        }
    }
}
