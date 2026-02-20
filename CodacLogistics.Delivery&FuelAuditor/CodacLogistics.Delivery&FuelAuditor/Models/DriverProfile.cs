using System;
using System.Collections.Generic;
using System.Text;

namespace CodacLogistics.Delivery_FuelAuditor.Models
{
    public class DriverProfile
    {
        // STORES THE DRIVER'S COMPLETE NAME
        public string FullName { get; set; }

        // STORES THE WEEKLY FUEL BUDGET (MONEY USES DECIMAL)
        public decimal WeeklyFuelBudget { get; set; }

        // STORES TOTAL DISTANCE TRAVELED FOR THE WEEK
        public double TotalDistance { get; set; }

        // ARRAY THAT STORES FUEL EXPENSES FOR 5 DAYS
        public decimal[] FuelExpenses { get; set; }

        // CONSTRUCTOR - INITIALIZES THE ARRAY SIZE TO 5 DAYS
        public DriverProfile()
        {
            FuelExpenses = new decimal[5];
        }
    }
}