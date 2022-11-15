using System;
using System.Collections.Generic;

namespace Midterm
{
    class TravelAgency
    {
        static void Main(string[] args)
        {
            List<Itinerary> itineraries = new List<Itinerary>();

            Console.WriteLine("Welcome to Algonquin College Student Travel Agency!");

            //Console.Write("\nEnter V to view all itineraries, A to add a new itinerary. \n" +
            //                "      C to change an existing itinerary, and E to exit: ");
            //string action = Console.ReadLine();
            //Console.WriteLine();


            //Write your code here to implement the functionality as required

            Boolean whileLoopFlag = true;

            while(whileLoopFlag)
            {
                Console.Write("\nEnter V to view all itineraries, A to add a new itinerary. \n" +
                            "      C to change an existing itinerary, and E to exit: ");
                string action = Console.ReadLine();
                Console.WriteLine();

                switch (action)
                {
                    case "V":
                        if (itineraries.Count == 0)
                        {
                            // when iteneray doesn't exist in the data
                            Console.WriteLine("No ininerary exits in the system!");
                            Console.WriteLine();
                            break;

                        }else
                        {
                            // when iteneray exists
                            Console.WriteLine("The following iteneraries exist in system: ");
                            for (int i = 0; i < itineraries.Count; i++)
                            {
                                Console.WriteLine($"    {i} - Passenger: {itineraries[i].PassengerName}, Depature: {itineraries[i].DepartureCity}, Arriving: {itineraries[i].ArrivingCity}, Cost: {itineraries[i].Cost}");
                            }
                        }
                        
                        break;

                    case "A":
                        Console.Write("         Enter passenger name: ");
                        string passangerName = Console.ReadLine();

                        Console.Write("         Enter departure city: ");
                        string departureCity = Console.ReadLine();

                        Console.Write("         Enter arriving city: ");
                        string arrivingCity = Console.ReadLine();

                        Itinerary currentPassanger = new Itinerary(passangerName, departureCity, arrivingCity);

                        itineraries.Add(currentPassanger);

                        Console.WriteLine();
                        Console.WriteLine($"    {currentPassanger.PassengerName}'s itinerary has been added to system, Cost: ${currentPassanger.Cost}");

                        break;

                    case "C":
                        Console.Write($"\nEnter the index of the itinerary you want to change (0 to {itineraries.Count}) : ");
                        int selectedIndex = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine();
                        Console.Write($"    You have selected to change {itineraries[selectedIndex].PassengerName}'s itinerary.");

                        Console.WriteLine();
                        Console.Write("         Enter departure city: ");
                        string newDepartureCity = Console.ReadLine();

                        Console.Write("         Enter arriving city: ");
                        string newArrivingCity = Console.ReadLine();


                        itineraries[selectedIndex].ChangeItinerary(newDepartureCity, newArrivingCity);


                        Console.WriteLine();
                        Console.Write($"    {itineraries[selectedIndex].PassengerName}'s itinerary has been changed. ${Itinerary.ChangeFee} change fee was applied.");
                        Console.WriteLine();


                        break;

                    case "E":
                        whileLoopFlag = false;
                        break;

                    default:
                        Console.WriteLine("Invalid entry: Must enter V, A, C, or E");
                        break;

                };



            }

            Console.WriteLine("\nThank you for using Algonquin College Student Travel Agency!");
            Console.WriteLine("Press return key to complete the application");
            Console.ReadLine();
        }
    }
}
