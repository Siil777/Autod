using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.Core.Domain
{
    public class CarService
    {
        public Guid Id { get; set; }
        public string CarMake { get; set; }
        public string TypeOfService { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime Modifieted { get; set; }

        public virtual LandingPage Customer { get; set; }

    }
}
