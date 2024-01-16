using Autod.Models.LandingPage;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Autod.Models.CarService
{
    public class CarServiceViewModel
    {
        [Display(Name = "Type of Service")]
        public string TypeOfService { get; set; }

        public List<SelectListItem> ServiceTypeOptions { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "bodyrepair", Text = "Body repair" },
        new SelectListItem { Value = "OilChange", Text = "Oil Change" },
        new SelectListItem { Value = "TireRotation", Text = "Tire Rotation" },
        new SelectListItem { Value = "BrakeService", Text = "Brake Service" },
        // Add more options as needed
    };
        public Guid Id { get; set; }
        public string CarMake { get; set; }

        public Guid? CustomerId { get; set; }


        public string SelectedTypeOfService { get; set; }

        public DateTime CreatedAt { get; set; }

        // List of available service types for the dropdown

        // Navigation property for the related Customer
        public virtual LandingPageViewModel Customer { get; set; }
    }
}
