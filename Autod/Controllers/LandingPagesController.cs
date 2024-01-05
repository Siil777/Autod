
using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Autod.Models.LandingPage;
using Microsoft.AspNetCore.Mvc;

namespace Autod.Controllers
{
    public class LandingPagesController : Controller
    {
        private readonly AutoContext _autoContext;
        private readonly ILandingPageServices _landingPageServices;
        private readonly ICarService _carService;

        public LandingPagesController(AutoContext autoContext, ILandingPageServices landingPageServices, ICarService carService)
        {
            _autoContext = autoContext;
            _landingPageServices = landingPageServices;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var result = _autoContext.LandingPages
                .Select(x => new LandingPageViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult SaveCustomerdata()
        {
            LandingPageViewModel viewModel = new LandingPageViewModel();

            return View("SaveCustomerdata", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomerdata(LandingPageViewModel vm)
        {
            var dto = new LandinPageDto
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                CreatedAt = DateTime.Now,
            };

            var result = await _landingPageServices.SaveCustomerdata(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(SaveCustomerRequest));
            }

            // Redirect 
            return RedirectToAction(nameof(SaveCustomerRequest));
        }

        [HttpGet]
        public IActionResult SaveCustomerRequest()
        {
            CarServiceViewModel carServiceView = new CarServiceViewModel();

            return View("SaveCustomerRequest", carServiceView);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomerRequest(CarServiceViewModel vm)
        {
            // Create 
            var dto = new CarServiceDto
            {
                CarMake = vm.CarMake,
                TypeOfService = vm.TypeOfService,
                CreatedAt = DateTime.Now,
            };

            // Retrieve the LandingPage entity from the database based on the provided CustomerId
            var landingPage = await _autoContext.LandingPages.FindAsync(vm.CustomerId);

            if (landingPage == null)
            {
                // Handle the case where the LandingPage with the provided CustomerId is not found
                return RedirectToAction(nameof(SaveCustomerRequest));
            }

            // Set the CustomerId in CarServiceDto to the Id of the LandingPage
            dto.CustomerId = landingPage.Id;

            var result = await _carService.SaveCustomerRequest(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(SaveCustomerRequest));
            }

            // Redirect 
            return RedirectToAction(nameof(SaveCustomerRequest));
        }

    }
}

