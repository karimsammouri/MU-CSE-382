using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace FormulaStandings
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<RaceData.Root> GetRaceData()
        {
            RaceData.Root data = null;
            try
            {
                string uriRequest = "https://ergast.com/api/f1/current.json";
                var response = await _client.GetAsync(uriRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<RaceData.Root>(content);
                    Console.WriteLine("Race data loaded from server");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                try
                {
                    string content = await GetFileContents("races.json");
                    data = JsonConvert.DeserializeObject<RaceData.Root>(content);
                    Console.WriteLine("Race data failed to load from server, " +
                        "loaded from locally stored JSON data");
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine("\t\tERROR {0}", ex2.Message);
                }
            }
            return data;
        }

        public async Task<RaceResultsData.Root> GetRaceResultsData(string roundNumber)
        {
            RaceResultsData.Root data = null;
            try
            {
                string uriRequest =
                    String.Format("https://ergast.com/api/f1/current/{0}/results.json",
                    roundNumber);
                var response = await _client.GetAsync(uriRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<RaceResultsData.Root>(content);
                    Console.WriteLine("Race result data loaded from server");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                try
                {
                    string content = await GetFileContents("round" + roundNumber + ".json");
                    data = JsonConvert.DeserializeObject<RaceResultsData.Root>(content);
                    Console.WriteLine("Race result data failed to load from " +
                        "server, loaded from locally stored JSON data");
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine("\t\tERROR {0}", ex2.Message);
                }
            }
            return data;
        }

        public async Task<DriverData.Root> GetDriverData()
        {
            DriverData.Root data = null;
            try
            {
                string uriRequest = "https://ergast.com/api/f1/current/driverStandings.json";
                var response = await _client.GetAsync(uriRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DriverData.Root>(content);
                    Console.WriteLine("Driver data loaded from server");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                try
                {
                    string content = await GetFileContents("drivers.json");
                    data = JsonConvert.DeserializeObject<DriverData.Root>(content);
                    Console.WriteLine("Driver data failed to load from server, " +
                        "loaded from locally stored JSON data");
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine("\t\tERROR {0}", ex2.Message);
                }

            }
            return data;
        }

        public async Task<ConstructorData.Root> GetConstructorData()
        {
            ConstructorData.Root data = null;
            try
            {
                string uriRequest = "https://ergast.com/api/f1/current/constructorStandings.json";
                var response = await _client.GetAsync(uriRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ConstructorData.Root>(content);
                    Console.WriteLine("Constructor data loaded from server");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                try
                {
                    string content = await GetFileContents("constructors.json");
                    data = JsonConvert.DeserializeObject<ConstructorData.Root>(content);
                    Console.WriteLine("Constructor data failed to load from server, " +
                        "loaded from locally stored JSON data");
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine("\t\tERROR {0}", ex2.Message);
                }
            }
            return data;
        }

        public async Task<string> GetFileContents(string fname)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            string namespaceName = "FormulaStandings.JSONData";
            Stream stream = assembly.GetManifestResourceStream(namespaceName + "." + fname);
            string text = "";
            using (var dictReader = new StreamReader(stream))
            {
                text = await dictReader.ReadToEndAsync();
            }
            return text;
        }
    }
}

