using System.Collections.Generic;
using VehicleSalesAnalysis.Models;

namespace VehicleSalesAnalysis.Services
{
    public interface IVehicleSalesAnalysisService
    {
        IEnumerable<Vehicle> GetVehicles();
        Dictionary<string, int> GetNumberOfCarsSoldPerModel(int startYear, int endYear);
        Dictionary<string, int> GetNumberOfCarsSoldPerManufacturer(int startYear, int endYear);
        int SumOfAveragesOfNumVehiclesSoldPerManufacturer(int startYear, int endYear);
        string MostCommonVehicleColourSold(int startYear, int endYear);
    }
}