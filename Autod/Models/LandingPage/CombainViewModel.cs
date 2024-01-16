using Autod.Models.CarService;

namespace Autod.Models.LandingPage
{
    public class CombainViewModel
    {
        public IEnumerable<LandingPageViewModel> LandingPageData { get; set; }
        public IEnumerable<CarServiceViewModel> CarServiceData { get; set; }
    }
}
