using Autod.core.Domain;
using Autod.core.Dto;
using Autod.core.ServiceInterface;
using Autod.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.AplicationServices.Services
{
    public class LandingPageServices: ILandingPageServices
    {
        private readonly AutoContext _autoContext;


        public LandingPageServices
            (
            AutoContext autoContext
            ) 
        { 
            _autoContext = autoContext;
        }
        //Async method takes parameter of type LandingPage named dto
        public async Task<LandingPage> SaveCustomerdata(LandingPageDto dto)
        {
            //instance of the landingPage
            LandingPage landingPage = new LandingPage();

            //instance is populated with values from dto
            landingPage.Id = Guid.NewGuid();
            landingPage.FirstName = dto.FirstName;
            landingPage.LastName = dto.LastName;
            landingPage.Email = dto.Email;

            //instance added to LandingPages DbSet
            await _autoContext.LandingPages.AddAsync( landingPage );
            await _autoContext.SaveChangesAsync();

            return landingPage;

        }
    }
}
