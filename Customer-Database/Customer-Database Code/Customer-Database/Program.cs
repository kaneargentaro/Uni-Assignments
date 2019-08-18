using System;
using System.IO;

namespace Customer_Database
{
    class Program
    {
            static string GetString(string prompt, string error)
            {
                string data = "";
                while (data == "")
                {
                    Console.Write(prompt);
                    data = Console.ReadLine();
                    if (data == "") Console.WriteLine(error);
                }
                return data;
            }
            static void AddCustomer(string[] Name, string[] Address, string[] Refno, string[] Plan, ref int current, ref int howmany)
            {
                // Get input data
                string name = "";
                do
                {
                    name = GetString("Enter Customer Full Name: ", "Full Name is empty and should be alphabetic characters only");
                    for (int i = 0; i < howmany; i++)
                        if (Name[i] == name)
                        {
                            Console.WriteLine("This name already exists\n");
                            name = "Incorrect Name";

                        }
                    if (name == "" || name == " " || name.Contains("0") || name.Contains("1") || name.Contains("2") ||
                            name.Contains("3") || name.Contains("4") || name.Contains("5") || name.Contains("6") || name.Contains("7") ||
                            name.Contains("8") || name.Contains("9"))
                    {
                        Console.WriteLine("Full Name is empty and should be alphabetic characters only\n");
                        name = "Incorrect Name";

                    }
                } while (name == "Incorrect Name");

                string address = "";
                do
                {
                    address = GetString("Enter Customer Address: ", "Address is empty or must contain a number in the first position");
                    for (int i = 0; i < howmany; i++)
                        if (Address[i] == address)
                        {
                            Console.WriteLine("This Address is already in use\n");
                            address = "Not The Right Address";
                        }
                    if (address.Length == 0 || address[0] == ' ' || !Char.IsDigit(address[0]))
                    {
                        Console.WriteLine("Address is empty or must contain a number in the first position\n");
                        address = "Not The Right Address";
                    }
                } while (address == "Not The Right Address");

                string refno = "";
                do
                {
                    refno = GetString("Enter Reference Number: ", "Reference Number is empty or contains letters");
                    for (int i = 0; i < howmany; i++)
                        if (Refno[i] == refno)
                        {
                            Console.WriteLine("Error: Reference number cannot contain letters");
                            refno = "Incorrect";
                        }
                    if (refno == "" || refno == " " || refno.Contains("a") || refno.Contains("b") || refno.Contains("c") ||
                            refno.Contains("d") || refno.Contains("e") || refno.Contains("f") || refno.Contains("g") || refno.Contains("h") ||
                            refno.Contains("i") || refno.Contains("j") || refno.Contains("k") || refno.Contains("l") || refno.Contains("m") ||
                            refno.Contains("n") || refno.Contains("o") || refno.Contains("p") || refno.Contains("q") || refno.Contains("r") ||
                            refno.Contains("s") || refno.Contains("t") || refno.Contains("u") || refno.Contains("v") || refno.Contains("w") ||
                            refno.Contains("x") || refno.Contains("y") || refno.Contains("z"))
                    {
                        Console.WriteLine("Error: Reference number cannot contain letters");
                        refno = "Incorrect";
                    }
                } while (refno == "Incorrect");

                string plan = "";
                do
                {
                    plan = GetString("Current Plan (S, M, L, or XL): ", "Full Name is empty and should be alphabetic characters only");
                    for (int i = 0; i < howmany; i++)
                        if (plan.ToUpper() != "S" && plan.ToUpper() != "M" && plan.ToUpper() != "L" && plan.ToUpper() != "XL")
                        {
                            Console.WriteLine("Error: Plan must be either S, M, L or XL");
                            plan = "Incorrect Plan";
                        }

                } while (plan == "Incorrect Plan");
                Name[howmany] = name;
                Address[howmany] = address;
                Refno[howmany] = refno;
                Plan[howmany] = plan;
                current = howmany;
                howmany++;
            }
            static void Display(string Name, string Address, string Refno, string Plan, ref double PlanData, ref double PlanCharge)
            {
                GetPlan(Plan, ref PlanData, ref PlanCharge);
                Console.WriteLine("\nName: {0} - Reference No: {1}\nAddress: {2}\nMonthly Payment for Plan '{3}':\t\t${4}", Name, Refno, Address, Plan, PlanCharge);
            }
            static void FindCustomer(string[] Name, string[] Address, string[] Refno, string[] Plan, ref int current, int howmany)
            {
                double PlanCharge = 0;
                double PlanData = 0;
                string sname = GetString("Enter the name of the customer you wish to search for: ", "Search Name cannot be empty");
                int position;
                for (position = 0; position < howmany; position++)
                {
                    if (Name[position].ToLower().Contains(sname.ToLower()))
                    {
                        Display(Name[position], Address[position], Refno[position], Plan[position], ref PlanData, ref PlanCharge);
                        string resp = GetString("Is that the one you are looking for (y/n)?", "Y or N only");
                        if (resp.ToLower() == "y")
                        {
                            current = position;
                            break;
                        }
                    }
                }
                if (position == howmany) Console.WriteLine("{0} is not on the customer list", sname);
            }
            static void RemoveCustomer(string[] Name, string[] Address, string[] Refno, string[] Plan, ref int current, ref int howmany)
            {
                double PlanCharge = 0;
                double PlanData = 0;
                Display(Name[current], Address[current], Refno[current], Plan[current], ref PlanData, ref PlanCharge);

                string resp = GetString("Is that the one you want to delete(y/n)? ", "y or n ONLY");
                if (resp.ToLower() == "y")
                {
                    for (int i = current; i < howmany - 1; i++)
                    {
                        Name[i] = Name[i + 1];
                        Address[i] = Address[i + 1];
                        Refno[i] = Refno[i + 1];
                        Plan[i] = Plan[i + 1];
                    }
                    howmany--;
                    current = howmany - 1;
                }
            }
            static string GetPlan(string Plan, ref double PlanData, ref double PlanCharge)
            {
                double data = 0;
                double cost = 0;
                {
                    if (Plan.ToUpper() == "S")
                    {
                        data = 1; cost = 55;
                    }
                    else if (Plan.ToUpper() == "M")
                    {
                        data = 2.5; cost = 70;
                    }
                    else if (Plan.ToUpper() == "L")
                    {
                        data = 6; cost = 95;
                    }
                    else if (Plan.ToUpper() == "XL")
                    {
                        data = 10; cost = 135;
                    }
                    else
                    {
                        Plan = "";
                        data = 0;
                        cost = 0;
                    }

                    PlanData = data;
                    PlanCharge = cost;
                    return Plan;
                }
            }
            static void CalculateDisplayPay(string Name, string Address, string Refno, string Plan, ref int current, int howmany)
            {
                const float EMAIL = 0.02731F, ROUND = 0.009F, WEB = 0.38912F, VIDEO = 3.00373F, MOVIE = 68.26667F, MUSIC = 1.00124F, APP = 34.98667F;
                const int GB = 1024, MONTH = 30, BLOCK = 10;
                // Declare data variables
                int Email = 0, Web = 0, Video = 0, Movie = 0, Music = 0, App = 0;
                // Declare output variable 
                double PlanCharge = 0, PlanData = 0, TEmail = 0, TWeb = 0, TVideo = 0, TMovie = 0, TMusic = 0, TApp = 0, TTotal = 0, NetPay = 0, ExtraBlocks = 0, ExtraDataCost = 0;

                if (Name == "")
                    Console.WriteLine("Please fill out section (a) before attempting to access (c)");
                else
                { // Input Data
                    Console.WriteLine("\n\t\t\tData Calculate\n");
                    Console.WriteLine("In a typical day, how often do you do these activities \nwhile you're not connected to Wi-Fi? \n\n");

                    Display(Name, Address, Refno, Plan, ref PlanData, ref PlanCharge);

                    // Get Emails wrote
                    do
                    {
                        Console.WriteLine("\nEmails: ");
                        Console.WriteLine("0\t5\t25\t50\t100\t250+");
                        Console.Write("How many emails (without attachment) do you send/receive? ");
                        if (int.TryParse(Console.ReadLine(), out Email) == false || Email != 0 && Email != 5 && Email != 25 && Email != 50 && Email != 100 && Email != 250)
                        {
                            Console.WriteLine("\nError: Email Usage must be 0, 5, 25, 50, 100 or 250. Please Try Again...");
                            Email = 99999999;
                        }
                    } while (Email == 99999999);

                    // Get Web Browsing Data
                    do
                    {
                        Console.WriteLine("\nWeb Browsing: ");
                        Console.WriteLine("0\t5\t25\t50\t100\t250+");
                        Console.Write("How many pages do you visit (including Facebook)? ");
                        if (int.TryParse(Console.ReadLine(), out Web) == false || Web != 0 && Web != 5 && Web != 25 && Web != 50 && Web != 100 && Web != 250)
                        {
                            Console.WriteLine("\nError: Web Usage must be 0, 5, 25, 50, 100 or 250. Please Try Again...");
                            Web = 99999999;
                        }
                    } while (Web == 99999999);

                    // Get Videos watched
                    do
                    {
                        Console.WriteLine("\nVideo / Movie streaming: ");
                        Console.WriteLine("0\t5min\t15min\t30min\t45min\t1hr+");
                        Console.Write("How much time do you spend watching videos? ");
                        if (int.TryParse(Console.ReadLine(), out Video) == false || Video != 0 && Video != 5 && Video != 15 && Video != 30 && Video != 45 && Video != 1)
                        {
                            Console.WriteLine("\nError: Video Usage must be 0, 5, 15, 30, 45 or 1. Please Try Again...");
                            Video = 99999999;
                        }
                        if (Video == 1)
                        {
                            Video = 60;
                        }
                    } while (Video == 99999999);


                    // Get HD Movies watched

                    do
                    {
                        Console.WriteLine("\nHD movies: ");
                        Console.WriteLine("0\t1\t2\t3\t5\t15+");
                        Console.Write("How many HD movies do you download? ");
                        if (int.TryParse(Console.ReadLine(), out Movie) == false || Movie != 0 && Movie != 1 && Movie != 2 && Movie != 3 && Movie != 5 && Movie != 15)
                        {
                            Console.WriteLine("\nError: Movie Usage must be 0, 1, 2, 3, 5 or 15. Please Try Again...");
                            Movie = 99999999;
                        }
                    } while (Movie == 99999999);

                    // Get Music streamed
                    do
                    {
                        Console.WriteLine("\nMusic: ");
                        Console.WriteLine("0\t5min\t15min\t30min\t45min\t1hr+");
                        Console.Write("How much music do you stream or download? ");
                        if (int.TryParse(Console.ReadLine(), out Music) == false || Music != 0 && Music != 5 && Music != 15 && Music != 30 && Music != 45 && Music != 1)
                        {
                            Console.WriteLine("\nError: Music Usage must be must be 0, 5, 15, 30, 45 or 1. Please Try Again...");
                            Music = 99999999;
                        }
                        if (Music == 1)
                        {
                            Music = 60;
                        }
                    } while (Music == 99999999);

                    // Get Apps downloaded
                    do
                    {
                        Console.WriteLine("\nApp / Games: ");
                        Console.WriteLine("0\t1\t2\t3\t6\t10+");
                        Console.Write("How many apps or games do you download? ");
                        if (int.TryParse(Console.ReadLine(), out App) == false || App != 0 && App != 1 && App != 2 && App != 3 && App != 6 && App != 15)
                        {
                            Console.WriteLine("\nError: App Usage must be 0, 1, 2, 3, 6, 10. Please Try Again...");
                            App = 99999999;
                        }

                        // Calculate Totals and Monthly Data
                        TApp = APP * App * MONTH / GB;
                        TEmail = EMAIL * Email * MONTH / GB;
                        TWeb = WEB * Web * MONTH / GB;
                        TVideo = VIDEO * Video * MONTH / GB;
                        TMovie = MOVIE * Movie * MONTH / GB;
                        TMusic = MUSIC * Music * MONTH / GB;
                        TTotal = TEmail + TWeb + TVideo + TMusic + TMovie + TApp;

                    } while (App == 99999999);
                    Display(Name, Address, Refno, Plan, ref PlanData, ref PlanCharge);
                    // Monthly Data Usage Total
                    Console.WriteLine("\nBased on your answers, your estimated data usage per Month is: {0:f2}GB\n\n", TTotal + ROUND);

                    // Calculations for payments            
                    if (PlanData < TTotal)
                    {
                        ExtraBlocks = Math.Ceiling((TTotal + ROUND) - PlanData); ;
                    }
                    if (PlanData > TTotal)
                    {
                        ExtraBlocks = 0;
                    }

                    if (PlanData < TTotal)
                    {
                        ExtraDataCost = (Math.Ceiling(((TTotal + ROUND) - PlanData))) * BLOCK;
                    }
                    if (PlanData > TTotal)
                    {
                        ExtraDataCost = 0;
                    }

                    NetPay = Math.Round(PlanCharge + ExtraDataCost);

                    // Monthly Payments
                    GetPlan(Plan, ref PlanData, ref PlanCharge);
                    Console.Write("Monthly Payment for Plan '{0}':\t\t ${1,8:F2} \n", Plan, PlanCharge);
                    Console.Write("Data Plan: {0} GB - Extra Block(s):  {1} GB @ $10.00\n", PlanData, ExtraBlocks);
                    Console.Write("Extra Data Usage:\t\t\t ${0,8:F2} \n", ExtraDataCost);

                    Console.Write("Payment Due:\t\t\t\t ${0,8:F2}", NetPay);


                    // Output results and make sure they are aligned 
                    Console.WriteLine("\n\nEmails\t\t\t({0,5:f2}%)", Math.Round(TEmail / TTotal * 100));
                    Console.WriteLine("General browsing\t({0,5:f2}%)", Math.Round(TWeb / TTotal * 100));
                    Console.WriteLine("Video / movie streaming\t({0,5:f2}%)", Math.Round(TVideo / TTotal * 100));
                    Console.WriteLine("HD Movie\t\t({0,5:f2}%)", Math.Round(TMovie / TTotal * 100));
                    Console.WriteLine("Streaming music\t\t({0,5:f2}%)", Math.Round(TMusic / TTotal * 100));
                    Console.WriteLine("Downloading apps\t({0,5:f2}%)", Math.Round(TApp / TTotal * 100));
                    Console.WriteLine("\n\n");
                }
            }
            static void SaveData(string[] Name, string[] Address, string[] Refno, string[] Plan, int howmany)
            {
                try
                {
                    FileStream fs = new FileStream(@"C:\temp\customer.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    int i;
                    for (i = 0; i < howmany - 1; i++) sw.WriteLine("{0},{1},{2},{3}", Name[i], Address[i], Refno[i], Plan[i]);
                    sw.Write("{0},{1},{2},{3}", Name[i], Address[i], Refno[i], Plan[i]);

                    sw.Close();
                }

                catch (Exception error)
                {
                    Console.WriteLine("Error - cannot create customer.txt file - {0}", error.Message);
                }
            }
            static void LoadData(string[] Name, string[] Address, string[] Refno, string[] Plan, ref int current, ref int howmany)
            {
                try
                {
                    if (howmany != 0)
                    {
                        Console.WriteLine("Warning... All current data will be overrided by new file data");
                        string response = GetString("Do you want to load new data set (y/n)? ", "Invalid - input is y or n");
                        if (response.ToLower() == "n") return;
                    }
                    FileStream fs = new FileStream(@"C:\temp\customer.txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    string[] address = new string[50];
                    string[] name = new string[50];
                    string[] plan = new string[50];
                    string[] refno = new string[50];
                    current = howmany = 0;
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] data = line.Split(',');
                        {
                            Name[howmany] = data[0];
                            Address[howmany] = data[1];
                            Refno[howmany] = data[2];
                            if (data[3].ToUpper() != "S" && data[3].ToUpper() != "M" && data[3].ToUpper() != "L" && data[3].ToUpper() != "XL")
                            {
                                Console.WriteLine("Error: Plan must be either S, M, L or XL. One of the Plans do not equal this value. Please check your txt file.");
                                do
                                {
                                    data[3] = GetString("Current Plan (S, M, L, or XL): ", "Full Name is empty and should be alphabetic characters only");
                                    for (int i = 0; i < howmany; i++)
                                        if (data[3].ToUpper() != "S" && data[3].ToUpper() != "M" && data[3].ToUpper() != "L" && data[3].ToUpper() != "XL")
                                        {
                                            Console.WriteLine("Error: Plan must be either S, M, L or XL");
                                            data[3] = "Incorrect Plan";
                                        }
                                } while (data[3] == "Incorrect Plan");
                            }
                            Plan[howmany] = data[3];
                            current = howmany;
                            howmany++;
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception error)
                {
                    Console.WriteLine("ERROR! can't Open input customer.txt file - {0}", error.Message);
                }
            }

            static void Main()
            {
                // Declare Response
                const int size = 50;
                string response = "a";
                double PlanCharge = 0;
                double PlanData = 0;
                string[] Name = new string[size];
                string[] Refno = new string[size];
                string[] Plan = new string[size];
                string[] Address = new string[size];
                //set all to invalid data
                for (int i = 0; i < size; i++)
                {
                    Name[i] = "Incorrect Name"; Address[i] = "Not The Right Address"; Refno[i] = "Incorrect"; Plan[i] = "Incorrect Plan";
                }
                int current = 0, howmany = 0;
                while (response != "x")
                {
                    // Display Menu
                    Console.WriteLine("\nWhat would you like to do?\n");
                    Console.WriteLine("Add a Customer (a)\nDisplay current customer (d)\nFind a customer (f)\nCalculate and display payment for current customer (c)\nRemove current customer (r)\nSave Data To File (s)\nLoad Data From File (l)\nExit (x)\n");
                    // Get Response
                    response = GetString("Enter your selection (a, d, f, c, r, s, l or x)? ", "\nUnknown selection, option ");
                    // Perform Response
                    switch (response)
                    {
                        case "a":
                        case "A":
                            if (howmany == size) Console.WriteLine("Array is full");
                            else AddCustomer(Name, Address, Refno, Plan, ref current, ref howmany);
                            break;
                        case "d":
                        case "D":
                            if (howmany == 0) Console.Write("No Customer to Display");
                            else Display(Name[current], Address[current], Refno[current], Plan[current], ref PlanData, ref PlanCharge);
                            break;
                        case "f":
                        case "F":
                            if (howmany == 0) Console.WriteLine("There is no Customers to search for");
                            else FindCustomer(Name, Address, Refno, Plan, ref current, howmany);
                            break;

                        case "c":
                        case "C":
                            if (howmany == 0) Console.WriteLine("There is no customers to calculate");
                            else CalculateDisplayPay(Name[current], Address[current], Refno[current], Plan[current], ref current, howmany);
                            break;
                        case "r":
                        case "R":
                            if (howmany == 0) Console.WriteLine("There is no customers to remove");
                            else RemoveCustomer(Name, Address, Refno, Plan, ref current, ref howmany);
                            break;
                        case "s":
                        case "S":
                            if (howmany == 0) Console.WriteLine("There is no record to Write into file");
                            else SaveData(Name, Address, Refno, Plan, howmany);
                            break;

                        case "l":
                        case "L":
                            LoadData(Name, Address, Refno, Plan, ref current, ref howmany);
                            break;
                        case "x":
                        case "X":
                            Console.WriteLine("User selected to exit, option " + response);
                            Environment.Exit(0);
                            break;
                    }
                }
                while (response != "x") ;

            }
        }
    }

