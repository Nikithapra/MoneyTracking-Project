//Monye tracking Operations
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

public class Transactions
{
    private int Balance;
    public int sumincome;
    public int sumexpense;
    public void ShowItems(List<MoneyTracking> items)
    {
        Console.WriteLine(" Pick an Option:");
        Console.WriteLine("------------------");
        Console.WriteLine("(1) Show all Items(Inc/Exp) \n" + "(2) Show only Incomes \n" + "(3) Show only Expenses");
        string option1 = Console.ReadLine();
        //creating obj for class
        MoneyTracking item1 = new MoneyTracking();

        //show all transactions
        if (option1 == "1")
        {
            //sorting list by  month,amount 
            List<MoneyTracking> sortitems = items.OrderBy(it => it.Month)
                                     .ThenBy(it => it.Amount)
                                      .ThenBy(it => it.Title)
                                     .ToList();
            //displaying list
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Month".PadRight(10) + "Trans-ID".PadRight(10)+ "Title".PadRight(10) + "TransType(Inc,Exp)".PadRight(20) + "Amount".PadRight(10));

            Console.WriteLine("--------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Green;

           
            foreach (MoneyTracking t in sortitems)
            {
                Console.WriteLine(t.Month.PadRight(10) + t.id.ToString().PadRight(10) + t.Title.PadRight(15) +
                t.Transtype.PadRight(14) + t.Amount.ToString().PadRight(10));
            }
        }
        Console.ResetColor();
        if (option1 == "2")
        {
            //show only Incomes
            
            List<MoneyTracking> displayincome = items.Where(MoneyTracking => MoneyTracking.Transtype.Equals("Income")).ToList();
            
            int sumincome = displayincome.Sum(s => s.Amount);
          
            Console.ForegroundColor = ConsoleColor.Green;
            //displaying list
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Month".PadRight(10) + "Trans-ID".PadRight(10) + "Title".PadRight(9) + "TransType(Incomes)".PadRight(20) + "Amount".PadRight(10));

            Console.WriteLine("---------------------------------------------------------------");

            foreach (var t in displayincome)
            {
                Console.WriteLine(t.Month.PadRight(10) + t.id.ToString().PadRight(10) + t.Title.PadRight(15) +
                t.Transtype.PadRight(15) + t.Amount.ToString().PadRight(10));
            }
        }

        if (option1 == "3")
        {
            //show only Expenses
            List<MoneyTracking> displayexpense = items.Where(MoneyTracking => MoneyTracking.Transtype.Contains("Expense")).ToList();
            int sumexpense= displayexpense.Sum(s => s.Amount);

            Balance = sumincome - sumexpense;
            //displaying list
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Month".PadRight(10) + "Trans-ID".PadRight(10)+ "Title".PadRight(9) + "TransType(Expe)".PadRight(12) + "Amount".PadRight(10));

            Console.WriteLine("-------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (MoneyTracking t in displayexpense)
            {

                Console.WriteLine(t.Month.PadRight(10) + t.id.ToString().PadRight(10) + t.Title.PadRight(10) +
                t.Transtype.PadRight(17) + t.Amount.ToString().PadRight(10));

            }
        }
        Console.ResetColor();
    }
    public void AddItem(List<MoneyTracking> items)
    {
        int balpre;
        //creating object for class
        MoneyTracking item = new MoneyTracking();

        Console.WriteLine("Pick an Option");
        Console.WriteLine("(1) Add Income items");
        Console.WriteLine(" (2)Add Expense items");

        string option1 = Console.ReadLine();
        //adding income
        if (option1 == "1")
        {
            Console.WriteLine("Enter the Id:");
            item.id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the  Title of transaction:");
            item.Title = Console.ReadLine();
            Console.WriteLine("Enter the  Month of transaction:");
            item.Month = Console.ReadLine();
            Console.WriteLine("Enter the transaction(Income):");
            item.Transtype = Console.ReadLine();
            Console.WriteLine("Enter the Amount:");
            item.Amount = int.Parse(Console.ReadLine());

            //Adding to list items
            items.Add(item);
            Console.WriteLine("Items Added To List");
            Balance = Balance + item.Amount;
            int Balance1 = Balance;

            //sorting list by  month,amount 
            List<MoneyTracking> sortitems = items.OrderBy(it => it.Month)
                                     .ThenBy(it => it.Amount)
                                     .ToList();
            //displaying list
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Month".PadRight(10) + "Trans-ID".PadRight(10) + "Title".PadRight(10) + "TransType(Inc,Exp)".PadRight(20) + "Amount".PadRight(10));

            Console.WriteLine("------------------------------------------------------");
            foreach (MoneyTracking t in sortitems)
            {
                Console.WriteLine(t.Month.PadRight(10) + t.id.ToString().PadRight(10) + t.Title.PadRight(15) +
              t.Transtype.PadRight(17) + t.Amount.ToString().PadRight(10));
            }
            //save file
            string JSONresult = JsonConvert.SerializeObject(sortitems);
            string path = @"C:\Users\vigop\source\repos\moneytrack operations\moneytrack operations\json\MoneyTracking.json";
            File.WriteAllText(path, JSONresult);

        }
        //adding Expense
        if (option1 == "2")
        {
            Console.WriteLine("Enter the Trans-ID:");
            item.id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the  Title of transaction:");
            item.Title = Console.ReadLine();
            Console.WriteLine("Enter the  Month of transaction:");
            item.Month = Console.ReadLine();
            Console.WriteLine("Enter the transaction(Expense):");
            item.Transtype = Console.ReadLine();
            Console.WriteLine("Enter the Amount:");
            item.Amount = int.Parse(Console.ReadLine());

            //Adding to list items
            items.Add(item);
            Console.WriteLine("Items Added To List");
            Balance = Balance - item.Amount;

            //sorting list by  month,amount 
            List<MoneyTracking> sortitems = items.OrderBy(it => it.Month)
                                     .ThenBy(it => it.Amount)
                                     .ToList();
            //displaying list
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Month".PadRight(12) + "Trans-ID".PadRight(10) + "Title".PadRight(10) + "TransType(Inc,Exp)".PadRight(20) + "Amount".PadRight(10));

            Console.WriteLine("------------------------------------------------------------");
            foreach (MoneyTracking t in sortitems)
            {
                Console.WriteLine(t.Month.PadRight(10) + t.id.ToString().PadRight(10) + t.Title.PadRight(15) +
              t.Transtype.PadRight(17) + t.Amount.ToString().PadRight(10));
            }
            //save file
            string JSONresult = JsonConvert.SerializeObject(sortitems);
            string path = @"C:\Users\vigop\source\repos\moneytrack operations\moneytrack operations\json\MoneyTracking.json";
            File.WriteAllText(path, JSONresult);

        }

    }

   //edit list
   public void Edit(List<MoneyTracking> items)
    {
        int prebal;
        Console.WriteLine(" Pick an Option:\n" + "(1)Edit items\n" + "(2) Remove items");
        string option1 = Console.ReadLine();

        if (option1 == "1")
        {
            Console.WriteLine("Enter Trans-ID to be edited");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Which fields in item  you want to edit:\n" +
               "(1) Trans-ID\n "+"(2) Transtitle\n"+" (3) Transtype\n" +"(4) Amount \n" + "(5) Month");
           Console.WriteLine("pick  an option");
            string opt = Console.ReadLine();

            foreach (var t in items)
            {
                if (t.id == id && opt == "1")
                {
                    Console.WriteLine("Enter Replaced Trans-ID:");
                    int rid = int.Parse(Console.ReadLine());
                    t.id = rid;
                }

                if (t.id == id && opt == "2")
                {
                    Console.WriteLine("Enter replaced item Title ");
                    string y = Console.ReadLine();
                    t.Title = y;
                }
                if (t.id==id && opt == "5")
                {
                    Console.WriteLine("Enter replaced item Month ");
                    string m1 = Console.ReadLine();
                    t.Month = m1;
                }
                if (t.id == id && opt == "3")
                {
                    Console.WriteLine("Enter replaced item transtype ");
                    string ty = Console.ReadLine();
                    t.Transtype = ty;
                    if(t.Transtype=="Income")
                        Balance=Balance+t.Amount;
                    else if(t.Transtype == "Expense")
                        Balance=Balance-t.Amount;
                }
                if (t.id == id && opt == "4")
                {
                    prebal = t.Amount;
                    Console.WriteLine("Enter replaced item Amount ");
                    int amt = int.Parse(Console.ReadLine());
                    t.Amount = amt;
                    if (t.Transtype == "Expense")
                    {
                        if (prebal > t.Amount)
                            Balance = Balance + (prebal - t.Amount);
                        else
                            Balance = Balance - (t.Amount - prebal);
                        int Balance1 = Balance;
                    }
                    else if (t.Transtype == "Income")
                    {
                        if (prebal > t.Amount)
                            Balance = Balance - (prebal - t.Amount);
                        else
                            Balance = Balance +(t.Amount - prebal);
                        int Balance1 = Balance;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your Balance:" + Balance);
                    Console.ResetColor();
                }
            }
            //sorting list by  month,amount 
            List<MoneyTracking> sortitems = items.OrderBy(it => it.Month)
                                     .ThenBy(it => it.Amount)
                                     .ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("Items after edited");
            //displaying list
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Month".PadRight(10) + "Trans-ID".PadRight(10) + "Title".PadRight(12) + "TransType".PadRight(12) + "Amount".PadRight(10));

            Console.WriteLine("----------------------------------------------------");

            foreach (var t in sortitems)
            {
                Console.WriteLine(t.Month.PadRight(12) + t.id.ToString().PadRight(10) + t.Title.PadRight(12) +
               t.Transtype.PadRight(13) + t.Amount.ToString().PadRight(10));

            }
            Console.ResetColor();
            //save file
            string JSONresult = JsonConvert.SerializeObject(items);
            string path = @"C:\Users\vigop\source\repos\moneytrack operations\moneytrack operations\json\MoneyTracking.json";
            File.WriteAllText(path, JSONresult);

        }

        //remove item
        if (option1 == "2")
        {
            Console.WriteLine("Enter item Id to remove");
             int  rem = int.Parse(Console.ReadLine());

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].id == rem)
                {
                    items.RemoveAt(i);
                }
            }
          
            List<MoneyTracking> sortitems = items.OrderBy(it => it.Month)
                                     .ThenBy(it => it.Amount)
                                     .ToList();
            Console.ForegroundColor= ConsoleColor.Green;
            //displaying list
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Month".PadRight(10) + "Trans-ID".PadRight(10) + "Title".PadRight(9) + "TransType".PadRight(12) + "Amount".PadRight(10));

            Console.WriteLine("----------------------------------------------");


            foreach (var t in sortitems)
            {
                Console.WriteLine(t.Month.PadRight(10)+t.id.ToString().PadRight(10)  + t.Title.PadRight(10) +
               t.Transtype.PadRight(13) + t.Amount.ToString().PadRight(10));

            }
            Console.ResetColor();
            //save file
            string JSONresult = JsonConvert.SerializeObject(items);
            string path = @"C:\Users\vigop\source\repos\moneytrack operations\moneytrack operations\json\MoneyTracking.json";
            File.WriteAllText(path, JSONresult);

        }
    }

    //saving to file using JSON
    public void Save(List<MoneyTracking> items)
    {
        //sorting list by  month,amount 
        List<MoneyTracking> sortitems = items.OrderBy(it => it.Month)
                                 .ThenBy(it => it.Amount)
                                  .ThenBy(it => it.Title)
                                 .ToList();
        string JSONresult = JsonConvert.SerializeObject(items);
        string path = @"C:\Users\vigop\source\repos\moneytrack operations\moneytrack operations\json\MoneyTracking.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
        }
        else if (!File.Exists(path))
        {
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
                Console.WriteLine(JSONresult);
                Console.ReadKey();
                Console.WriteLine(File.ReadAllText(path));
            }
        }

    }
   
    //displaying Balance
    public int Bal(List<MoneyTracking> items)
    {
        List<MoneyTracking> displayincome = items.Where(MoneyTracking => MoneyTracking.Transtype.Equals("Income")).ToList();

        //calculating sum of income and expense 
        int sumincome = displayincome.Sum(s => s.Amount);
        List<MoneyTracking> displayexpense = items.Where(MoneyTracking => MoneyTracking.Transtype.Contains("Expense")).ToList();
        int sumexpense = displayexpense.Sum(s => s.Amount);
        //calculating Balance
        Balance = sumincome - sumexpense;
          
        return Balance;
    }

}

