using Autod.Core.Domain;
using Autod.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.Core.ServiceInterface
{
    public interface ILandingPageServices
    {
         Task<LandingPage> Create(LandinPageDto dto);

         Task<LandingPage> SavePrimaryDataPage(LandinPageDto dto);
        
         Task<LandingPage> DeletePrimaryDataPage(Guid id);
        
         Task<LandingPage> Update(LandinPageDto dto);
        
         Task<LandingPage> GetAsync(Guid id);

    }
}
