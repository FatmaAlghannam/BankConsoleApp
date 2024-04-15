// See https://aka.ms/new-console-template for more information
// Banking Mini Project : 15-4-24
using System;
class BankAccount
{
  
    private string name;
    private int accountNumber;
    private double balance;
    private const int maxTransaction = 50;
    private double[] transactions = new double[maxTransaction];
    private int transactionCount = 0;

   
    public BankAccount(string name, int accountNumber, double initialBalance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }
    //deposit:
    public void Deposit(double amount)
    {
        balance += amount;
        transactions[transactionCount++] = amount;
        Console.WriteLine($"   Deposit successful \n  New Balance: {balance} ");
    }

    //withdraw: 
    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            transactions[transactionCount++] = -amount;
            Console.WriteLine($" Withdrawal successful \nNew Balance: {balance}");
        }
        else
        {
            Console.WriteLine(" Insufficient funds.");
        }
    }

    //view balance:
    public void ViewBalance()
    {
        Console.WriteLine($" Current Balance: {balance}");
    }

    //transaction history:
    public void ViewTransactionHistory()
    {
        Console.WriteLine("\n  Transaction History: ");
        for (int i = 0; i < transactionCount; i++)
        {
            Console.WriteLine(transactions[i] > 0 ? $"Deposit: +${transactions[i]}" : $"Withdrawal: -${-transactions[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("                          Welcome to the Bank Console Application \n");
        Console.WriteLine("                ---------------------------------------------------        ");
        Console.WriteLine("   Enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("   Enter Your Account Number:");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("   Enter Your Balance Amount:");
        double balance = double.Parse(Console.ReadLine());

        // BankAccount
        BankAccount account = new BankAccount(name, accountNumber, balance);

        int choice;
        do
        {
            Console.WriteLine("\n  Menu:");
            Console.WriteLine("1.  Deposit");
            Console.WriteLine("2.  Withdraw");
            Console.WriteLine("3.  View Balance:");
            Console.WriteLine("4.  View Transaction History");
            Console.WriteLine("5.  Exit");
            Console.WriteLine("\n  Enter your choice:");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("   Enter Your Deposit Amount: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                case 2:
                    Console.WriteLine("   Enter Withdrawal Amount: ");
                    double withdrawalAmount = double.Parse(Console.ReadLine());
                    account.Withdraw(withdrawalAmount);
                    break;
                case 3:
                    account.ViewBalance();
                    break;
                case 4:
                    account.ViewTransactionHistory();
                    break;
                case 5:
                    Console.WriteLine("   Thank you Custoumer! \n ");
                    break;
                default:
                    Console.WriteLine("   Invalid choice. Try again !");
                    break;
            }
        } while (choice != 5);
    }
}