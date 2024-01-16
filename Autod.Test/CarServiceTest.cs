using Autod.Controllers;
using Autod.Core.Domain;
using Autod.Core.Dto;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Autod.Models.CarService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Autod.Test
{
    public class CarServiceTest: TestBase
    {
        //CarService controller
        [Fact]
        //test is checking whether, when we call the SaveCarMakeTypeService action on the CarServicesController 
        // with valid input CarServiceViewModel, the result is a redirect to another action RedirectToActionResult
        //and that the target action is CarServicesController.SaveCarMakeTypeService
        public async Task SaveCarMakeTypeService_ValidInput_ReturnsRedirectToAction()
        {
            // Arrange
            using var scope = serviceProvider.CreateScope();
            var autoContext = scope.ServiceProvider.GetRequiredService<AutoContext>();
            var carService = scope.ServiceProvider.GetRequiredService<ICarService>();
            var controller = new CarServicesController(autoContext, carService);
            var vm = new CarServiceViewModel
            {
                CarMake = "Tesla",
                TypeOfService = "Update OS already",
                CustomerId = Guid.NewGuid(),
            };
            // Act
            var result = await controller.SaveCarMakeTypeService(vm);
            // Assert
            //Success
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(CarServicesController.SaveCarMakeTypeService), ((RedirectToActionResult)result).ActionName);
            //lack of succes
            //Assert.IsNotType<RedirectToActionResult>(result);
            //Assert.NotEqual(nameof(CarServicesController.Index), ((RedirectToActionResult)result).ActionName);
        }
        [Fact]
        public async Task Should_UpdateCarServiceTable_WhenUpdateDataVersion()
        {
            CarServiceDto dto = MockCarsData();
            var createCar = await Svc<ICarService>().Create(dto);
            CarServiceDto Update = MockUpdateCarsData();
            var UpdateCar = await Svc<ICarService>().UpdateServicePage(Update);
            //error korda teha 
            Assert.DoesNotMatch(UpdateCar.CarMake, createCar.CarMake);
            Assert.NotEqual(UpdateCar.TypeOfService, createCar.TypeOfService);
            Assert.NotEqual(UpdateCar.CustomerId, createCar.CustomerId);
        }
        [Fact]
        public async Task Should_DeleteByIdCar()
        {
            //Arange
            CarServiceDto car = MockCarsData();
            //Act
            var addCar = await Svc<ICarService>().Create(car);
            var result = await Svc<ICarService>().DeleteTypeServicePage((Guid)addCar.Id);
            //Asert
            Assert.NotEqual(result, addCar);
        }
        [Fact]
        public async Task Should_FindCarById()
        {
            // Arrange
            CarServiceDto car = MockCarsData();

            // Act
            var addCar = await Svc<ICarService>().Create(car);
            var foundCar = await Svc<ICarService>().GetAsync((Guid)addCar.Id);

            // Assert
            Assert.NotNull(foundCar); 
            Assert.Equal(addCar.Id, foundCar.Id); 
        }
        private CarServiceDto MockCarsData()
        {
            CarServiceDto car = new()
            {
                CarMake = "Axes",
                TypeOfService = "TO",
                CustomerId = Guid.Parse("25816411-ae14-4763-8713-5dddba77aaf7"),
                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,
            };
            return car;
        }
        private CarServiceDto MockUpdateCarsData()
        {
            CarServiceDto car = new CarServiceDto()
            {
                CarMake = "Carriage",
                TypeOfService = "Body repair",
                CustomerId = Guid.Parse("358f41c4-e568-4f49-8493-98353f5f1b88"),
                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,
            };
            return car;
        }
    }
}

