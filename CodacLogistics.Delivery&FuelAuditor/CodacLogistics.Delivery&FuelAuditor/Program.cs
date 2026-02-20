/*
===============================================================
Name of the Lab: Prelim Activity 01: Codac Logistics Delivery & Fuel Auditor
Developer Name : Kurt Russel B. Zarate
Subject        : IT Elective 2
Course & Block : BSIT - 3.2
Date Created   : February 18, 2026
Description    : This is a console-based application that tracks the daily fuel expenses and delivery performance of a single vehicle over a 5-day work week

The System:
- Collects Driver Profile Information
- Validates Distance Input Using While Loop
- Stores Daily Fuel Expenses in a 1D Array
- Calculates Total and Average Fuel Costs
- Determines Fuel Efficiency Rating
- Check if the Driver stayed within the Budget

C# Concepts Used:
- Data Types (String, Int, Double, Decimal, Bool)
- Loops (While, For)
- Array (1D Decimal Array)
- Conditional Statements (If / Else)
- String Interpolation ($"")
===============================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using CodacLogistics.Delivery_FuelAuditor.Models;
using CodacLogistics.Delivery_FuelAuditor.Services;

namespace CodacLogistics.Delivery_FuelAuditor
{
    class Program
    {
        static void Main(string[] args)
        {
            // SETS THE CONSOLE WINDOW TITLE
            Console.Title = "Codac Logistics - Fuel Tracking System";

            // CREATE OBJECT INSTANCES
            DriverProfile driver = new DriverProfile();
            FuelService fuelService = new FuelService();

            // ======================================================
            // TASK 1: DRIVER PROFILE INPUT AND DISTANCE VALIDATION
            // ======================================================

            // ASK FOR DRIVER NAME
            // STRING IS USED FOR DRIVER'S FULL NAME BECAUSE IT STORES TEXT DATA
            Console.Write("Enter Driver Full Name: ");
            driver.FullName = Console.ReadLine();

            // ASK FOR WEEKLY FUEL BUDGET (DECIMAL FOR MONEY)
            // DECIMAL IS USED FOR MONEY TO AVOID FLOATING-POINT ROUNDING ERRORS
            Console.Write("Enter Weekly Fuel Budget: ");
            driver.WeeklyFuelBudget = decimal.Parse(Console.ReadLine());

            // VALIDATE TOTAL DISTANCE USING WHILE LOOP
            // WHILE LOOP IS USED INSTEAD OF IF TO CONTINUOUSLY VALIDATE INPUT UNTIL THE USER ENTERS A VALUE BETWEEN 1.0 AND 5000.0
            while (true)
            {
                Console.Write("Enter Total Distance Traveled (1 - 5000 km): ");
                driver.TotalDistance = double.Parse(Console.ReadLine());

                // CHECK IF DISTANCE IS WITHIN VALID RANGE
                // DOUBLE IS USED FOR DISTANCE BECAUSE IT MAY CONTAIN DECIMAL VALUES
                if (driver.TotalDistance >= 1.0 && driver.TotalDistance <= 5000.0)
                    break; // EXIT LOOP IF VALID

                // ERROR MESSAGE IF INVALID INPUT
                Console.WriteLine("Invalid distance. Please enter a value between 1 and 5000.\n");
            }

            // ======================================================
            // TASK 2: FUEL EXPENSE TRACKING USING 1D ARRAY
            // ======================================================

            // DECIMAL IS USED FOR MONEY VALUES
            decimal totalFuelSpent = 0;

            // LOOP TO INPUT 5 DAYS OF FUEL EXPENSES
            // ARRAY IS USED TO STORE DAILY EXPENSES
            for (int i = 0; i < driver.FuelExpenses.Length; i++)
            {
                // (i + 1) IS USED BECAUSE ARRAY STARTS AT 0 BUT USERS COUNT FROM 1
                Console.Write($"Enter fuel expense for Day {i + 1}: ");
                driver.FuelExpenses[i] = decimal.Parse(Console.ReadLine());

                // ACCUMULATE TOTAL FUEL SPENT
                totalFuelSpent += driver.FuelExpenses[i];
            }

            // ======================================================
            // TASK 3: PERFORMANCE ANALYSIS
            // ======================================================

            // CALCULATE AVERAGE DAILY FUEL
            // METHOD IS USED TO KEEP CALCULATION LOGIC SEPARATE
            decimal averageFuel = fuelService.CalculateAverageFuel(totalFuelSpent);

            // DETERMINE EFFICIENCY RATING
            // EFFICIENCY CALCULATION RETURNS STRING RATING
            string efficiencyRating = fuelService.GetEfficiencyRating(driver.TotalDistance, totalFuelSpent);

            // CHECK IF DRIVER STAYED UNDER BUDGET
            // BOOLEAN IS USED BECAUSE BUDGET CHECK RETURNS TRUE OR FALSE
            bool isUnderBudget = fuelService.IsUnderBudget(totalFuelSpent, driver.WeeklyFuelBudget);

            // ======================================================
            // TASK 4: DISPLAY FORMATTED AUDIT REPORT
            // ======================================================

            Console.WriteLine("\n==========================================");
            Console.WriteLine("        CODAC LOGISTICS AUDIT REPORT");
            Console.WriteLine("==========================================");

            // STRING INTERPOLATION ($"") IS USED FOR CLEAN AND READABLE OUTPUT
            Console.WriteLine($"Driver Name: {driver.FullName}");
            Console.WriteLine($"Total Distance: {driver.TotalDistance} KM");

            Console.WriteLine("\nFuel Expense Breakdown:");

            // DISPLAY EACH DAY'S EXPENSE
            for (int i = 0; i < driver.FuelExpenses.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: PHP {driver.FuelExpenses[i]}");
            }

            Console.WriteLine($"\nTotal Fuel Spent: PHP {totalFuelSpent}");
            Console.WriteLine($"Average Daily Fuel Expense: PHP {averageFuel}");
            Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
            Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");

            // PAUSE BEFORE EXITING
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}