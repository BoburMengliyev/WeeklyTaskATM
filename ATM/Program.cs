using System;

class BankAccount
{
    public string FullName { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; private set; }

    public BankAccount(string fullName, string accountNumber)
    {
        FullName = fullName;
        AccountNumber = accountNumber;
        Balance = 0;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"{amount} so'm hisobingizga qo‘shildi.");
        }
        else
        {
            Console.WriteLine("Noto‘g‘ri miqdor.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Noto‘g‘ri miqdor.");
        }
        else if (amount > Balance)
        {
            Console.WriteLine("Hisobda yetarli mablag‘ mavjud emas.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"{amount} so'm yechildi. Qolgan balans: {Balance} so'm.");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Hisobingizda {Balance} so'm mavjud.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ismingizni kiriting: ");
        string name = Console.ReadLine();

        Console.Write("Hisob raqamingizni kiriting: ");
        string accNumber = Console.ReadLine();

        BankAccount userAccount = new BankAccount(name, accNumber);
        int choice;

        do
        {
            Console.WriteLine("\n--- ATM Menyusi ---");
            Console.WriteLine("1. Pul qo‘yish");
            Console.WriteLine("2. Pul yechish");
            Console.WriteLine("3. Balansni ko‘rish");
            Console.WriteLine("0. Chiqish");
            Console.Write("Tanlang (0-3): ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Qo‘yiladigan summa: ");
                    decimal deposit = Convert.ToDecimal(Console.ReadLine());
                    userAccount.Deposit(deposit);
                    break;

                case 2:
                    Console.Write("Yechiladigan summa: ");
                    decimal withdraw = Convert.ToDecimal(Console.ReadLine());
                    userAccount.Withdraw(withdraw);
                    break;

                case 3:
                    userAccount.ShowBalance();
                    break;

                case 0:
                    Console.WriteLine("Dasturdan chiqildi. Xayr!");
                    break;

                default:
                    Console.WriteLine("Noto‘g‘ri tanlov. Qaytadan urinib ko‘ring.");
                    break;
            }

        } while (choice != 0);
    }
}
