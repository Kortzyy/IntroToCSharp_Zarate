using System;
using System.Collections.Generic;
using System.Text;
using CodacLogistics.Delivery_FuelAuditor.Models;

namespace CodacLogistics.Delivery_FuelAuditor.Services
{
    public class FuelService
    {
        // CALCULATES THE TOTAL FUEL SPENT FOR 5 DAYS
        public decimal CalculateTotalFuel(decimal[] expenses)
        {
            decimal total = 0;

            // LOOP THROUGH EACH DAY'S EXPENSE
            for (int i = 0; i < expenses.Length; i++)
            {
                total += expenses[i];
            }

            return total;
        }

        // CALCULATES THE AVERAGE DAILY FUEL EXPENSE
        public decimal CalculateAverageFuel(decimal totalFuel)
        {
            return totalFuel / 5;
        }

        // DETERMINES THE FUEL EFFICIENCY RATING
        public string GetEfficiencyRating(double totalDistance, decimal totalFuel)
        {
            // CONVERT DECIMAL TO DOUBLE FOR CALCULATION
            double efficiency = totalDistance / (double)totalFuel;

            // CHECK EFFICIENCY CONDITIONS
            if (efficiency > 15)
                return "High Efficiency";
            else if (efficiency >= 10)
                return "Standard Efficiency";
            else
                return "Low Efficiency / Maintenance Required";
        }

        // CHECKS IF DRIVER STAYED WITHIN BUDGET
        public bool IsUnderBudget(decimal totalFuel, decimal budget)
        {
            return totalFuel <= budget;
        }
    }
}
