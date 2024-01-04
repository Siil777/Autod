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
    public class CarServiceServices : ICarService
    {
        private readonly AutoContext _autoContext;

        public CarServiceServices
            (
                 AutoContext autoContext
            )
        {
            _autoContext = autoContext;
        }

        public async Task<CarService> SaveCustomerRequest(CarServiceDto dto)
        {
            CarService carService= new CarService();

            carService.Id = Guid.NewGuid();
            carService.CarMake = dto.CarMake;
            carService.TypeOfService= dto.TypeOfService;
            carService.CustomerId = dto.CustomerId;
            carService.CreatedAt= DateTime.Now;


            await _autoContext.AddRangeAsync(carService);
            await _autoContext.SaveChangesAsync();

            return carService;

        }
    }
}
