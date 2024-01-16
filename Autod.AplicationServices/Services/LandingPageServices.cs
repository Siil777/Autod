using Autod.Core.Domain;
using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<LandingPage> Create(LandinPageDto dto)
        {
            LandingPage customerPrimaryData = new LandingPage();
            customerPrimaryData.Id = Guid.NewGuid();
            customerPrimaryData.FirstName = dto.FirstName;
            customerPrimaryData.LastName = dto.LastName;
            customerPrimaryData.Email = dto.Email;
            customerPrimaryData.CreatedAt = DateTime.Now;
            customerPrimaryData.Modifieted = DateTime.Now;
            await _autoContext.LandingPages.AddAsync(customerPrimaryData);
            await _autoContext.SaveChangesAsync();
            return customerPrimaryData;
        }

        public async Task<LandingPage> SavePrimaryDataPage(LandinPageDto dto)
        {
            LandingPage landingPage = new LandingPage();

            landingPage.Id = Guid.NewGuid();
            landingPage.FirstName = dto.FirstName;
            landingPage.LastName = dto.LastName;
            landingPage.Email = dto.Email;
            landingPage.CreatedAt = DateTime.Now;
            landingPage.Modifieted = DateTime.Now;

            await _autoContext.LandingPages.AddAsync(landingPage);
            await _autoContext.SaveChangesAsync();
            return landingPage;
        }
        //Method to delete primary data 
        public async Task<LandingPage> DeletePrimaryDataPage(Guid id)
        {
            var CustomerId = await _autoContext.LandingPages
                .FirstOrDefaultAsync(x => x.Id == id);
            _autoContext.LandingPages.Remove(CustomerId);
            await _autoContext.SaveChangesAsync();
            return CustomerId;
        }
        //Update primary data
        public async Task<LandingPage> Update(LandinPageDto dto)
        {
            var customaData = new LandingPage()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedAt = dto.CreatedAt,
                Modifieted = DateTime.Now,


            };
            _autoContext.LandingPages.Update(customaData);
            await _autoContext.SaveChangesAsync();
            return customaData;
        }
      
        //Details
        public async Task<LandingPage> GetAsync(Guid id)
        {
            var result = await _autoContext.LandingPages
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}

