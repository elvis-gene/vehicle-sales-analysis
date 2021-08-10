using System;
using System.Collections.Generic;
using System.Linq;
using VehicleSalesAnalysis.Models;

namespace VehicleSalesAnalysis.Helpers
{
    public static class ServicesHelper
    {
        public static int GetNumberOfVehiclesSold(IEnumerable<Sale> sales, int startYear, int endYear)
        {
            return sales.Where(sale => sale.Year >= startYear && sale.Year <= endYear).Sum(sale => sale.VehiclesSold);
        }

        // Doesn't accept years in the future.
        // End year must be bigger than start year.
        // Year can't be negative
        // Year must be of type int?
        public static bool AreValidYears(int startYear, int endYear)
        {
            if (IsValidYear(startYear) && IsValidYear(endYear))
            {
                return endYear >= startYear;
            }

            return false;
        }

        private static bool IsValidYear(int year)
        {
            return year <= DateTime.Now.Year && year >= 0;
        }
    }
}