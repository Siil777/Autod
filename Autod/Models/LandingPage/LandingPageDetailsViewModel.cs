namespace Autod.Models.LandingPage
{
    public class LandingPageDetailsViewModel
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Modifieted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
