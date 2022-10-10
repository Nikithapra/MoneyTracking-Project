//MONEY TRACKING SYSTEM -PROJECT
using Newtonsoft.Json;

//reading from file to List items

string fileName = (@"C:\Users\vigop\source\repos\MoneyTracking-Project\json\MoneyTracking.json");
string jsonString = File.ReadAllText(fileName);
List<MoneyTracking> items = JsonConvert.DeserializeObject<List<MoneyTracking>>(jsonString);

Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine(" Press show all items to show Balance and read from file:");
//creating obj for class
Transactions t = new Transactions();

while (true)
{
    // int Balance=0;
    int Balance = t.Bal(items);
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n");
    Console.WriteLine("Welcome to MoneyTracking");
    Console.WriteLine("------------------------------");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"You have {Balance} kr in your Account.!! ");
    Console.ResetColor();
    Console.WriteLine("Pick an option");
    Console.WriteLine("(1).Show  all Items(Income/Expense)");
    Console.WriteLine("(2).Add new (Income/ Expense) ");
    Console.WriteLine("(3).Edit Item (Edit,Remove)");
    Console.WriteLine("(4).Save and Quit from File");

    string s = Console.ReadLine();
    int input = int.Parse(s);

    //calling functions
    if (input == 4)
    {
        t.Save(items);

        break;
    }
    if (input == 2)
    {
        t.AddItem(items);
    }
    if (input == 3)
    {
        t.Edit(items);
    }
    if (input == 1)
    {
        t.ShowItems(items);
    }
}

