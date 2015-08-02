using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Common.Service
{
    public interface IDataRequest
    {
        Task<List<T>> PollAsync<T>(string address, string query);
    }
}
