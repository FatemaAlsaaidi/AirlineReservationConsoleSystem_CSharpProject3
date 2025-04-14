﻿using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;

namespace AirlineReservationConsoleSystem_CSharpProject3
{
    internal class Program
    {   // global variables and arraies for flight ....... 
        static int Max_Flight = 2;
        static int FlightCounter = 0;
        static string[] flightCode_A = new string[Max_Flight];
        static string[] fromCity_A = new string[Max_Flight];
        static string[] toCity_A = new string[Max_Flight];
        static DateTime[] departureTime_A = new DateTime[Max_Flight];
        static int[] duration_A = new int[Max_Flight];
        static int[] SeatsNum_A = new int[Max_Flight];
        static int[] SeatReserved_A = new int[Max_Flight];
        static int[] price_A = new int[Max_Flight];

        // flag to validate the user input 
        static bool isValid = false;
        // check if exist
        static bool ISFound = true;

        // variables and arraies Passenger Booking Functions section
        static int BookingCounter = 0;
        static string[] PassengerName_A = new string[100];
        static string[] BookingFlightCode_A = new string[100];
        static string[] GenerateBookingID_A = new string[100];
        static int tickets = 0;

        //                                =====================Startup & Navigation=============

        // 1. display welcome message method..........
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
        }
        // 2. show main menu method
        public static int ShowMainMenu()
        {
            int option = 0;
            do
            {
                // Just to clear the screen
                Console.Clear();
                //Print the menu lists
                Console.WriteLine("Airline Reservation System");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. Display All Flights");
                Console.WriteLine("3. Find Flight By Code");
                Console.WriteLine("4. Update Flight Departure");
                Console.WriteLine("5. Cancel Flight Booking");
                Console.WriteLine("6. Book Flight");
                Console.WriteLine("7. Validate Flight Code");
                Console.WriteLine("8. Generate Booking ID");
                Console.WriteLine("9. Display Flight Details");
                Console.WriteLine("10.Search Bookings By Destination");
                Console.WriteLine("11. Calculate Fare");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter the option: ");
                string input = Console.ReadLine();
                try
                {
                    option = int.Parse(input);// Attempt to parse the input
                    isValid = true; // If parsing is successful, set isValid to true
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // Wait for user to acknowledge the message
                    isValid = false; // Keep isValid false to repeat the loop
                }
            }while(!isValid); // Continue looping until valid input is received

            return option;
        }

