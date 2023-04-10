using Core.DTOs;
using Core.DTOs.VehicleViewModels;
using Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace VehiclesAccountingProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService service)
        {
            this.vehicleService = service;
        }
        // GET: VehicleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
           var selectedVehicle = vehicleService.GetVehicleDetailsDto(id);
            return View(selectedVehicle);
        }

        // GET: VehicleController/Create
        [HttpGet]
        [Authorize(Roles = "Админ")]
        public ActionResult Create()
        {
            AddNewVehicleViewModel viewModel = new AddNewVehicleViewModel()
            {
                PetrolModels = vehicleService.GetPetrolList(),
                EmployeeSimpleModels = vehicleService.GetEmployeeSimpleList(),
            };

            return View(viewModel);
        }

        // POST: VehicleController/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        [Authorize(Roles = "Админ")]
        public async Task<ActionResult> Create(AddNewVehicleViewModel vehicleModel, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var result = await vehicleService.SaveAsync(vehicleModel);
                if (result != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
