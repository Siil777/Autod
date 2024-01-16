using Autod.Models.CarService;

namespace Autod.Models.LandingPage
{
    public class LandingPageViewModel
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<CarServiceViewModel> CarServices { get; set; }




    }
}
