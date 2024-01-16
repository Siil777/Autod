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
    public class CarServiceServices : ICarService
    {
        private readonly AutoContext _autoContext;

        public CarServiceServices(AutoContext autoContext)
        {
            _autoContext = autoContext;
        }
        public async Task<CarService> Create(CarServiceDto dto)
        {
            CarService carService = new CarService();
            carService.Id = Guid.NewGuid();
            carService.CarMake = dto.CarMake;
            carService.TypeOfService = dto.TypeOfService;
            carService.CustomerId = dto.CustomerId;
            carService.CreatedAt = DateTime.Now;
            carService.Modifieted = DateTime.Now;
            await _autoContext.CarServices.AddAsync(carService);
            await _autoContext.SaveChangesAsync();
            return carService;
        }

        public async Task<CarService> SaveCarMakeTypeService(CarServiceDto dto)
        {
            CarService carService = new CarService();
            carService.Id = Guid.NewGuid();
            carService.CarMake = dto.CarMake;
            carService.TypeOfService = dto.TypeOfService;
            carService.CustomerId = dto.CustomerId;
            carService.CreatedAt = DateTime.Now;
            carService.Modifieted = DateTime.Now;
            await _autoContext.CarServices.AddAsync(carService);
            await _autoContext.SaveChangesAsync();
            return carService;
        }
        //Update type of service and car make
        public async Task<CarService> UpdateServicePage(CarServiceDto dto)
        {
            var carMakeTypeOfService = new CarService();
            {
                carMakeTypeOfService.Id = dto.Id;
                carMakeTypeOfService.CarMake = dto.CarMake;
                carMakeTypeOfService.TypeOfService = dto.TypeOfService;
                carMakeTypeOfService.CustomerId = dto.CustomerId;
                carMakeTypeOfService.CreatedAt = dto.CreatedAt;
                carMakeTypeOfService.Modifieted = DateTime.Now;
                _autoContext.CarServices.Update(carMakeTypeOfService);
                await _autoContext.SaveChangesAsync();
                return carMakeTypeOfService;

            }
         
        }
        //Method to delete CarMake and Type of Service
        public async Task<CarService> DeleteTypeServicePage(Guid id)
        {
            var CarId = await _autoContext.CarServices
                .FirstOrDefaultAsync(x => x.Id == id);
            _autoContext.CarServices.Remove(CarId);
            await _autoContext.SaveChangesAsync();
            return CarId;
        }
        //Get Details and Update by id
        public async Task<CarService> GetAsync(Guid id)
        {
            var result = await _autoContext.CarServices
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}

