using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.Core.Dto
{
    public class CarServiceDto
    {
        public Guid Id { get; set; }
        public string CarMake { get; set; }
        public string TypeOfService { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Modifieted { get; set; }
        public virtual LandinPageDto Customer { get; set; }
    }

}
