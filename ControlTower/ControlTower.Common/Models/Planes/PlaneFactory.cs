using ControlTower.Common.Models;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Common.Models.Planes
{
    public static class PlaneFactory
    {
        static string[] planeModels = new string[]
          {
              "Boeing 787 Dreamliner","Boeing 777-200","Boeing 737-800","Boeing 747-400","Boeing 777-300","Airbus A320","Airbus A350","Airbus A333-300", "Airbus A340-300", "Airbus A340-500","Airbus A380-800",
          };
        public static IPlane CreatePlane<T>() where T : IPlane, new()
        {
            var plane = new T();
            plane.FlightNumber = GenerateFlightNumber();
            plane.Model = GetPlaneModel();
            plane.IsLoaded = false;
            plane.HasMaintained = false;
            plane.Departured = false;
            return plane;
        }
        private static string GenerateFlightNumber()
        {
            StringBuilder builder = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 2; i++)
            {
                char c = (char)rnd.Next('A', 'Z');
                builder.Append(c);
            }
            var number = rnd.Next(1000, 9999);

            builder.Append(number);
            return builder.ToString();
        }
        public static int GetRandomNumber(int num1, int num2)
        {
            Random rnd = new Random();
            int answer;
            if (num1 < num2)
                answer = rnd.Next(num1, num2);
            else
                answer = rnd.Next(num2, num1);
            return answer;
        }
        private static string GetPlaneModel()
        {
            Random rnd = new Random();
            var index = rnd.Next(0, planeModels.Length - 1);
           return planeModels[index];
        }

    }
}
