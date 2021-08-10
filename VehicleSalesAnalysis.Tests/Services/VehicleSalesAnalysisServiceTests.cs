using System;
using System.Collections.Generic;
using System.Linq;
using VehicleSalesAnalysis.Factory;
using VehicleSalesAnalysis.Services;
using Xunit;

namespace VehicleSalesAnalysis.Tests.Services
{
    public class VehicleSalesAnalysisServiceTests
    {
        private static IVehicleSalesAnalysisService GetServiceInstance()
        {
            return VehicleSalesAnalysisServiceFactory.GetService;
        }

        [Fact]
        public void GetVehicles_ReturnsPopulatedList()
        {
            var vehicles = GetServiceInstance().GetVehicles().ToList();
            Assert.NotEmpty(vehicles);
        }

        [Fact]
        public void GetNumberOfCarsSoldPerModel_ReturnsDictionary()
        {
            var carsSoldByModel = GetServiceInstance().GetNumberOfCarsSoldPerModel(2011, 2020);
            Assert.IsType<Dictionary<string, int>>(carsSoldByModel);
        }
        
        [Fact]
        public void GetNumberOfCarsSoldPerModel_WrongInput()
        {
            Assert.Throws<ArgumentException>(() => GetServiceInstance().GetNumberOfCarsSoldPerModel(2011, 2025));
        }

        [Fact]
        public void GetNumberOfCarsSoldPerManufacturer_ReturnsDictionary()
        {
            var carsSoldByManufacturer = GetServiceInstance().GetNumberOfCarsSoldPerManufacturer(2011, 2020);
            Assert.NotEmpty(carsSoldByManufacturer);
        }

        [Fact]
        public void GetNumberOfCarsSoldPerManufacturer_WrongInput()
        {
            Assert.Throws<ArgumentException>(() => GetServiceInstance().GetNumberOfCarsSoldPerManufacturer(-2010, 2021));
        }

        [Fact]
        public void SumOfAveragesOfNumVehiclesSoldPerManufacturer()
        {
            var average = GetServiceInstance().SumOfAveragesOfNumVehiclesSoldPerManufacturer(2020, 2020);
            Assert.IsType<int>(average);
        }
        
        [Fact]
        public void SumOfAveragesOfNumVehiclesSoldPerManufacturer_WrongInput()
        {
            Assert.Throws<ArgumentException>(() => GetServiceInstance().SumOfAveragesOfNumVehiclesSoldPerManufacturer(2022, 2010));
        }

        [Fact]
        public void MostCommonVehicleColourSold()
        {
            var colour = GetServiceInstance().MostCommonVehicleColourSold(2011, 2020);
            Assert.IsType<string>(colour);
        }

        [Fact]
        public void MostCommonVehicleColourSold_WrongInput()
        {
            Assert.Throws<ArgumentException>(() => GetServiceInstance().MostCommonVehicleColourSold(2010, -2020));
        }
        
        [Fact]
        public void MostCommonVehicleColourSold_NoSales()
        {
            var colour = GetServiceInstance().MostCommonVehicleColourSold(2005, 2009); // could also try 2021 - 2021
            Assert.Null(colour);
        }
    }
}