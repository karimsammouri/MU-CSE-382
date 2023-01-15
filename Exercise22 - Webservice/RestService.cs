using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TimeZone
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<TimeZone> GetTimeZoneData(string query)
        {
            TimeZone data = null;

            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pass 2");
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<TimeZone>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return data;
        }
    }
}

