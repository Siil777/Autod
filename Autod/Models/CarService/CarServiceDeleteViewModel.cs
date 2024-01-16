namespace Autod.Models.CarService
{
    public class CarServiceDeleteViewModel
    {
        public Guid Id { get; set; }
        public string CarMake { get; set; }

        public Guid? CustomerId { get; set; }
        public string SelectedTypeOfService { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime Modifieted { get; set; }
    }
}
