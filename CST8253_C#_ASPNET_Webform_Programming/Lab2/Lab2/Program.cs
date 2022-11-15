using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string inputNum;
            //string userAnswer;
            
            //List<int> nums = new List<int>();
            //List<int> evenNums = new List<int>();
            //List<int> oddNums = new List<int>();

            // loop until user wants to stop it.
            while (true)
            {
                // initialize variables
                string inputNum;
                string userAnswer;

                List<int> nums = new List<int>();
                List<int> evenNums = new List<int>();
                List<int> oddNums = new List<int>();


                // loop until user input enter
                do
                {

                    Console.Write("Enter an Integer > ");
                    inputNum = Console.ReadLine();

                    // check input whether enter or not
                    if (inputNum != "")
                    {
                        // convert string to int
                        nums.Add(Convert.ToInt32(inputNum));
                    }


                }
                while (inputNum != "");

                // check whether nums list has item(s) or not
                if (nums.Count == 0)
                {
                    Console.Write("You did not enter any integer \n");
                }
                else
                {
                    Console.Write("The maximum integer you entered is: " + nums.Max() + "\n");
                    Console.Write("The minimum integer you entered is: " + nums.Min() + "\n");

                    // make lists for odd and even number(s)
                    foreach (var v in nums)
                    {
                        if (v % 2 == 0)
                        {
                            // even
                            evenNums.Add(v);

                        }
                        else
                        {
                            // odd
                            oddNums.Add(v);
                        }
                    }
                    // console for odd number(s)
                    Console.Write("The number of odd integer(s) you entered is: " + oddNums.Count + "\n");
                    Console.Write("The sum of all odd integer(s) you entered is: " + oddNums.Sum() + "\n");
                    Console.Write("The average of all odd integer(s) you entered is: " + oddNums.Average() + "\n");

                    // console for even number(s)
                    Console.Write("The number of even integer(s) you entered is: " + evenNums.Count + "\n");
                    Console.Write("The sum of all even integer(s) you entered is: " + evenNums.Sum() + "\n");
                    Console.Write("The average of even odd integer(s) you entered is: " + evenNums.Average() + "\n");

                }

                Console.Write("Play again(Y/N)? >");
                userAnswer = Console.ReadLine().ToLower();

                if (userAnswer == "y")
                {
                    // repeat again
                    Console.Write("Play again: 1 \n");
                }
                else
                {
                    // stop it
                    Console.Write("Bye \n");
                    break;
                }

            };



            

        }
    }
}

