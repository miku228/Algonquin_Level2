using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //// initialize list which store activity log
            //List<List<string>> activities = new List<List<string>>();

            //// date
            //DateTime dt = DateTime.Now;

            // flag for loop
            Boolean whileLoop = true;

            int[] accountsSelectable = { 1, 2 };

            double dailyWithdraw = 0;


            Console.WriteLine("Welcome to Algonquin Banking System!");
            Console.WriteLine("");
            

            // 1. prompt the user to enter user name.
            Console.Write("Enter Customer Name: ");
            string userName = Console.ReadLine();

            Account account = new Account(userName);


            while (whileLoop)
            {

                Console.WriteLine("");
                Console.WriteLine("Select  one of the following activities:");
                Console.WriteLine("");
                Console.WriteLine(" 1. Deposit ...");
                Console.WriteLine(" 2. Withdraw ...");
                Console.WriteLine(" 3. Transfer ...");
                Console.WriteLine(" 4. Account Activity Enquiry ...");
                Console.WriteLine(" 5. Balance Enquiry ...");
                Console.WriteLine(" 6. Exit");
                Console.WriteLine("");

                Console.Write("Enter your selection (1 to 6): ");
                int selectedAction = Convert.ToInt32(Console.ReadLine());

                switch (selectedAction)
                {
                    // deposit
                    case 1:
                        Console.WriteLine("");
                        Console.Write("Select account (1 - Checking Account, 2 - Saving Account): ");
                        int dselectedAccount = Convert.ToInt32(Console.ReadLine());

                        // check the input either 1 or 2
                        if(!accountsSelectable.Contains(dselectedAccount)) break;

                        string dselectedAccountFull = dselectedAccount == 1 ? "Checking" : "Saving";

                        Console.WriteLine("");
                        Console.Write("Enter Amount: ");
                        double dAmount = Convert.ToInt32(Console.ReadLine());

                        account.deposit(dselectedAccount, dAmount);

                        double dcurrentBalance = dselectedAccount == 1 ? account.CheckingBalance : account.SavingBalance;

                        // $amount, date, activity
                        //activities.Add(new List<string>() { "$" + Convert.ToString(dAmount), dt.ToString("yyyy-mm-dd"), "Deposit" });
                        Console.WriteLine($"Deposit completed, {dselectedAccountFull} account current balance: ${dcurrentBalance}");

                        break;


                    // withdraw
                    case 2:
                        Console.WriteLine("");
                        Console.Write("Select account (1 - Checking Account, 2 - Saving Account): ");
                        int wselectedAccount = Convert.ToInt32(Console.ReadLine());
                        // check the input either 1 or 2
                        if (!accountsSelectable.Contains(wselectedAccount)) break;

                        string wselectedAccountFull = wselectedAccount == 1 ? "Checking" : "Saving";

                        Console.WriteLine("");
                        Console.Write("Enter Amount: ");
                        double wAmount = Convert.ToInt32(Console.ReadLine());

                        if (wselectedAccount == 1 && Account.maxWithdrawChecking < (wAmount + dailyWithdraw))
                        {
                            // check withdraw doesn't exceed daily cap : Checking
                            Console.WriteLine("");
                            Console.WriteLine($"    Exceed the daily max withdraw amount ${Account.maxWithdrawChecking}");
                            break;
                        }
                        else if(wselectedAccount == 1 && account.CheckingBalance < wAmount)
                        {
                            // check withdraw + penalty doesn't exceed current balance : Checking
                            dailyWithdraw += wAmount;
                            Console.WriteLine("");
                            Console.WriteLine($"    Insufficient fund, {wselectedAccountFull} account current balance ${account.CheckingBalance}");
                            break;
                        
                        }
                        else if(wselectedAccount == 2 && account.SavingBalance < wAmount)
                        {
                            // check withdraw + penalty doesn't exceed current balance : Saving
                            Console.WriteLine("");
                            Console.WriteLine($"    Insufficient fund, {wselectedAccountFull} account current balance ${account.SavingBalance}");
                            break;
                        }
                        else
                        {
                            account.withdraw(wselectedAccount, wAmount);
                            double wcurrentBalance = wselectedAccount == 1 ? account.CheckingBalance : account.SavingBalance;
                            // $amount, date, activity
                            //activities.Add(new List<string>() { "$" + Convert.ToString(wAmount), dt.ToString("yyyy-mm-dd"), "Withdraw" });
                            Console.WriteLine($"Withdraw completed, {wselectedAccountFull} account current balance: ${wcurrentBalance}");

                        }

                        break;

                    // transfer
                    case 3:
                        Console.WriteLine("");
                        Console.Write("Select accounts (1 - from Checking to Saving; 2 - from Saving to Checking): ");
                        int tselectedAccount = Convert.ToInt32(Console.ReadLine());
                        string tselectedAccountFull = tselectedAccount == 1 ? "Checking" : "Saving";

                        Console.WriteLine("");
                        Console.Write("Enter Amount: ");
                        double tAmount = Convert.ToInt32(Console.ReadLine());

                        account.transfer(tselectedAccount, tAmount);

                        // $amount, date, activity
                        //activities.Add(new List<string>() { "$" + Convert.ToString(tAmount), dt.ToString("yyyy-mm-dd"), "Transfer" });
                        Console.WriteLine("");
                        Console.WriteLine("    Transfer completed");
                        break;

                    // Account Activity Enquiry
                    case 4:
                        Console.WriteLine("");
                        Console.WriteLine("Checking Account:");
                        Console.WriteLine("");
                        Console.WriteLine("     Amount  		 Date 			 Activity");
                        Console.WriteLine("     ------ 		 ---- 			  --------");
                       
                        List<List<string>> checkingActivities = account.CheckingActivities;
                        for (int i=0; i< checkingActivities.Count; i++) {
                            Console.WriteLine($"     {checkingActivities[i][0]} 		 {checkingActivities[i][1]} 			  {checkingActivities[i][2]}");
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Saving Account:");
                        Console.WriteLine("");
                        Console.WriteLine("     Amount  		 Date 			 Activity");
                        Console.WriteLine("     ------ 		 ---- 			  --------");

                        List<List<string>> savingActivities = account.SavingActivities;
                        for (int i = 0; i < savingActivities.Count; i++)
                        {
                            Console.WriteLine($"     {savingActivities[i][0]} 		 {savingActivities[i][1]} 			  {savingActivities[i][2]}");
                        }

                        break;

                    // Balance Enquiry
                    case 5:
                        Console.WriteLine("");
                        Console.WriteLine("Current balance:");
                        Console.WriteLine("     Account 				  Balance");
                        Console.WriteLine("     -------- 				  ------");
                        Console.WriteLine($"    Checking 				  ${account.CheckingBalance}");
                        Console.WriteLine($"    Saving 			     	  ${account.SavingBalance}");

                        break;

                    // Exit
                    case 6:
                        whileLoop = false;
                        Console.WriteLine("");
                        Console.WriteLine("Bye~!");
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Invalid selection! Enter 1 - 6 only!");
                        break;


                }

            };


            // 2. prompt input initial Checking and Saving amount
            //Console.Write("Enter " + userName + "'s Initial Checking Deposit Amount(minimum $1,000.00): ");
            //double iCheckingDeposit = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter " + userName + "'s Initial Saving Deposit Amount(minimum $1,000.00): ");
            //double iSavingDeposit = Convert.ToInt32(Console.ReadLine());


            // 3. Deposit
            //Console.Write("Enter an account to deposit Checking or Saving(C/S): ");
            //string selectedDepositAccount = Console.ReadLine().ToLower();

            //Console.Write("Enter an amount to deposit: ");
            //double depositAmount = Convert.ToInt32(Console.ReadLine());




            //Console.WriteLine("");
            //Console.WriteLine("You can do deposit, withdraw and transfer.");
            //Console.Write("What do you want to do(D/W/T): ");
            //string selectedAction = Console.ReadLine().ToLower();
            //Console.WriteLine($"After {month} month, {customers[i].Ownername}'s account (#{customers[i].AccountNumber}), has a balance of: $ {string.Format("{0:#,0.##}", customers[i].Balance)}");






        }
    }
}

