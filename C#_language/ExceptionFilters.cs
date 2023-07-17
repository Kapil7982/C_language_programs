using System;

namespace BankingSystem
{
    public class InsufficientFundsException : Exception
    {
        public string AccountNumber { get; }
        public decimal RequestedAmount { get; }
        public decimal AvailableBalance { get; }

        public InsufficientFundsException(string accountNumber, decimal requestedAmount, decimal availableBalance)
        {
            AccountNumber = accountNumber;
            RequestedAmount = requestedAmount;
            AvailableBalance = availableBalance;
        }
    }

    public class BankingSystem
    {
        private decimal accountBalance = 1000;

        public void Withdraw(string accountNumber, decimal amount)
        {
            try
            {
                if (amount > accountBalance)
                {
                    throw new InsufficientFundsException(accountNumber, amount, accountBalance);
                }

                accountBalance -= amount;
                Console.WriteLine($"Withdrawal successful. New balance: {accountBalance}");
            }
            catch (InsufficientFundsException ex) when (ex.AccountNumber.StartsWith("S"))
            {
                Console.WriteLine($"Insufficient funds for savings account {ex.AccountNumber}. Requested amount: {ex.RequestedAmount}. Available balance: {ex.AvailableBalance}");
            }
            catch (InsufficientFundsException ex) when (ex.AccountNumber.StartsWith("C"))
            {
                Console.WriteLine($"Insufficient funds for checking account {ex.AccountNumber}. Requested amount: {ex.RequestedAmount}. Available balance: {ex.AvailableBalance}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Insufficient funds for account {ex.AccountNumber}. Requested amount: {ex.RequestedAmount}. Available balance: {ex.AvailableBalance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankingSystem bankingSystem = new BankingSystem();

            // Withdrawal transactions
            bankingSystem.Withdraw("S12345", 500);   // Savings account, sufficient balance
            bankingSystem.Withdraw("C98765", 2000);  // Checking account, insufficient balance
            bankingSystem.Withdraw("X24680", 1000);  // Non-existent account

            Console.ReadLine();
        }
    }
}

// Output of the above program 

// dotnet run ExceptionFilters.cs
// Withdrawal successful. New balance: 500
// Insufficient funds for checking account C98765. Requested amount: 2000. Available balance: 500
// Insufficient funds for account X24680. Requested amount: 1000. Available balance: 500
