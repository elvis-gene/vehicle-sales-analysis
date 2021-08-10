using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using VehicleSalesAnalysis.Helpers;
using VehicleSalesAnalysis.Models;

namespace VehicleSalesAnalysis.Services
{
    public class VehicleSalesAnalysisService : IVehicleSalesAnalysisService
    {
        private const string JsonFileName = "sales.json";
        private readonly string _filePath;
        
        public VehicleSalesAnalysisService()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, "Data", JsonFileName);
        }
        
        public IEnumerable<Vehicle> GetVehicles()
        {
            using var jsonFileReader = File.OpenText(_filePath);
            return JsonSerializer.Deserialize<Vehicle[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public Dictionary<string, int> GetNumberOfCarsSoldPerModel(int startYear, int endYear)
        {
            if (!ServicesHelper.AreValidYears(startYear, endYear))
                throw new ArgumentException("Check that the year values input are correct");
            
            // To pair each vehicle model with its total
            var carsSoldPerModel = new Dictionary<string, int>();

            foreach (var vehicle in GetVehicles().ToList())
            {
                var vehiclesSold = ServicesHelper.GetNumberOfVehiclesSold(vehicle.Sales.ToList(), startYear, endYear);
                
                carsSoldPerModel.Add(vehicle.Model, vehiclesSold);
            }
            
            return carsSoldPerModel;
        }

        public Dictionary<string, int> GetNumberOfCarsSoldPerManufacturer(int startYear, int endYear)
        {
            if (!ServicesHelper.AreValidYears(startYear, endYear))
                throw new ArgumentException("Check that the year values input are correct");
            
            // Use dictionary (manufacturer - total key-value pair).
            // If the manufacturer is already in the map, add value corresponding to that key (manufacturer)
            // , otherwise create new key - pair

            var carsSoldPerManufacturer = new Dictionary<string, int>();
            
            foreach (var vehicle in GetVehicles().ToList())
            {
                var vehiclesSold = ServicesHelper.GetNumberOfVehiclesSold(vehicle.Sales.ToList(), startYear, endYear);

                var key = vehicle.Manufacturer;
                
                if (carsSoldPerManufacturer.ContainsKey(key))
                {
                    carsSoldPerManufacturer[key] += vehiclesSold;
                }
                else
                {
                    carsSoldPerManufacturer[key] = vehiclesSold;
                }
            }

            return carsSoldPerManufacturer;
        }
        
        public int SumOfAveragesOfNumVehiclesSoldPerManufacturer(int startYear, int endYear)
        {
            // Get total number of cars sold per manufacturer
            var carsSoldPerManufacturer = GetNumberOfCarsSoldPerManufacturer(startYear, endYear);
            
            var numberOfYears = (endYear - startYear) + 1;
            
            // Calculate average number of cars sold between (both inclusive) startYear & endYear for each manufacturer
            // and add all the averages up.
            var sum = carsSoldPerManufacturer.Values.Sum(value => value / numberOfYears);

            return sum;
        }

        public string MostCommonVehicleColourSold(int startYear, int endYear)
        {
            if (!ServicesHelper.AreValidYears(startYear, endYear))
                throw new ArgumentException("Check that the year values input are correct");
            
            var carsSoldPerColour = new Dictionary<string, int>();
            var hadNoSales = true;
            
            foreach (var vehicle in GetVehicles().ToList())
            {
                var vehiclesSold = ServicesHelper.GetNumberOfVehiclesSold(vehicle.Sales.ToList(), startYear, endYear);

                // If any model, was sold, set hadNoSales to false
                if (vehiclesSold > 1) hadNoSales = false;
                
                if (carsSoldPerColour.ContainsKey(vehicle.Colour))
                {
                    carsSoldPerColour[vehicle.Colour] += vehiclesSold;
                }
                else
                {
                    carsSoldPerColour[vehicle.Colour] = vehiclesSold;
                }
            }

            // if no sales were made, return null, else, return key (colour) paired with the
            // highest number of vehicles sold (first element when values in the dictionary are sorted in descending order)
            return hadNoSales ? null : carsSoldPerColour.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;
        }
    }
}