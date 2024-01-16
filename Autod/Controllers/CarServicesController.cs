using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Autod.Models.CarService;
using Autod.Models.LandingPage;
using Microsoft.AspNetCore.Mvc;

namespace Autod.Controllers
{
    public class CarServicesController : Controller
    {
        private readonly AutoContext _autoContext;
        private readonly ICarService _carService;
        public CarServicesController(AutoContext autoContext, ICarService carService)
        {
            _autoContext = autoContext;
            _carService = carService;
        }
        public IActionResult Index()
        {
            var landingPageData = _autoContext.LandingPages
                .Select(x => new LandingPageViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                });
            var carServiceData = _autoContext.CarServices
                .Select(x => new CarServiceViewModel
                {
                    Id = x.Id,
                    CarMake = x.CarMake,
                    CustomerId = x.CustomerId,
                    SelectedTypeOfService = x.TypeOfService
                });
            var combinedViewModel = new CombainViewModel
            {
                LandingPageData = landingPageData,
                CarServiceData = carServiceData,
            };
            return View(combinedViewModel);
        }
        // Page where a customer input car make and type of service 
        [HttpGet]
        public async Task<IActionResult> DetailsCarMakeTypeService(Guid id)
        {
            var CarService = await _carService.GetAsync(id);
            if (CarService == null)
            {
                return NotFound();
            }
            var vm = new CarServiceDetailsViewModel
            {
                Id = CarService.Id,
                CarMake = CarService.CarMake,
                CustomerId = CarService.CustomerId,
                SelectedTypeOfService = CarService.TypeOfService,
                CreatedAt = CarService.CreatedAt,
                Modifieted= CarService.Modifieted,
            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult SaveCarMakeTypeService(Guid id)
        {

            CarServiceViewModel carServiceView = new CarServiceViewModel { CustomerId = id };

            return View("SaveCarMakeTypeService", carServiceView);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCarMakeTypeService(CarServiceViewModel vm)
        {
            // Create a new CarServiceDto
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
                return RedirectToAction(nameof(SaveCarMakeTypeService));
            }
            // Set the CustomerId in CarServiceDto to the Id of the LandingPage
            dto.CustomerId = landingPage.Id;
            var result = await _carService.SaveCarMakeTypeService(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(SaveCarMakeTypeService));
            }
            // Redirect to the SaveCustomerRequest action in this controller
            return RedirectToAction(nameof(SaveCarMakeTypeService));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTypeServicePage(Guid id)
        {
            var CarService = await _carService.DeleteTypeServicePage(id);
            if (CarService == null)
            {
                return NotFound();
            }
            var vm = new CarServiceDeleteViewModel
            {
                Id = CarService.Id,
                CarMake = CarService.CarMake,
                CustomerId = CarService.CustomerId,
                SelectedTypeOfService = CarService.TypeOfService,
                CreatedAt = CarService.CreatedAt,
                Modifieted= CarService.Modifieted,


            };
          return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateTypeOfService()
        {
            CarServiceCreateUpdateViewModel viewModel = new CarServiceCreateUpdateViewModel();

            return View("CreateTypeOfService", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeOfService(CarServiceCreateUpdateViewModel vm)
        {

            var dto = new CarServiceDto
            {
                CarMake = vm.CarMake,
                TypeOfService = vm.TypeOfService,
                CreatedAt = DateTime.Now,
            };

            try
            {
                // Retrieve the last inserted LandingPages record's Id
                var lastLandingPageId = _autoContext.LandingPages.OrderByDescending(lp => lp.CreatedAt).FirstOrDefault()?.Id;

                if (lastLandingPageId != null)
                {
                    // Set the CustomerId in CarServiceDto to the last inserted LandingPages record's Id
                    dto.CustomerId = lastLandingPageId.Value;

                    // Create the CarService record
                    var result = await _carService.Create(dto);

                    if (result == null)
                    {

                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {

                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating CarService: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateServicePage(Guid id)
        {
            var customerData = await _carService.GetAsync(id);

            if (customerData == null)
            {
                return NotFound();

            }
            var vm = new CarServiceCreateUpdateViewModel();
            vm.Id= customerData.Id;
            vm.CarMake = customerData.CarMake;
            vm.SelectedTypeOfService = customerData.TypeOfService;
            vm.CustomerId = customerData.CustomerId;
            vm.CreatedAt = customerData.CreatedAt;
            vm.Modifieted = DateTime.Now;


            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateServicePage(CarServiceCreateUpdateViewModel vm)
        {
            var CarService = new CarServiceDto()
            {
                Id= vm.Id,
                CarMake= vm.CarMake,
                TypeOfService=vm.SelectedTypeOfService,
                CustomerId=vm.CustomerId,
                CreatedAt=vm.CreatedAt,
                Modifieted=DateTime.Now,

            };
         



        
            var result = await _carService.UpdateServicePage(CarService);
            if (result == null)
            {
                return RedirectToAction(nameof(Index), vm);

            }
            return RedirectToAction(nameof(Index), vm);
        }

    }
}