        // 3. Exit Application method
        public static void ExitApplication()
        {
            Console.WriteLine("Thanks! Have Happy Day!");
        }
        // 4. Add Flight information method
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int SeatsNum)
        {
            // If all validations pass, save the data
            flightCode_A[FlightCounter] = flightCode;
            fromCity_A[FlightCounter] = fromCity;
            toCity_A[FlightCounter] = toCity;
            departureTime_A[FlightCounter] = departureTime;
            duration_A[FlightCounter] = duration;
            SeatsNum_A[FlightCounter] = SeatsNum;

        }
        //                    ==========================Flight and Passenger Management (5–8) ==================
        //5. Display All Flights method 
        public static void DisplayAllFlights()
        {
            Console.WriteLine("All Available Flight Information ");
            // Loop through all flights up to the current number of valiable flight
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is avilable
                if (SeatReserved_A[i] <= SeatsNum_A[i])
                {
                    Console.WriteLine($"Avilable Flight {i + 1}: ");
                    // Display all information of avilable flight
                    Console.WriteLine($"Flight Code: {flightCode_A[i]}");
                    Console.WriteLine($"From City: {fromCity_A[i]}");
                    Console.WriteLine($"To City: {toCity_A[i]}");
                    Console.WriteLine($"Departure Time: {departureTime_A[i]}");
                    Console.WriteLine($"Duration : {duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats"); // Number of Avilabe seats on specific flight
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats"); // display how many number of seat are reserve in th flight
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats"); // display how many of seats are remaine
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }

            Console.WriteLine("All Not Available Flight Information ");
            bool isFound = false; // reset and use local variable
                                  // Loop through all flights up to the current number of not valiable flight
            for (int i = 0; i < FlightCounter; i++)
            {
                // check if flight is not available
                if (SeatReserved_A[i] >= SeatsNum_A[i])
                {
                    isFound = true;
                    // display the information of not available flight
                    Console.WriteLine($"Unavailable Flight {i + 1}: ");
                    Console.WriteLine($"Flight Code: {flightCode_A[i]}");
                    Console.WriteLine($"From City: {fromCity_A[i]}");
                    Console.WriteLine($"To City: {toCity_A[i]}");
                    Console.WriteLine($"Departure Time: {departureTime_A[i]}");
                    Console.WriteLine($"Duration : {duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats");
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats");
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats");
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }

            if (!isFound)
            {
                Console.WriteLine("There is no flight that is fully booked.");
            }
        }

        //6. Find Flight By Code
        public static bool FindFlightByCode(string code)
        {
            for (int i = 0; i < FlightCounter; i++) 
            { 
                if (code == flightCode_A[i])
                {
                    Console.WriteLine($"Flight Code: {flightCode_A[i]}");
                    Console.WriteLine($"From City: {fromCity_A[i]}");
                    Console.WriteLine($"To City: {toCity_A[i]}");
                    Console.WriteLine($"Departure Time: {departureTime_A[i]}");
                    Console.WriteLine($"Duration : {duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats"); // Number of Avilabe seats on specific flight
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats"); // display how many number of seat are reserve in th flight
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats"); // display how many of seats are remaine
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }

            return true;

        }
        //7. Update Flight Departure
        public static DateTime UpdateFlightDeparture(ref DateTime departure)
        {
            int index = 0;
            Console.WriteLine("Enter the flight code: ");
            string FlightCode = Console.ReadLine();
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCode_A[i] == FlightCode)
                {
                    index = i;
                }
                
            }

            return departureTime_A[index] = departure;
        }
        // 8. CancelFlightBooking(out string passengerName) 
        //public static string CancelFlightBooking(out string passengerName)
        //{

        //}

        //                    ========================= Passenger Booking Functions =============================
        //9. Book Flight +  Generate Booking ID
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            int index = 0;
            string bookingID = GenerateBookingID(passengerName);
            PassengerName_A[BookingCounter] = passengerName;
            BookingFlightCode_A[BookingCounter] = flightCode;
            GenerateBookingID_A[BookingCounter] = bookingID;
            Console.WriteLine("How many tickets do you want");
            int tickets = int.Parse(Console.ReadLine());

            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCode_A[i] == flightCode)
                {
                    SeatReserved_A[i] = SeatReserved_A[i] + tickets; // Resserved seat for every tickets
                    break;
                }
            }
            

        }

        // 
        // 10. Validate Flight Code
        public static bool ValidateFlightCode(string flightCode)
        {
            bool InExist = false;
            for (int i = 0; i< FlightCounter; i++)
            {
                if (flightCode_A[i] == flightCode)
                {
                    Console.WriteLine("The flight code exist");
                    InExist = true;
                }
                else
                {
                    Console.WriteLine("The flight code dose not exist");
                    InExist = false;
                }
            }

            return InExist;
        }
        // 11.  Generate Booking ID
        public static string GenerateBookingID(string passengerName)
        {
            //generate a random number
            Random random = new Random();
            string randomNumber = random.Next(1, 100).ToString();
            string BookingID = passengerName + randomNumber;
            return BookingID;
        }

        // 12.  Display Flight Details
        public static void DisplayFlightDetails(string code)
        {
            int PassengerNumber = 0;
            for (int i = 0; i < FlightCounter; i++) 
            {
                if (flightCode_A[i] == code)
                {
                    for (int j = 0; j < BookingCounter; j++) 
                    {
                        if (BookingFlightCode_A[j] == code)
                        {
                            PassengerNumber++;
                        }
                    }

                    Console.WriteLine($"Flight Code: {flightCode_A[i]}");
                    Console.WriteLine($"From City: {fromCity_A[i]}");
                    Console.WriteLine($"To City: {toCity_A[i]}");
                    Console.WriteLine($"Duration: {duration_A[i]}");
                    Console.WriteLine($"Departure Time: {departureTime_A[i]}");
                    Console.WriteLine($"Number of Passenger: {PassengerNumber} ");


                }
                else
                {
                    Console.WriteLine("Can not found this code");
                }
                Console.WriteLine("Passenger name with booking code: ");
                for(int k=0; k<BookingCounter; k++)
                {
                    if (BookingFlightCode_A[k] == code)
                    {
                        Console.WriteLine($"Pasender Name: {PassengerName_A[k]}");
                        Console.WriteLine($"Pasender Code: {BookingFlightCode_A[k]}");

                    }
                }

            }

        }
        // 13.  Search Bookings By Destination
        public static void SearchBookingsByDestination(string toCity)
        {
            int ToCityIndex = 0;
            for (int i = 0; i < FlightCounter; i++) 
            {
                if (toCity_A[i] == toCity)
                {
                    ToCityIndex = i;
                }
            }

            for(int i = 0;i < BookingCounter; i++)
            {
                if (flightCode_A[ToCityIndex] == BookingFlightCode_A[i])
                {
                    Console.WriteLine(PassengerName_A[i]);
                    Console.WriteLine(GenerateBookingID_A[i]);
                    Console.WriteLine("----------------------------------------------");
                }
                
            }

            
        }
        //                  ==========================Function Overloading ========================
        //14. CalculateFare(int basePrice, int numTickets)
        public static int CalculateFare(int basePrice, int numTickets)
        {
            int TotalFarePrice = basePrice * numTickets;
            return TotalFarePrice;
        }

        public static double CalculateFare(double basePrice, int numTickets)
        {
            double TotalFarePrice = basePrice * numTickets;
            return TotalFarePrice;
        }

        public static double CalculateFare(int basePrice, int numTickets, int discount)
        {
 
            double discountAmount = (basePrice / 100) * discount;
            double TotalFarePrice = (basePrice * numTickets) - discount;
            return TotalFarePrice;
        }
        //                   ========================= System Utilities & Final Flow ===========================

        //  1. Start System method 
        public static void StartSystem()
        {
            // calling DisplayWelcomeMessage() function 
            DisplayWelcomeMessage();

            // Wait for user to press any key before continuing
            Console.ReadLine();

            // use while to repate the ShowMainMenu() to show the menu in every one of the feature in the menu break; 
            while (true)
            {
                int option = ShowMainMenu();

                // Declare variables to store singe value of user input in case 1 
                string flight_Code = null;
                string from_City = null;
                string to_City = null;
                int Fly_Price=0;
                DateTime departure_Time;
                int duration_1 = 0;
                int Seats_Num = 0;
                char ChoiceChar = 'y';
                bool AddMore = true;
                int traies = 0;

                // Declare variables to store singe value of user input in case 6

                bool BookingMore = true;

                switch (option)
                {
                    // add flight 
                    case 1:
                        while (AddMore && FlightCounter < Max_Flight)
                        {
                            Console.WriteLine($"Enter flight {FlightCounter + 1} Information");
                            // Flight Code Input..
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                // ask user to input Flight Code data and store this data in flight_Code variable 
                                Console.WriteLine("Enter Flight Code :");
                                flight_Code = Console.ReadLine();

                                // flightCode input validation 
                                // check if the input flight code is not null and display the message to the user to enter the valid valis code input
                                if (string.IsNullOrWhiteSpace(flight_Code))
                                {
                                    Console.WriteLine("Flight code cannot be empty.");
                                    isValid = false;
                                    traies++;
                                }
                                else
                                {
                                    isValid = true;
                                    traies = 0;
                                }

                                // (Optional) Check if flight code already exists
                                for (int i = 0; i < FlightCounter; i++)
                                {
                                    if (flightCode_A[i] == flight_Code)
                                    {
                                        Console.WriteLine("A flight with this code already exists.");
                                        isValid = false;
                                        traies++;

                                    }
                                    else
                                    {
                                        isValid = true;
                                        traies = 0;
                                    }

                                }

                                if (traies > 3)
                                {
                                    Console.WriteLine("Failed to provide a valid flight code after 3 tries.");
                                    return;
                                }

                            } while (!isValid && traies <= 3); // if the input is not vlidate repet ask the user 

                            

                            // From City Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                //Ask user to input the from city data and temprorly store this data in from_city data
                                Console.WriteLine("Enter From City :");
                                from_City = Console.ReadLine();


                                // fromCity input validation 
                                if (string.IsNullOrWhiteSpace(from_City))
                                {
                                    Console.WriteLine("From city names cannot be empty.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }
                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // To City Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter To City :");
                                to_City = Console.ReadLine();

                                // fromCity input validation 
                                if (string.IsNullOrWhiteSpace(to_City))
                                {
                                    Console.WriteLine("Trom city names cannot be empty.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }

                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // Departure time input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter the departure time (e.g., 2025-04-12 14:30):");
                                string input = Console.ReadLine();

                                if (DateTime.TryParse(input, out departure_Time))
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid format! Please enter a valid date and time.");
                                    isValid = false;
                                }

                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // Duration Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter duration:");
                                string DurationInput = Console.ReadLine();

                                // Duration input validation 
                                if (int.TryParse(DurationInput, out duration_1))
                                {
                                    if (duration_1 <= 0)
                                    {
                                        Console.WriteLine("Duration must be greater than zero.");
                                        isValid = false;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                    isValid = false;
                                }
                            } while (!isValid); // if the input is not vlidate repet ask the user 


                            // Number of seats input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter the Number of seats:");
                                Seats_Num = int.Parse(Console.ReadLine());
                                //seatsNum input validation
                                if (Seats_Num <= 0)
                                {
                                    Console.WriteLine("Number of seats must be greater than zero.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }

                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            

                            // check is all inputs data is valid or not 
                            if (isValid)
                            {
                                // store all inputs data in the array 
                                AddFlight(flightCode: flight_Code, fromCity: from_City, toCity: to_City, departureTime: departure_Time, duration: duration_1, SeatsNum: Seats_Num);
                                Console.WriteLine("Flight added successfully!");
                                FlightCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Flight added faild!");
                                break;

                            }
                            //ask user if want to add more flight information 
                            Console.WriteLine("Do you want to add more flight information?! (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            // use if statement to deal with ChoiceChar input if y or n
                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                // use if instead to check also if FlightCounter is equal or not the Max_Flight
                                if (FlightCounter == Max_Flight)
                                {
                                    Console.WriteLine("Can Not Add More Flight Information");
                                    AddMore = false; 
                                }
                                else
                                {
                                    AddMore = true; // display AddMore as true if FlightCounter does not equal Max_Flight and it is aable to add more flight information.
                                }
                            }
                            else
                            {
                                AddMore = false; // display AddMore as false is user do not add more flight information 
                            }
                            Console.ReadLine();
                        }
                        
                        break;
                    // display all flight
                    case 2:
                        DisplayAllFlights();
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    //Find Flight By Code
                    case 3:
                        Console.WriteLine("Enter the code of Flight : ");
                        string code = Console.ReadLine();
                        FindFlightByCode(code);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    //Update Flight Departure
                    case 4:
                        Console.WriteLine($" Update Flight Departure of Flight : ");
                        DateTime departure = DateTime.Parse(Console.ReadLine());
                        UpdateFlightDeparture(ref departure);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();

                        break;
                    // CancelFlightBooking
                    case 5:
                        // CancelFlightBooking(out string passengerName) 
                        break;
                    // Book Flight +  GenerateBookingID
                    case 6:
                        while (BookingMore)
                        {
                            int FlightIndex = 0;
                            Console.WriteLine("Enter passenger Name :");
                            string passengerName_Input = Console.ReadLine();

                            Console.WriteLine("Enter Flight Code: ");
                            string flightCode_Input = Console.ReadLine();
                            for (int i = 0; i < FlightCounter; i++)
                            {
                                if (flightCode_A[i] == flightCode_Input)
                                {
                                    FlightIndex = i;
                                    break;
                                }
                            }

                            if (flightCode_A[FlightIndex] == flightCode_Input)
                            {
                                if (BookingCounter < SeatsNum_A[FlightIndex])
                                {
                                    BookFlight(passengerName: passengerName_Input, flightCode: flightCode_Input);
                                    Console.WriteLine("Flight booking successfully!");
                                    BookingCounter++;

                                }
                                else
                                {
                                    Console.WriteLine("No available seats on this flight.");
                                    BookingMore = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Flight code can not found it");
                                BookingMore = false;
                            }
                            //ask user if want to Booking more  
                            Console.WriteLine("Do you want to bookimg more flight information?! (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            // use if statement to deal with ChoiceChar input if y or n
                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                // Check if any flights still have available seats
                                bool hasAvailableSeats = false;
                                for (int i = 0; i < FlightCounter; i++)
                                {
                                    if (BookingCounter < SeatsNum_A[i])
                                    {
                                        hasAvailableSeats = true;
                                        break;
                                    }
                                }

                                if (!hasAvailableSeats)
                                {
                                    Console.WriteLine("Cannot book more flights. All are fully booked.");
                                    BookingMore = false;
                                }
                            }
                            else
                            {
                                BookingMore = false; // display AddMore as false is user do not booking more flight 
                            }
                            Console.ReadLine();
                        } 

                        break;
                    // Validate Flight Code
                    case 7:
                        Console.WriteLine("Enter the flight code :");
                        string flightCodeInput = Console.ReadLine();
                        ValidateFlightCode(flightCodeInput);
                        Console.ReadKey();
                        break;
                    // DisplayFlightDetails
                    case 8:
                        Console.WriteLine("Enter the the flight code: ");
                        string flightCode = Console.ReadLine();
                        DisplayFlightDetails(flightCode);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();


                        break;
                    //  Search Bookings By Destination
                    case 9:
                        Console.WriteLine("Enter the To City name:");
                        string ToCityInput = Console.ReadLine();
                        SearchBookingsByDestination(ToCityInput);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    //  Function Overloading
                    case 10:
                        double price1 = 0;
                        int price2 = 0;
                        int TicketNumber = 0;
                        int discount;

                        Console.Write("Enter the flight price: ");
                        price1 = double.Parse(Console.ReadLine());
                        price2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("How many ticket do you want: ");
                        int tickets = int.Parse(Console.ReadLine());


                        int totalFare = CalculateFare(price2, tickets);
                        double totalFare = CalculateFare(price1, tickets);
                        Console.WriteLine("Total fare is: " + totalFare);

                        Console.ReadKey();


                        break;

                    case 0:
                        //calling ExitApplication() function
                        ExitApplication();
                        //using return to stop the whole method thus, stop whole program 
                        return;


                    default:
                        // // Display an message for invalid user input 
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }

        }

        //                    ======================= main method ==============================

        // 1. main method 
        static void Main(string[] args)
        {
            StartSystem();
        }
    }
}
