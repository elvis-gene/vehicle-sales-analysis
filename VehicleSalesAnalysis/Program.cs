using System;
using System.Collections.Generic;
using VehicleSalesAnalysis.Factory;
using VehicleSalesAnalysis.Services;

namespace VehicleSalesAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleService = VehicleSalesAnalysisServiceFactory.GetService;
            
            var numberOfCarsSoldPerModel = vehicleService.GetNumberOfCarsSoldPerModel(2011, 2020);
            
            foreach (var (key, value) in numberOfCarsSoldPerModel)
            {
                Console.WriteLine($"{key} ─ {value}");
            }
            
            Console.WriteLine("");

            var numberOfCarsSoldPerManufacturer = vehicleService.GetNumberOfCarsSoldPerManufacturer(2011, 2020);
            
            foreach (var (key, value) in numberOfCarsSoldPerManufacturer)
            {
                Console.WriteLine($"{key} ─ {value}");
            }

            Console.WriteLine("");
            
            var sum = vehicleService.SumOfAveragesOfNumVehiclesSoldPerManufacturer(2011, 2020);
            Console.WriteLine($"Sum of Averages: {sum}\n");

            var colour = vehicleService.MostCommonVehicleColourSold(2011, 2020);
            Console.WriteLine($"Colour: {colour}");
        }
    }
}