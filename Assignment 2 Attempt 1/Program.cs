/* ==============================================
            Paint Job Calculator V1
   6-11-2016
   -Main Menu Added
   -Receipt Can be Saved into a File
   -Receipt Menu includes 4 currencies
   -Started Update Currency Menu
   ==============================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Assignment_2_Attempt_1
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            //Variables
            string dummy = "";
            string choice;

            //Input
            Console.Clear();
            Console.WriteLine(dummy.PadLeft(120, '='));
            Console.WriteLine("                                              Paint Job Calculator V1");
            Console.WriteLine();
            Console.WriteLine(dummy.PadLeft(120, '='));
            Console.WriteLine("Main Menu:\n");
            Console.WriteLine("1) Prepare a receipt");
            Console.WriteLine("2) Update Values");
            Console.WriteLine("3) Exit\n");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Receipt();
                    break;
                case "2":
                    updateSettings();
                    break;
                case "3":
                    return;
            }
        }

        static void updateSettings()
        {
            string format = "{0,-30}{0,-10}{0,-10}";
            Console.WriteLine("According to your databse:");
            Console.WriteLine(format, "",":");
        }
        static void Receipt()
        {
            //Variables
            
            string name;
            int roomNo;
            int sqrFeet;
            double paintPrice;
            string currencyChoice1 = "";
            string currencyChoice2 = "";
            string currencyChoice3 = "";
            string currencyChoice4 = "";
            string choice;

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
            double plnTotal;
            double yenTotal;
            double usdTotal;

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

            start:
                Console.Write("Lastly please enter abbrieviated currency you wish on your bill (gbp, yen, pln or usd): ");
                currencyChoice1 = Console.ReadLine();
                if (currencyChoice1 == "gbp" || currencyChoice1 == "yen" || currencyChoice1 == "usd" || currencyChoice1 == "pln")
                {
                    goto next;
                }
                else
                {
                    Console.WriteLine("Invalid choice, choose again.");
                    goto start;
                }

            next:
            Console.Write("Do you want to add more currencies? (yes/no) ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    start2:
                    Console.Write("Please enter another currency (gbp, yen, pln or usd): ");
                    currencyChoice2 = Console.ReadLine();
                    if (currencyChoice2 == "gbp" || currencyChoice2 == "yen" || currencyChoice2 == "usd" || currencyChoice2 == "pln")
                    {
                        goto next2;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, choose again.");
                        goto start2;
                    }

                    next2:
                    if (currencyChoice2 == currencyChoice1)
                    {
                        Console.Write("Please enter a different currency than {0}.\n", currencyChoice1);
                        goto case "yes"; 
                    }
                    else
                    {
                        break;
                    }

                case "no":
                    goto process;

                default:
                    Console.WriteLine("Invalid choice");
                    goto case "yes";
            }

            Console.Write("Do you want to add more currencies? (yes/no) ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    start3:
                    Console.Write("Please enter another currency (gbp, yen, pln or usd): ");
                    currencyChoice3 = Console.ReadLine();
                    if (currencyChoice3 == "gbp" || currencyChoice3 == "yen" || currencyChoice3 == "usd" || currencyChoice3 == "pln")
                    {
                        goto next3;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, choose again.");
                        goto start3;
                    }
                next3:
                    if (currencyChoice3 == currencyChoice1)  
                    {
                        Console.Write("Please enter a different currency than {0}.\n", currencyChoice1);
                        goto case "yes";
                    }
                    else if (currencyChoice3 == currencyChoice2)
                    {
                        Console.Write("Please enter a different currency than {0}.\n", currencyChoice1);
                        goto case "yes";
                    }
                    else
                    {
                        break;
                    }

                case "no":
                    goto process;

                default:
                    Console.WriteLine("Invalid choice");
                    goto case "yes";
            }

            Console.Write("Do you want to add more currencies? (yes/no) ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                start4:
                    Console.Write("Please enter another currency (gbp, yen, pln or usd): ");
                    currencyChoice4 = Console.ReadLine();
                    if (currencyChoice4 == "gbp" || currencyChoice4 == "yen" || currencyChoice4 == "usd" || currencyChoice4 == "pln")
                    {
                        goto next4;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, choose again.");
                        goto start4;
                    }

                next4:
                    if (currencyChoice4 == currencyChoice1)
                    {
                        Console.Write("Please enter a different currency than {0}.\n", currencyChoice1);
                        goto case "yes";
                    }
                    else if (currencyChoice4 == currencyChoice2)
                    {
                        Console.Write("Please enter a different currency than {0}.\n", currencyChoice1);
                        goto case "yes";
                    }
                    else if (currencyChoice4 == currencyChoice3)
                    {
                        Console.Write("Please enter a different currency than {0}.\n", currencyChoice1);
                        goto case "yes";
                    }
                    else
                    {
                        break;
                    }

                case "no":
                    goto process; 
                default:
                    Console.WriteLine("Invalid choice");
                    goto case "yes";
            }

            process:
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
            plnTotal = total * 4.10;
            yenTotal = total * 110.80;
            usdTotal = total * 1.10;

            //Output
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Job Quote");
            Console.WriteLine(dummy.PadLeft(9,'='));
            Console.WriteLine(tableFormat, "Date", ":", DateTime.Today.ToString("d"));
            Console.WriteLine(tableFormat, "Customer Name", ":", name);

            Console.WriteLine();
            Console.WriteLine(tableFormat, "Total Number of Gallons", ":", paintAmount.ToString("n2"));
            Console.WriteLine(tableFormat, "Total Hours of Labour", ":", hours.ToString("n2"));

            Console.WriteLine(dummy.PadLeft(36,'-'));
            Console.WriteLine(tableFormat, "Cost of Paint", ":", paintCost.ToString("c2"));
            Console.WriteLine(tableFormat, "Paint VAT", ":", paintVat.ToString("c2"));
            Console.WriteLine(tableFormat, "Total cost of Paint", ":", paintTotal.ToString("c2"));

            Console.WriteLine(dummy.PadLeft(36,'-'));
            Console.WriteLine(tableFormat, "Labour Cost", ":", labourCost.ToString("c2"));
            Console.WriteLine(tableFormat, "Labour VAT", ":", labourVat.ToString("c2"));
            Console.WriteLine(tableFormat, "Labour Total", ":", labourTotal.ToString("c2"));

            Console.WriteLine(dummy.PadLeft(36,'-'));
            Console.WriteLine(tableFormat, "Total Cost of Job", ":", total.ToString("c2"));

            switch (currencyChoice1.ToLower())
            {
                case "gbp":
                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                    Console.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                    break;

                case "pln":
                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                    Console.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                    break;

                case "yen":
                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                    Console.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                    break;

                case "usd":
                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                    Console.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                    break;

                default:
                    break;
            }

            switch (currencyChoice2.ToLower())
            {
                case "gbp":
                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                    Console.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                    break;

                case "pln":
                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                    Console.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                    break;

                case "yen":
                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                    Console.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                    break;

                case "usd":
                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                    Console.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                    break;

                default:
                    break;
            }

            switch (currencyChoice3.ToLower())
            {
                case "gbp":
                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                    Console.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                    break;

                case "pln":
                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                    Console.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                    break;

                case "yen":
                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                    Console.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                    break;

                case "usd":
                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                    Console.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                    break;

                default:
                    break;
            }

            switch (currencyChoice4.ToLower())
            {
                case "gbp":
                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                    Console.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                    break;

                case "pln":
                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                    Console.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                    break;

                case "yen":
                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                    Console.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                    break;

                case "usd":
                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                    Console.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                    break;

                default:
                    break;
            }

            Console.WriteLine("Would you like to print this receipt? (yes,no): ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    Stream path;
                    SaveFileDialog b = new SaveFileDialog();
                    b.Filter = "Txt Files (*.txt)|*.txt|Word Document (*.doc)|*.doc|Modern Word Document (*.docx)|*.docx|All Files|*.*";
                    b.FilterIndex = 1;
                    b.RestoreDirectory = true;
                    string folderPathway;
                    if (b.ShowDialog() == DialogResult.OK)
                    {
                        folderPathway = Path.GetFullPath(b.FileName);
                        if ((path = b.OpenFile()) != null)
                        {
                            StreamWriter Receipt = new StreamWriter(path);
                            Receipt.WriteLine("Job Quote");
                            Receipt.WriteLine(dummy.PadLeft(9, '='));
                            Receipt.WriteLine(tableFormat, "Date", ":", DateTime.Today.ToString("d"));
                            Receipt.WriteLine(tableFormat, "Customer Name", ":", name);

                            Receipt.WriteLine("");
                            Receipt.WriteLine(tableFormat, "Total Number of Gallons", ":", paintAmount.ToString("n2"));
                            Receipt.WriteLine(tableFormat, "Total Hours of Labour", ":", hours.ToString("n2"));

                            Receipt.WriteLine(dummy.PadLeft(36, '-'));
                            Receipt.WriteLine(tableFormat, "Cost of Paint", ":", paintCost.ToString("c2"));
                            Receipt.WriteLine(tableFormat, "Paint VAT", ":", paintVat.ToString("c2"));
                            Receipt.WriteLine(tableFormat, "Total cost of Paint", ":", paintTotal.ToString("c2"));

                            Receipt.WriteLine(dummy.PadLeft(36, '-'));
                            Receipt.WriteLine(tableFormat, "Labour Cost", ":", labourCost.ToString("c2"));
                            Receipt.WriteLine(tableFormat, "Labour VAT", ":", labourVat.ToString("c2"));
                            Receipt.WriteLine(tableFormat, "Labour Total", ":", labourTotal.ToString("c2"));

                            Receipt.WriteLine(dummy.PadLeft(36, '-'));
                            Receipt.WriteLine(tableFormat, "Total Cost of Job", ":", total.ToString("c2"));
                            switch (currencyChoice1.ToLower())
                            {
                                case "gbp":
                                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                                    Receipt.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                                    break;

                                case "pln":
                                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                                    Receipt.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                                    break;

                                case "yen":
                                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                                    Receipt.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                                    break;

                                case "usd":
                                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                                    Receipt.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                                    break;

                                default:
                                    break;
                            }

                            switch (currencyChoice2.ToLower())
                            {
                                case "gbp":
                                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                                    Receipt.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                                    break;

                                case "pln":
                                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                                    Receipt.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                                    break;

                                case "yen":
                                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                                    Receipt.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                                    break;

                                case "usd":
                                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                                    Receipt.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                                    break;

                                default:
                                    break;
                            }

                            switch (currencyChoice3.ToLower())
                            {
                                case "gbp":
                                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                                    Receipt.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                                    break;

                                case "pln":
                                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                                    Receipt.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                                    break;

                                case "yen":
                                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                                    Receipt.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                                    break;

                                case "usd":
                                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                                    Receipt.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                                    break;

                                default:
                                    break;
                            }

                            switch (currencyChoice4.ToLower())
                            {
                                case "gbp":
                                    CultureInfo gbp = CultureInfo.GetCultureInfo("en-GB");                          //Getting the pound sign
                                    Receipt.WriteLine(tableFormat, "Sterling Equivalent", ":", sterlingTotal.ToString("c2", gbp.NumberFormat));
                                    break;

                                case "pln":
                                    CultureInfo pln = CultureInfo.GetCultureInfo("pl-PL");
                                    Receipt.WriteLine(tableFormat, "Zloty equivalent", ":", plnTotal.ToString("c2", pln.NumberFormat));
                                    break;

                                case "yen":
                                    CultureInfo yen = CultureInfo.GetCultureInfo("ja-JP");
                                    Receipt.WriteLine(tableFormat, "Yen equivalent", ":", yenTotal.ToString("c2", yen.NumberFormat));
                                    break;

                                case "usd":
                                    CultureInfo usd = CultureInfo.GetCultureInfo("en-US");
                                    Receipt.WriteLine(tableFormat, "Dollar equivalent", ":", usdTotal.ToString("c2", usd.NumberFormat));
                                    break;

                                default:
                                    break;
                            }
                            Receipt.Close();
                            path.Close();
                            Process.Start(folderPathway);
                        }
                    }
                    Main();
                    break;
                case "no":
                    Main();
                    break;
            }
        }
    }
}