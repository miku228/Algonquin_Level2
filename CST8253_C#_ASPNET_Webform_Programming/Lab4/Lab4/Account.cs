using System;
namespace Lab4
{
	public class Account
	{
		// ** fields **
		static double monthlyFee = 4.0;
		static double monthlyInterestRate = 0.0025;
		static double minimumInitialBalance = 1000;
		static double minimumMonthDeposit = 50;

		// ** constructors **
		public Account(string name, double iDeposit, double mDeposit)
		{
			Ownername = name;
			Balance = iDeposit;
			MonthlyDeposit = mDeposit;

			Random rnd = new Random();
			AccountNumber = '9' + rnd.Next(10000).ToString();

		}


		// ** properties ** 
		public string Ownername { get; set; }
		public double Balance { get; set; }
		public string AccountNumber { get; set; }
		public double MonthlyDeposit { get; set; }



		// ** methods **

		// calculate after deposit(task5)
		public void CalcuDeposit(double deposit) {
			double balance = this.Balance;
			balance += deposit;
			Balance = balance;
		}

		// calculate after withdraw(task5)
		public void CalcuWithdraw(double withdraw)
		{
			double balance = this.Balance;
			balance -= withdraw;
			Balance = balance;

		}

		// deduct monthly fee(task6)
		public void DeductMonthlyFee()
		{
			Balance -= Account.monthlyFee;
		}

		// add monthly interest(task6)
		public void AddMonthlyInterest()
		{
			Balance += Balance * Account.monthlyInterestRate;
		}

		// add monthly deposit(task6)
		public void AddMonthlyDeposit()
		{
			Balance += MonthlyDeposit;
			//Console.WriteLine($"After Monthly Deposit: {Balance}");
		}

	}
}

