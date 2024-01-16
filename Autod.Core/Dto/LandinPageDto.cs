using Autod.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.Core.Dto
{
    public class LandinPageDto
    {

        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime Modifieted { get; set; }

        public List<CarService> CarService { get; set; }
     
    }
}
