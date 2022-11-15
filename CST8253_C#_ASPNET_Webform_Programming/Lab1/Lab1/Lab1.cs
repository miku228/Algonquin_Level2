using System;

namespace Lab_1
{
    class Lab1
    {
        static void Main(string[] args)
        {
            // Crete a string variable for use later
            // string name;
            int name;

            // Display a prompt to the user
            Console.Write("What is your name? > ");

            // Capture the user's response
            //name = Console.ReadLine();
            name = int.Parse(Console.ReadLine());

            // Display a string literal combined with the value of the string variable
            // What does the "\n" do?
            Console.Write("Hello " + name + "\n");

            // Waits for the user press enter
            Console.Write("Thank you for run my first lab!");
            Console.Read();


        }
    }
}

