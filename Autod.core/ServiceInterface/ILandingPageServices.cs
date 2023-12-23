using Autod.core.Domain;
using Autod.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.core.ServiceInterface
{
    public interface ILandingPageServices
    {
        Task<LandingPage> SaveCustomerdata(LandingPageDto dto);
        
    }
}
