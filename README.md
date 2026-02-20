# IntroToCSharp_Zarate
**Prelim Activity 01 : Codac Logistics Delivery &amp; Fuel Auditor**

# Task Description
This project is a console-based C# application developed for **Codac Logistics** to monitor the daily fuel expenses and delivery performance of a single vehicle over a 5-day work week.

The system was designed to simulate a real-world logistics tracking tool used by delivery drivers and accounting departments to evaluate operational efficiency and budget compliance.

# Project Objective
The objective of this system is to:

* Collect driver profile information
* Validate weekly travel distance input
* Record daily fuel expenses using a 1D array
* Calculate total and average fuel consumption
* Determine fuel efficiency rating
* Compare total fuel expenses against the weekly budget
* Generate a formatted audit report

# Technical Requirements Implemented
This application demonstrates the following C# concepts:

**Data Types**
* string – Driver’s full name
* double – Total distance traveled
* decimal – Fuel budget and expenses (for financial accuracy)
* bool – Budget status result

**Input & Output**

* Console.ReadLine() for user input
* String interpolation ($"") for formatted output

**Validation**

* A while loop ensures that total distance is between 1.0 and 5000.0 kilometers
* Prevents invalid data from being processed

**Data Structure**

* A one-dimensional decimal[] array stores fuel expenses for 5 working days

**Control Flow**

* for loop processes daily expenses
* if/else statements determine fuel efficiency rating

# Efficiency Rating Logic
Fuel efficiency is calculated using the formula: Efficiency = Total Distance ÷ Total Fuel Spent

The system classifies performance as:

* **High Efficiency** → Efficiency > 15
* **Standard Efficiency** → Efficiency ≥ 10
* **Low Efficiency / Maintenance Required** → Efficiency < 10

# Budget Evaluation
The program compares: Total Fuel Spent vs Weekly Fuel Budget

It then determines whether the driver stayed within budget using a boolean condition.

# Project Structure
**CodacLogistics.Delivery&FuelAuditor**

`Program.cs` // Handles user interaction and output

    |_
`Models` 
  `DriverProfile.cs` // Store Driver data
`Services`
  `FuelService.cs` // Handles calculation and Logic
