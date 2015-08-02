using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DynamicRealTimeBikes.Common.Service
{
    public class DataRequest : IDataRequest
    {

        public async Task<List<T>> PollAsync<T>(string address, string query)
        {
            var results = new List<T>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsAsync<List<T>>();
                }
                return results;
            }
        }
    }
}
