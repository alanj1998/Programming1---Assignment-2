/* ==============================================
            Paint Job Calculator V1
   ==============================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;             //Add that to display the pound sign
using System.Diagnostics;

namespace Assignment_2_Attempt_1
{
    class Program
    {
        static void Main()
        {
            //Variables

            string name;
            int roomNo;
            int sqrFeet;
            double paintPrice;

            double paintAmount;
            double hours;

            double paintCost;
            double paintVat;
            double paintTotal;

            double labourCost;
            double labourVat;
            double labourTotal;

            double total;
            double sterlingTotal;

            string tableFormat;
            tableFormat = "{0,-25}{1,-10}{2,-10}";

            string dummy;
            dummy = "";

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Input
            Console.Clear();
            Console.Write("Please enter customer name: ");
            name = Console.ReadLine();
            Console.Write("Please enter the amount of rooms which are to be painted: ", name);
            roomNo = int.Parse(Console.ReadLine());
            Console.Write("Now please enter the wall space of each room in square feet: ");
            sqrFeet = int.Parse(Console.ReadLine());
            Console.Write("Now lastly please enter the price per gallon of paint to be used: ");
            paintPrice = double.Parse(Console.ReadLine());

            //Processing
                //Amounts of paint and labour time
            paintAmount = (roomNo * sqrFeet) / 150.00;
            hours = paintAmount * 8;

                //Paint totals
            paintCost = paintAmount * paintPrice;
            paintVat = paintCost * 0.20;
            paintTotal = paintCost + paintVat;

                //Labour totals
            labourCost = hours * 20.00;
            labourVat = labourCost * 0.10;
            labourTotal = labourCost + labourVat;

                //Totals
            total = paintTotal + labourTotal;
            sterlingTotal = total * 0.85;

            //Output
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Job Quote");
            Console.WriteLine(dummy.PadLeft(9, '='));
            Console.WriteLine(tableFormat, "Date", ":", DateTime.Today.ToString("d"));
            Console.WriteLine(tableFormat, "Customer Name", ":", name);

            Console.WriteLine();
            Console.WriteLine(tableFormat, "Total Number of Gallons", ":", paintAmount.ToString("n2"));
            Console.WriteLine(tableFormat, "Total Hours of Labour", ":", hours.ToString("n2"));

            Console.WriteLine(dummy.PadLeft(36, '-'));
            Console.WriteLine(tableFormat, "Cost of Paint", ":", paintCost.ToString("c2"));
            Console.WriteLine(tableFormat, "Paint VAT", ":", paintVat.ToString("c2"));
            Console.WriteLine(tableFormat, "Total cost of Paint", ":", paintTotal.ToString("c2"));

            Console.WriteLine(dummy.PadLeft(36, '-'));
            Console.WriteLine(tableFormat, "Labour Cost", ":", labourCost.ToString("c2"));
            Console.WriteLine(tableFormat, "Labour VAT", ":", labourVat.ToString("c2"));
            Console.WriteLine(tableFormat, "Labour Total", ":", labourTotal.ToString("c2"));

            Console.WriteLine(dummy.PadLeft(36, '-'));
            Console.WriteLine(tableFormat, "Total Cost of Job", ":", total.ToString("c2"));

            CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
            Console.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
        }
    }
}