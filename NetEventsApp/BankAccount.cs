using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEventsApp
{
    class BankAccount
    {
        public int Balance { get; private set; }

        AccountHandler? notify;

        // add/remove
        public event AccountHandler Notify
        {
            add
            {
                notify += value;
                Console.WriteLine($"handler {value.Method.Name} add");
            }
            remove
            {
                notify -= value;
                Console.WriteLine($"handler {value.Method.Name} remove");
            }
        }

        public BankAccount(int sum = 0) => Balance = sum;

        public void AddMoney(int sum)
        {
            Balance += sum;
            notify?.Invoke(this, new AccountEventArgs(sum, $"Balance add {sum} rub."));
        }

        public void TakeMoney(int sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                notify?.Invoke(this, new(-sum, $"Balance del {sum} rub."));
            }
            else
                notify?.Invoke(this, new(-sum, $"Balance less than {sum} rub."));


        }


        public delegate void AccountHandler(object sender, AccountEventArgs e);

    }

    class AccountEventArgs
    {
        public string? Message { get; }
        public int Sum { get; }

        public AccountEventArgs(int sum, string? message)
        {
            Message = message;
            Sum = sum;
        }
    }
}
