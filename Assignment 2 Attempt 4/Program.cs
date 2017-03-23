using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace Assignment_2_Attempt_4
{
    class Program
    {
        static void Main()
        {
            //Variables
            string name;
            int noRooms;
            int wallspace;
            double paintCostPerGallon;

            double paintAmount;
            double labourHrs;

            double paintCost;
            double paintVAT;
            double paintTotal;

            double labourCost;
            double labourVAT;
            double labourTotal;

            double total;
            double totalSterling;

            string tableFormat = "{0,-25}{1,-10}{2,-10}";
            string dummy = "";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo greatBritain = CultureInfo.GetCultureInfo("en-GB");

            //Input
            Console.Clear();
            Console.Write("Please enter customer name: ");
            name = Console.ReadLine();
            Console.Write("Now please enter amount of rooms to be painted: ");
            noRooms = int.Parse(Console.ReadLine());
            Console.Write("Now enter wallspace of each room in sqr.feet: ");
            wallspace = int.Parse(Console.ReadLine());
            Console.Write("Lastly enter price of paint per gallon: ");
            paintCostPerGallon = double.Parse(Console.ReadLine());

            //Process
            paintAmount = (noRooms * wallspace) / 150.00;
            labourHrs = paintAmount * 8.00;

            paintCost = paintAmount * paintCostPerGallon;
            paintVAT = paintCost * 0.20;
            paintTotal = paintCost + paintVAT;

            labourCost = labourHrs * 20.00;
            labourVAT = labourCost * 0.10;
            labourTotal = labourCost + labourVAT;

            total = labourTotal + paintTotal;
            totalSterling = total * 0.85;

            //Output
            Console.WriteLine();
            Console.WriteLine("Job Quote");
            Console.WriteLine(dummy.PadLeft(9, '='));
            Console.WriteLine(tableFormat, "Customer Name", ":", name);
            Console.WriteLine(tableFormat, "Date", ":", DateTime.Today.ToString("d"));
            Console.WriteLine();
            Console.WriteLine(tableFormat, "Total Number of Gallons", ":", paintAmount.ToString("n2"));
            Console.WriteLine(tableFormat, "Total Hours of Labour", ":", labourHrs.ToString("n2"));
            Console.WriteLine(dummy.PadLeft(30, '-'));
            Console.WriteLine(tableFormat, "Cost of Paint", ":", paintCost.ToString("c2"));
            Console.WriteLine(tableFormat, "Paint VAT", ":", paintVAT.ToString("c2"));
            Console.WriteLine(tableFormat, "Total Cost of Paint", ":", paintTotal.ToString("c2"));
            Console.WriteLine(dummy.PadLeft(30,'-'));
            Console.WriteLine(tableFormat, "Labour Cost", ":", labourCost.ToString("c2"));
            Console.WriteLine(tableFormat, "Labour VAT", ":", labourVAT.ToString("c2"));
            Console.WriteLine(tableFormat, "Total Labour Cost", ":", labourCost.ToString("c2"));
            Console.WriteLine(dummy.PadLeft(30,'-'));
            Console.WriteLine(tableFormat, "Total", ":", total.ToString("c2"));
            Console.WriteLine(tableFormat, "Sterling Equivalent", ":", totalSterling.ToString("c2", greatBritain.NumberFormat));
            Console.Write("\nDo you want to save? (yes/no) ");
            string choice;
            choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    Stream path;
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = ".txt File|*.txt|Modern Word File|*.docx|Old Word File|*.doc|Any File|*.*";
                    save.FilterIndex = 1;
                    save.RestoreDirectory = true;
                    string folderPathway;
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        folderPathway = Path.GetFullPath(save.FileName);
                        if ((path = save.OpenFile()) != null)
                        {
                            StreamWriter receipt = new StreamWriter(path);
                            receipt.WriteLine("Job Quote");
                            receipt.WriteLine(dummy.PadLeft(9, '='));
                            receipt.WriteLine(tableFormat, "Customer Name", ":", name);
                            receipt.WriteLine(tableFormat, "Date", ":", DateTime.Today.ToString("d"));
                            receipt.WriteLine();
                            receipt.WriteLine(tableFormat, "Total Number of Gallons", ":", paintAmount.ToString("n2"));
                            receipt.WriteLine(tableFormat, "Total Hours of Labour", ":", labourHrs.ToString("n2"));
                            receipt.WriteLine(dummy.PadLeft(30, '-'));
                            receipt.WriteLine(tableFormat, "Cost of Paint", ":", paintCost.ToString("c2"));
                            receipt.WriteLine(tableFormat, "Paint VAT", ":", paintVAT.ToString("c2"));
                            receipt.WriteLine(tableFormat, "Total Cost of Paint", ":", paintTotal.ToString("c2"));
                            receipt.WriteLine(dummy.PadLeft(30, '-'));
                            receipt.WriteLine(tableFormat, "Labour Cost", ":", labourCost.ToString("c2"));
                            receipt.WriteLine(tableFormat, "Labour VAT", ":", labourVAT.ToString("c2"));
                            receipt.WriteLine(tableFormat, "Total Labour Cost", ":", labourCost.ToString("c2"));
                            receipt.WriteLine(dummy.PadLeft(30, '-'));
                            receipt.WriteLine(tableFormat, "Total", ":", total.ToString("c2"));
                            receipt.WriteLine(tableFormat, "Sterling Equivalent", ":", totalSterling.ToString("c2", greatBritain.NumberFormat));
                            receipt.Close();
                            path.Close();
                            Process.Start(folderPathway);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
