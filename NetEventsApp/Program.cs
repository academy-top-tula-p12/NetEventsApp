using NetEventsApp;

BankAccount account = new BankAccount(1000);
account.Notify += ConsoleWriter;
account.Notify += (object sender, AccountEventArgs e) =>
    {
        var colorOld = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;

        if (sender is BankAccount account)
        {
            Console.WriteLine($"Summa transaction: {e.Sum}");
            Console.WriteLine($"Balance: {account.Balance}");
            Console.WriteLine($"Message {e.Message}");
        }

        Console.ForegroundColor = colorOld;
    };

account.AddMoney(500);
account.TakeMoney(800);

account.Notify -= ConsoleWriter;

account.TakeMoney(800);

void ConsoleWriter(object sender, AccountEventArgs e)
{
    if(sender is BankAccount account)
    {
        Console.WriteLine($"Summa transaction: {e.Sum}");
        Console.WriteLine($"Balance: {account.Balance}");
        Console.WriteLine($"Message {e.Message}");
    }
}