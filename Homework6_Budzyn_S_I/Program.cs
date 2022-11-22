namespace Homework6
{
    class Program
    {
        public static void Main(string[] args)
        {// main має делегувати роботу на інші класи! Логічно все це перенести в клас меню.
            while (true)
            {
                Console.WriteLine("Select action:");
                Console.WriteLine("Add info from file (enter add)");
                Console.WriteLine("Print data for every apartments (enter print-all)");
                Console.WriteLine("Print data for specific apartment (enter print-sp)");
                Console.WriteLine("Find the biggest debtor (enter debtor)");
                Console.WriteLine("Find all apartments where energy wasn`t used (enter zero)");
                Console.WriteLine("To quit enter q");
                string? answer = Console.ReadLine();
                // Краще використовувати switch і кожну дію оформляти окремою функцією. Значно прозоріший був би код.
                if (answer == "add")
                {
                    AddInfo("info.txt");
                }
                else if (answer == "print-all")
                {
                    using (EnergyContext context = new EnergyContext())
                    {
                        Console.WriteLine("1 quarter:");
                        Print(context.Apartments.ToArray());
                        Console.WriteLine(new String('_', 50));
                        Console.WriteLine("2 quarter:");
                        Print(context.Apartments.ToArray());
                        Console.WriteLine(new String('_', 50));
                        Console.WriteLine("3 quarter:");
                        Print(context.Apartments.ToArray());
                        Console.WriteLine(new String('_', 50));
                        Console.WriteLine("4 quarter:");
                        Print(context.Apartments.ToArray());
                    }
                }
                else if (answer == "print-sp")
                {
                    int.TryParse(Console.ReadLine(), out int num);
                    using (EnergyContext context = new EnergyContext())
                    {
                        Console.WriteLine("1 quarter:");
                        Print(context.Apartments.Where(ap => ap.Number == num).ToArray());
                        Console.WriteLine(new String('_', 50));
                        Console.WriteLine("2 quarter:");
                        Print(context.Apartments.Where(ap => ap.Number == num).ToArray());
                        Console.WriteLine(new String('_', 50));
                        Console.WriteLine("3 quarter:");
                        Print(context.Apartments.Where(ap => ap.Number == num).ToArray());
                        Console.WriteLine(new String('_', 50));
                        Console.WriteLine("4 quarter:");
                        Print(context.Apartments.Where(ap => ap.Number == num).ToArray());
                    }
                }
                else if (answer == "debtor")
                {
                    Dictionary<uint, uint> debtors = new Dictionary<uint, uint>();
                    using (EnergyContext context = new EnergyContext())
                    {
                        foreach (var data in context.Apartments)
                        {
                            if (!debtors.ContainsKey(data.Number))
                            {
                                debtors.Add(data.Number, 0);
                            }
                            
                           
                            debtors[data.Number] += (data.FirstMonthValue2 - data.FirstMonthValue2);

                            debtors[data.Number] += (data.SecondMonthValue2 - data.SecondMonthValue2);

                            debtors[data.Number] += (data.FirstMonthValue2 - data.SecondMonthValue2);
                            
                        }
                        Console.WriteLine($"The biggest debtor is: {context.Apartments.Where(ap => ap.Number == debtors.Max().Key).First().Surname}");
                    }
                    
                }
                else if (answer == "zero")
                {
                    Dictionary<uint, uint> debtors = new Dictionary<uint, uint>();
                    using (EnergyContext context = new EnergyContext())
                    {
                        foreach (var data in context.Apartments)
                        {
                            if (!debtors.ContainsKey(data.Number))
                            {
                                debtors.Add(data.Number, 0);
                            }

                            debtors[data.Number] += (data.FirstMonthValue2 - data.FirstMonthValue2);

                            debtors[data.Number] += (data.SecondMonthValue2 - data.SecondMonthValue2);

                            debtors[data.Number] += (data.FirstMonthValue2 - data.SecondMonthValue2);

                        }
                        foreach (var debtor in debtors)
                        {
                            if (debtor.Value == 0)
                            {
                                Console.WriteLine($"Zero debtor: {context.Apartments.Where(ap => ap.Number == debtor.Key).First().Surname}");
                            }
                        }
                    }
                }
                else if (answer == "q")
                {
                    break;
                }

            }
        }
        public static void AddInfo(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {                
                string firstlLine = streamReader.ReadLine();
                int.TryParse(firstlLine.Split(",")[0].Trim(), out int apartAmount);
                int.TryParse(firstlLine.Split(",")[1].Trim(), out int quartNum);
                for (int i = 0; i < apartAmount; i++)
                {
                    string[] apartInfo = streamReader.ReadLine().Split(",");
                    uint.TryParse(apartInfo[0].Trim(), out uint apartNumber);
                    string address = apartInfo[1].Trim();
                    string surname = apartInfo[2].Trim();
                    uint.TryParse(apartInfo[3].Trim(), out uint firstMonthValue1);
                    uint.TryParse(apartInfo[4].Trim(), out uint firstMonthValue2);
                    uint.TryParse(apartInfo[5].Trim(), out uint secondMonthValue1);
                    uint.TryParse(apartInfo[6].Trim(), out uint secondMonthValue2);
                    uint.TryParse(apartInfo[7].Trim(), out uint thirdMonthValue1);
                    uint.TryParse(apartInfo[8].Trim(), out uint thirdMonthValue2);
                    DateTime.TryParse(apartInfo[9].Trim(), out DateTime firstDate);
                    DateTime.TryParse(apartInfo[10].Trim(), out DateTime secondDate);
                    DateTime.TryParse(apartInfo[11].Trim(), out DateTime thirdDate);
                    using (EnergyContext context = new EnergyContext())
                    {
                        ApartmentData apartmentData = new ApartmentData() 
                        {
                            Number = apartNumber, 
                            Address = address, 
                            QuarterNumber = quartNum,
                            FirstMonthValue1 = firstMonthValue1, 
                            FirstMonthValue2 = firstMonthValue2, 
                            SecondMonthValue1 = secondMonthValue1,
                            SecondMonthValue2 = secondMonthValue2,
                            Surname = surname,
                            ThirdMonthValue1 = thirdMonthValue1,
                            ThirdMonthValue2 = thirdMonthValue2,
                            FirstDate = firstDate,
                            SecondDate = secondDate,    
                            ThirdDate = thirdDate
                        };
                        if (quartNum == 1)
                        {
                            context.Apartments.Add(apartmentData);
                        }
                        else if (quartNum == 2)
                        {
                            context.Apartments.Add(apartmentData);
                        }
                        else if (quartNum == 3)
                        {
                            context.Apartments.Add(apartmentData);
                        }
                        else
                        {
                            context.Apartments.Add(apartmentData);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
        public static void Print(params ApartmentData[] apartments)
        {
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var ap in apartments)
                {
                    string firstMonth;
                    string secondMonth;
                    string thirdMonth;

                    if (ap.QuarterNumber == 1)
                    {
                        firstMonth = "January";
                        secondMonth = "February";
                        thirdMonth = "March";

                    }
                    else if (ap.QuarterNumber == 2)
                    {
                        firstMonth = "April";
                        secondMonth = "May";
                        thirdMonth = "June";

                    }
                    else if (ap.QuarterNumber == 3)
                    {
                        firstMonth = "July";
                        secondMonth = "August";
                        thirdMonth = "September";

                    }
                    else
                    {
                        firstMonth = "October";
                        secondMonth = "November";
                        thirdMonth = "December";

                    }

                    writer.WriteLine($"Apartment number - {ap.Number,10}, " +
                    $"Surname - {ap.Surname,10}, " +
                    $"{firstMonth,10} - {ap.FirstMonthValue1,10}/{ap.FirstMonthValue2,10} ({ap.FirstDate,10}), " +
                    $"{secondMonth,10} - {ap.SecondMonthValue1,10}/{ap.SecondMonthValue2,10} ({ap.SecondDate,10}), " +
                    $"{thirdMonth,10} - {ap.ThirdMonthValue1,10}/{ap.ThirdMonthValue2,10} ({ap.ThirdDate,10}).");
                }
            }
        }
    }
}
