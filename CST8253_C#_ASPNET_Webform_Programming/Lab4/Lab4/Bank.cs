using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    class Bank
    {
        static void Main(string[] args)
        {
            // initialize list which store customer instances
            List<Account> customers = new List<Account>();


            // 1.prompt the user to enter the number of months the customer will keep the money in account.
            Console.Write("Enter the number of months to deposit: ");
            int month = Convert.ToInt32(Console.ReadLine());

            while (true)
            {

                // 2.prompt the user to enter the customer’s name.
                string cName;
                Console.WriteLine("");
                Console.Write("Enter Customer Name: ");
                cName = Console.ReadLine();

                // check the user input Enter or not
                if (cName == "")
                {
                    break;
                }

                // 3.prompt the user to enter an initial deposit amount for the saving account.
                Console.Write("Enter " + cName + "'s Initial Deposit Amount(minimum $1,000.00): ");
                int iDeposit = Convert.ToInt32(Console.ReadLine());

                // 4.prompt the user to enter a monthly deposit amount to the saving account
                Console.Write("Enter " + cName + "'s Monthly Deposit Amount(minimum $50.00): ");
                int mDeposit = Convert.ToInt32(Console.ReadLine());
                
                // add Account instance to list called customers
                customers.Add(new Account(cName, iDeposit, mDeposit));

            }

            //  task6: update accout balance each months
            for(int i = 0; i < customers.Count; i++)
            {
                for(int l = 0; l < month; l++)
                {
                    // calculate monthly fee
                    customers[i].DeductMonthlyFee();
                    // add monthly interest
                    customers[i].AddMonthlyInterest();
                    // add monthly deposit
                    customers[i].AddMonthlyDeposit();

                }
                Console.WriteLine($"After {month} month, {customers[i].Ownername}'s account (#{customers[i].AccountNumber}), has a balance of: $ {string.Format("{0:#,0.##}", customers[i].Balance)}");

            }

        }

    }
}

