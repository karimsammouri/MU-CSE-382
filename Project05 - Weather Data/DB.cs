using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using System.Reflection;
using System.Security.Cryptography;

namespace WeatherData
{
    public class DB
    {
        private static string DBName = "log.db";
        public static SQLiteConnection conn;
        public static Random rng = new Random(34);
        public static void OpenConnection()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, DBName);
            conn = new SQLiteConnection(fname);
            conn.CreateTable<WeatherInfo>();
            var data = conn.Table<WeatherInfo>();

            if (data.FirstOrDefault() == null)
            {
                PopulateDB();
            }
        }
        public static void PopulateDB()
        {
            for (int y = 2015; y <= 2021; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    for (int d = 1; d <= 31; d++)
                    {
                        DateTime date;
                        try
                        {
                            date = new DateTime(y, m, d);
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                        double temp = RandomTemperature(m, 1, 25.0, 8, 85.0, 12, 30.0, 0.10);

                        WeatherInfo data = new WeatherInfo
                        {
                            Date = date,
                            Temperature = temp
                        };

                        conn.Insert(data);
                    }
                }
            }
        }
        public static double RandomTemperature(int x, int xLo, double valAtLo,
                                                 int xMid, double valAtMid,
                                                 int xHi, double valAtHi,
                                                 double avgNoiseLevel)
        {
            int xLeft = x <= xMid ? xLo : xMid;
            int xRight = x <= xMid ? xMid : xHi;
            double yLeft = x <= xMid ? valAtLo : valAtMid;
            double yRight = x <= xMid ? valAtMid : valAtHi;

            int xDiff = x - xLeft;
            double yDiff = yRight - yLeft;
            int intervalWidth = xRight - xLeft;

            double value = xDiff / (double)intervalWidth * yDiff + yLeft;
            double noise = 2 * rng.NextDouble() * avgNoiseLevel;
            double returnValue = (1.0 + noise) * value;

            return returnValue;
        }
    }
}
