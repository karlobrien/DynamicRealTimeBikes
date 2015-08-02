using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Common.Service.Tests
{
    public class MoqBikeService : IBikeService
    {
        public Task<IEnumerable<StationDto>> GetAllStationData()
        {
            return Task.FromResult(MoqStations());
        }

        private IEnumerable<StationDto> MoqStations()
        {
            StationDto one = new StationDto();
            one.Name = "Heuston";
            one.Number = 1;
            one.Address = "Heuston";
            one.Banking = true;
            one.Status = "Open";
            one.Bike_Stands = "20";
            one.Available_Bike_Stands = "10";
            one.Available_Bikes = "10";

            StationDto two = new StationDto();
            two.Name = "Smithfield";
            two.Number = 2;
            two.Address = "Smithfield";
            two.Banking = true;
            two.Status = "Open";
            two.Bike_Stands = "30";
            two.Available_Bike_Stands = "20";
            two.Available_Bikes = "10";

            return new List<StationDto> { one, two };
        }
    }
}
