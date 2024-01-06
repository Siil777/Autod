using Autod.Core.Domain;
using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.AplicationServices.Services
{
    public class LandingPageServices : ILandingPageServices
    {
        private readonly AutoContext _autoContext;
        private readonly ICarService _carService;

        public LandingPageServices(AutoContext autoContext, ICarService carService)
        {
            _autoContext = autoContext;
            _carService = carService;
        }

        public async Task<LandingPage> SaveCustomerdata(LandinPageDto dto)
        {
            LandingPage landingPage = new LandingPage();

            landingPage.Id = Guid.NewGuid();
            landingPage.FirstName = dto.FirstName;
            landingPage.LastName = dto.LastName;
            landingPage.Email = dto.Email;
            landingPage.CreatedAt = DateTime.Now;

            await _autoContext.LandingPages.AddAsync(landingPage);
            await _autoContext.SaveChangesAsync();

            return landingPage;
        }


    }
}

