using System;
using System.Collections.Generic;
using System.Text;

//I, Ayub Ali, 000354446 certify that this material is my original work.No other person's work has been used without due acknowledgement.
namespace Lab1
{
    /// <summary>
    /// Creates the employee object here.
    /// </summary>
    class Employee
    {
        private string name; 
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        /// <summary>
        /// This is the employee contructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <param name="rate"></param>
        /// <param name="hours"></param>

        public Employee(string name, int number,decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;

            if (hours < 40.0)
            {
                gross = (decimal)hours * rate;
                return;
            }
            gross = (40.0M) * rate + ((decimal)hours - (40.0M)) * rate * (1.5M);
        }

        //Get methods

        public decimal GetGross()
        {
            return gross;
        }

        public double GetHours()
        {
            return hours;
        }

        public string GetName()
        {
            return name;
        }

        public int GetNumber()
        {
            return number;
        }

        public decimal GetRate()
        {
            return rate;
        }

        

        public void printEmploy()
        {
            Console.WriteLine("*{0, -15} | {1:D5} | {2,6:C} | {3:#0.00} | {4,9:C}|\n", this.name, this.number, this.rate, this.hours, this.gross);
        }

        //Set methods
        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }
    }
}
