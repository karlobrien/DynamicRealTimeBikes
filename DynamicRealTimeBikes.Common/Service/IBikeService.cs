using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Common.Service
{
    public interface IBikeService
    {
        Task<IEnumerable<StationDto>> GetAllStationData();
    }
}
