namespace Autod.Models.LandingPage
{
    public class CarService
    {
        public Guid Id { get; set; }
        public string CarMake { get; set; }
        public string TypeOfService { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } // Added CreatedAt property

        // Navigation property for the related Customer
        public virtual LandingPageViewModel Customer { get; set; }
    }
}
