using Autod.Core.Domain;
using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Autod.Models.CarService;
using Autod.Models.LandingPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        //Combain two models to display two tables on one Index.
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
                    Id=x.Id,
                    CarMake=x.CarMake,
                    CustomerId=x.CustomerId,
                    SelectedTypeOfService=x.TypeOfService
                });

            var combinedViewModel = new CombainViewModel
            {
                LandingPageData = landingPageData,
                CarServiceData = carServiceData,
            };

            return View(combinedViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsPrimaryDataPage(Guid id)
        {
            var landingPage = await _landingPageServices.GetAsync(id);

            if (landingPage == null)
            {
                return NotFound();
            }

            var vm = new LandingPageDetailsViewModel
            {
                Id = landingPage.Id,
                FirstName = landingPage.FirstName,
                LastName = landingPage.LastName,
                Email = landingPage.Email,
                CreatedAt = landingPage.CreatedAt,
                Modifieted=landingPage.Modifieted,
            };

            return View(vm);
        }
        [HttpGet]
        public IActionResult SavePrimaryDataPage()
        {
            LandingPageViewModel viewModel = new LandingPageViewModel();

            return View("SavePrimaryDataPage", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePrimaryDataPage(Guid id)
        {
            var customer = await _landingPageServices.DeletePrimaryDataPage(id);
            if (customer == null)
            {
                return NotFound();
            }


            var vm = new LandingPageDeleteViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                CreatedAt = customer.CreatedAt,
                Modifieted = customer.Modifieted,


            };

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SavePrimaryDataPage(LandingPageViewModel vm)
        {
            var dto = new LandinPageDto
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                CreatedAt = DateTime.Now,
            };

            var result = await _landingPageServices.SavePrimaryDataPage(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }


            return RedirectToAction("SaveCarMakeTypeService", "CarServices", new { id = result.Id });
        }
        [HttpGet]
        public IActionResult CreatePrimary()
        {
            LandingPagesCreateUpdateViewModel viewModel = new LandingPagesCreateUpdateViewModel();

            return View("CreatePrimary", viewModel);
        }
        [HttpPost]
        //Create primary data. Page primary data
        public async Task<IActionResult> CreatePrimary(LandingPagesCreateUpdateViewModel vm)
        {
            var dto = new LandinPageDto
            {
                Id= vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                CreatedAt = vm.CreatedAt,
                Modifieted = DateTime.Now,
            };

            var result = await _landingPageServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }


            //return RedirectToAction("SaveCarMakeTypeService", "CarServices", new { id = result.Id });

            return RedirectToAction(nameof(Index));
        }
        //Update primary data
        [HttpGet]
        public async Task<IActionResult> UpdatePrimaryData(Guid id)
        {
            var customerData = await _landingPageServices.GetAsync(id);

            if (customerData == null)
            {
                return NotFound();
            }

            var vm = new LandingPagesCreateUpdateViewModel
            {
                Id= customerData.Id,
                FirstName = customerData.FirstName,
                LastName = customerData.LastName,
                Email = customerData.Email,
                CreatedAt = customerData.CreatedAt,
                Modifieted = customerData.Modifieted
            };

            return View("UpdatePrimaryData", vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrimaryData(LandingPagesCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdatePrimaryData", vm);
            }

            var customerBaseData = new LandinPageDto
            {
                Id= vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                CreatedAt = vm.CreatedAt,
                Modifieted = DateTime.Now
            };

            await _landingPageServices.Update(customerBaseData);
            return RedirectToAction(nameof(Index), vm);
        }


    }



}

