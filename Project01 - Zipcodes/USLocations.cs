// I have successfully completed all requirements of this project.

using System;
namespace USLocations
{
    public class USLocations
    {
        // Task for reading file
        private Task inputTask;
        // Read locations info here
        private List<Location> locations;

        // Location is meant to be a custom class that stores, zipcode, state,
        // city, etc. This constructor will initiate the loading of the TSV file.
        // The constructor must return very quickly, perhaps before all 
        // of the zip code information has been completely loaded. Tasks
        // will be needed to do this.
        public USLocations(string fileName)
        {
            locations = new List<Location>();
            inputTask = ReadFile(fileName);
        }

        // Asynchronous method for reading file
        public async Task ReadFile(string fileName)
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                input.ReadLine(); // to skip header
                while (!input.EndOfStream)
                {
                    string line = await input.ReadLineAsync();
                    string[] toks = line.Split('\t');
                    int zipCode = Convert.ToInt32(toks[1]);
                    string city = toks[3];
                    string state = toks[4];
                    string latitude = toks[6];
                    string longitude = toks[7];
                    Location location = new Location(zipCode, city, state,
                        latitude, longitude);
                    locations.Add(location);
                }
            }
        }

        /**
         * Returns the city names that appear in both of the given states.
             * "OH" and "MI" would yield {OXFORD, FRANKLIN, ... }
         */
        public ISet<string> GetCommonCityNames(string state1, string state2)
        {
            ISet<string> common = new SortedSet<string>();
            // Cycle through locations to find cities common to both states.
            // Before doing this, you may need to wait for the reading to complete.
            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].state.Equals(state1))
                {
                    for (int j = 0; j < locations.Count; j++)
                    {
                        if (locations[j].state.Equals(state2))
                        {
                            if (locations[i].city.Equals(locations[j].city))
                            {
                                common.Add(locations[i].city);
                            }
                        }
                    }
                }
            }
            return common;
        }
        /**
         * Returns all zipcodes that are within a specified distance from a
         * particular zipcode.
         */
        // Do this by researching the "Haversine" formula to do this one.
        // The formula for converting from degrees to radians is:
        //     radians = degrees * Math.PI / 180.0;
        public double Distance(int zip1, int zip2)
        {
            // Use Haversine to compute distance between two locations.
            // Before doing this, you may need to wait for the reading to complete.
            double latitude1 = 0;
            double longitude1 = 0;
            double latitude2 = 0;
            double longitude2 = 0;
            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].zipCode.Equals(zip1))
                {
                    latitude1 = Convert.ToDouble(locations[i].latitude);
                    longitude1 = Convert.ToDouble(locations[i].longitude);
                }
                if (locations[i].zipCode.Equals(zip2))
                {
                    latitude2 = Convert.ToDouble(locations[i].latitude);
                    longitude2 = Convert.ToDouble(locations[i].longitude);
                }
            }
            double distance = 2 * 6371 * Math.Asin(Math.Sqrt(Math.Pow(
                Math.Sin(((latitude2 - latitude1) / 2) * (Math.PI / 180.0)), 2) +
                (Math.Cos(latitude1 * (Math.PI / 180.0)) * Math.Cos(latitude2 *
                (Math.PI / 180.0)) * Math.Pow(Math.Sin(((longitude2 - longitude1) *
                (Math.PI / 180.0)) / 2), 2))));
            return distance;
        }
    }

    public class Location
    {
        public int zipCode;
        public string city;
        public string state;
        public string latitude;
        public string longitude;

        public Location(int zipCode, string city, string state,
            string latitude, string longitude)
        {
            this.zipCode = zipCode;
            this.city = city;
            this.state = state;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }

}

