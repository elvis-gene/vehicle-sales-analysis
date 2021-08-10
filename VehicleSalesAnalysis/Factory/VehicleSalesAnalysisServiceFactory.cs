using VehicleSalesAnalysis.Services;

namespace VehicleSalesAnalysis.Factory
{
    public static class VehicleSalesAnalysisServiceFactory
    {
        // Make the service a singleton
        private static IVehicleSalesAnalysisService _vehicleSalesAnalysisService;
        
        public static IVehicleSalesAnalysisService GetService =>
            _vehicleSalesAnalysisService ??= new VehicleSalesAnalysisService();
    }
}