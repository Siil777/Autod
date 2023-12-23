
using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Autod.Models.LandingPage;
using Microsoft.AspNetCore.Mvc;

namespace Autod.Controllers
{
    public class LandingPageController : Controller
    {

        private readonly AutoContext _autoContext;
        private readonly ILandingPageServices _landingPageServices;


        public LandingPageController
            (
                AutoContext autoContext,
                ILandingPageServices landingPageServices
            ) 
        { 
            _autoContext = autoContext;
            _landingPageServices = landingPageServices;

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

            return View(viewModel);
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


            };

            var result = await _landingPageServices.SaveCustomerdata(dto);

            if (result==null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index), vm);
        }
    }
}
