
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


        public LandingPagesController
            (
                AutoContext autoContext,
                ILandingPageServices landingPageServices
,
                ICarService carServiceServices
            )
        {
            _autoContext = autoContext;
            _landingPageServices = landingPageServices;
            _carService = carServiceServices;
        }
        //Landing page initial form
        // based on space shop
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
        public async Task <IActionResult> SaveCustomerdata(LandingPageViewModel vm) 
        {
            var dto = new LandinPageDto
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                CreatedAt= DateTime.Now,


            };

            var result = await _landingPageServices.SaveCustomerdata(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(SaveCustomerRequest));
            }

            return RedirectToAction(nameof(SaveCustomerRequest), vm);

        }
        //Page where a customer leave precise data about car and service he needs
        [HttpGet]
        public IActionResult SaveCustomerRequest()
        {
            CarServiceViewModel carServiceView= new CarServiceViewModel();

            return View("SaveCustomerRequest", carServiceView);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCustomerRequest(CarServiceViewModel vm)
        {
            var dto = new CarServiceDto
            {
                Id = vm.Id,
                CarMake = vm.CarMake,
                TypeOfService=vm.TypeOfService,
                CustomerId = vm.CustomerId,
                CreatedAt=DateTime.Now,


               


            };
            var result = await _carService.SaveCustomerRequest(dto);

            if (result==null)
            {
                return RedirectToAction(nameof(SaveCustomerRequest));

            }

            return RedirectToAction(nameof(SaveCustomerRequest), vm);



        }
    }
}
