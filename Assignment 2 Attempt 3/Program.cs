using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment_2_Attempt_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string name;
            int roomNo;
            int roomSize;
            double paintCostPerGallon;

            double totalPaintAmount;
            double totalHrLabour;

            double paintCost;
            double paintVAT;
            double paintTotal;

            double labourCost;
            double labourVAT;
            double labourTotal;

            double total;
            double sterlingTotal;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo gb = CultureInfo.GetCultureInfo("en-GB");

            string format = "{0,-25}{1,-10}{2,-10}";
            string dummy = "";

            //Input
            Console.Clear();
            Console.Write("Please enter customer name: ");
            name = Console.ReadLine();
            Console.Write("Now please enter number of rooms to be painted: ");
            roomNo = int.Parse(Console.ReadLine());
            Console.Write("Now enter the size of room in sqr. feet: ");
            roomSize = int.Parse(Console.ReadLine());
            Console.Write("Lastly please enter paint cost per gallon: ");
            paintCostPerGallon = double.Parse(Console.ReadLine());

            //Processing
            totalPaintAmount = (roomNo * roomSize) / 150;
            totalHrLabour = totalPaintAmount * 8;

            paintCost = totalPaintAmount * paintCostPerGallon;
            paintVAT = paintCost * 0.20;
            paintTotal = paintCost + paintVAT;

            labourCost = totalHrLabour * 20.00;
            labourVAT = labourCost * 0.10;
            labourTotal = labourCost + labourVAT;

            total = paintTotal + labourTotal;
            sterlingTotal = total * 0.85;

            //Output
            Console.WriteLine();
            Console.WriteLine("Job Quote");
            Console.WriteLine(dummy.PadLeft(9, '='));
            Console.WriteLine(format, "Date",":", DateTime.Today.ToString("d"));
            Console.WriteLine(format, "Customer Name", ":", name);
            Console.WriteLine();
            Console.WriteLine(format, "Total Number of Gallons", ":", totalPaintAmount.ToString("n2"));
            Console.WriteLine(format, "Total Hours of Labour", ":", totalHrLabour.ToString("n2"));
            Console.WriteLine(dummy.PadLeft(30, '-'));
            Console.WriteLine(format, "Cost of Paint", ":", paintCost.ToString("c2"));
            Console.WriteLine(format, "Paint VAT", ":", paintVAT.ToString("c2"));
            Console.WriteLine(format, "Total Cost of Paint", ":", paintTotal.ToString("c2"));
            Console.WriteLine(dummy.PadLeft(30, '-'));
            Console.WriteLine(format, "Labour Cost", ":", labourCost.ToString("c2"));
            Console.WriteLine(format, "Labour VAT", ":", labourVAT.ToString("c2"));
            Console.WriteLine(format, "Total Labour Cost", ":", labourTotal.ToString("c2"));
            Console.WriteLine(dummy.PadLeft(30, '-'));
            Console.WriteLine(format, "Total Cost of Job", ":", total.ToString("c2"));
            Console.WriteLine(format, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gb.NumberFormat));
        }
    }
}
