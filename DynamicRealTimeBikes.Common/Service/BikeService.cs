using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Common.Service
{
    public class BikeService : IBikeService
    {
        private IDataRequest _dataRequest;
        private ApiFormat _apiFormat;

        public BikeService(IDataRequest dataRequest)
        {
            _dataRequest = dataRequest;

            var file = File.ReadAllText(@"C:\Temp\Config.json");
            _apiFormat = JsonConvert.DeserializeObject<ApiFormat>(file);
        }

        public async Task<IEnumerable<StationDto>> GetAllStationData()
        {
            var apiKey = _apiFormat.ApiKey;
            var apiAddress = _apiFormat.Address;
            var query = String.Format("?contract=dublin&apiKey={0}", apiKey);
            
            var stationData = await _dataRequest.PollAsync<StationDto>(_apiFormat.Address, query);
            return stationData;
        }
    }
}
