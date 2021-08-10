using VehicleSalesAnalysis.Factory;
using Xunit;

namespace VehicleSalesAnalysis.Tests.Factory
{
    public class VehicleSalesAnalysisServiceFactoryTests
    {

        [Fact]
        public void ServiceIsSingleton()
        {
            var instance1 = VehicleSalesAnalysisServiceFactory.GetService;
            var instance2 = VehicleSalesAnalysisServiceFactory.GetService;

            Assert.Same(instance1, instance2);
        }
    }
}