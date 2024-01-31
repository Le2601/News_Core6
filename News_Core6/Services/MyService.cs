using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace News_Core6.Services
{
    public class MyService
    {
        private readonly IDistributedCache _cache;

        public MyService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public string GetData()
        {
            string data = _cache.GetString("myKey");

            if (data == null)
            {
                // Nếu không tìm thấy trong cache, lấy dữ liệu từ nguồn và đặt vào cache
                data = GetDataFromSource();
                _cache.SetString("myKey", data, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Cache trong 10 phút
                });
            }

            return data;
        }

        private string GetDataFromSource()
        {
            // Logic để lấy dữ liệu từ nguồn
            return "Data from source";
        }
    }
}
