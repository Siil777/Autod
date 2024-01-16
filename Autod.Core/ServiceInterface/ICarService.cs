using Autod.Core.Domain;
using Autod.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<CarService> SaveCarMakeTypeService(CarServiceDto dto);

        Task<CarService> UpdateServicePage(CarServiceDto dto);

        Task<CarService> Create(CarServiceDto dto);

        Task<CarService> DeleteTypeServicePage(Guid id);

        Task<CarService> GetAsync(Guid id);
    }
}
