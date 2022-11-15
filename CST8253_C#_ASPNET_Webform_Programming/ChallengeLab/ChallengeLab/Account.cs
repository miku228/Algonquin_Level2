using System;
using System.Collections.Generic;

namespace ChallengeLab
{
	public class Account
	{
		// ** fields **
		private string ownerName;
		// date
		private DateTime dt = DateTime.Now;

		private List<List<string>> checkingActivities = new List<List<string>>();
		private List<List<string>> savingActivities = new List<List<string>>();

		// -- saving accout
		static double interestsRateSaving = 0.03;
		static double withdrowPenaltySaving = 10;

		// -- checking account
		public static double maxWithdrawChecking = 300;


		// ** constructor **
		public Account(string ownerName)
		{
			OwnerName = ownerName;
			// initalize accounts balance
			//CheckingBalance = iCheckingDeposit;
			//SavingBalance = iSavingDeposit;


		}


		// ** properties **

		public string OwnerName
		{
			// only setter
			set { ownerName = value;  }
		}

		public double CheckingBalance { get; set; }
		public double SavingBalance { get; set; }
		public double DailyWithdrawChecking { get; set; }

		public int WithdrawFlag { get; set; }
		public int DailyCapFlag { get; set; }


		public List<List<string>> CheckingActivities {
            get { return checkingActivities; }
            set { checkingActivities = value; }
		}

		public List<List<string>> SavingActivities
		{
			get { return savingActivities; }
			set { savingActivities = value; }
		}
	



		// ** methods **

		public void deposit(int account, double amount)
        {
			if(account == 1)
            {
				CheckingBalance += amount;
				// $amount, date, activity
				//Console.WriteLine("$" + Convert.ToString(amount));
				//Console.WriteLine(dt.ToString("yyyy-mm-dd"));
				//Console.WriteLine("");
				//checkingActivities.Add(new List<string>() { "$", "yyyy-mm-dd", "DEPOSIT" });
				CheckingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "DEPOSIT" });

			}
			else
            {
				SavingBalance += amount * (1 + Account.interestsRateSaving);
				// $amount, date, activity
				SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "DEPOSIT" });
				SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount* Account.interestsRateSaving), dt.ToString("yyyy-mm-dd"), "DEPOSIT: Interests" });
			}
        }

		public void withdraw(int account, double amount)
        {
			// 1 = Checking, 2 = Saving
			if(account == 1)
            {
				// a. withdraw + penalty doesn't exceed current balance
				// b. daily withdraw is below cap
				if (CheckingBalance >= amount && Account.maxWithdrawChecking >= DailyWithdrawChecking + amount)
				{
					CheckingBalance -= amount;
					DailyWithdrawChecking += amount;
					CheckingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "WITHDRAW" });
				}

			}
            else
            {
				// a. withdraw + penalty doesn't exceed current balance
				if (SavingBalance >= amount + Account.withdrowPenaltySaving)
				{
					SavingBalance -= amount + Account.withdrowPenaltySaving;
					SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "WITHDRAW" });
					SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "Penalty" });
				}
				
			}
		}

		public void transfer(int account, double amount)
		{
			// 1 = Checking -> Saving, 2 = Saving -> Checking
			if(account == 1)
            {
				CheckingBalance -= amount;
				SavingBalance += amount;
				CheckingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "TRANSFER: Transfer out" });
				SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "TRANSFER: Transfer in" });
			}
			else
			{
				SavingBalance -= amount + Account.withdrowPenaltySaving;
				CheckingBalance += amount;
				SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "TRANSFER: Transfer out" });
				SavingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "Penalty" });
				CheckingActivities.Add(new List<string>() { "$" + Convert.ToString(amount), dt.ToString("yyyy-mm-dd"), "TRANSFER: Transfer in" });
			}

		}


	}
}

