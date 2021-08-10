using System.Collections.Generic;
using VehicleSalesAnalysis.Helpers;
using VehicleSalesAnalysis.Models;
using Xunit;

namespace VehicleSalesAnalysis.Tests.Helpers
{
    public class ServicesHelperTests
    {

        [Fact]
        public void GetNumberOfVehiclesSold()
        {
            var vehiclesSold = ServicesHelper.GetNumberOfVehiclesSold(new List<Sale>(), 2010, 2021);
            Assert.IsType<int>(vehiclesSold);
        }

        [Fact]
        public void AreValidYears()
        {
            var validYears = ServicesHelper.AreValidYears(2010, 2021);
            Assert.True(validYears);
        }

        [Fact]
        public void AreValidYears_WrongInput()
        {
            var validYears = ServicesHelper.AreValidYears(2030, -2021);
            Assert.False(validYears);
        }
    }
}