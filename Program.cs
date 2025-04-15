using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;
using System.Reflection;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Diagnostics;

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
        static string [] Ticket_Price_A = new string[Max_Flight];

        // flag to validate the user input 
        static bool isValid = false;
        // check if exist
        static bool ISFound = true;

        // variables and arraies Passenger Booking Functions section

        static int BookingCounter = 0;
        static string[] PassengerName_A = new string[100];
        static string[] BookingFlightCode_A = new string[100];
        static string[] GenerateBookingID_A = new string[100];
        static int [] booking_tickets = new int[100];
        

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
                Console.WriteLine("7. Display Flight Details");
                Console.WriteLine("8.Search Bookings By Destination");
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
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int SeatsNum, double TicketPrice)
        {
            // If all validations pass, save the data
            flightCode_A[FlightCounter] = flightCode;
            fromCity_A[FlightCounter] = fromCity;
            toCity_A[FlightCounter] = toCity;
            departureTime_A[FlightCounter] = departureTime;
            duration_A[FlightCounter] = duration;
            SeatsNum_A[FlightCounter] = SeatsNum;
            Ticket_Price_A[FlightCounter] = TicketPrice;

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
        // 8. CancelFlightBooking(out string passengerName)  + ConfirmAction("string");
        public static void CancelFlightBooking(out string passengerName)
        {
            int index = 0;
            passengerName = ""; // // Initialize the passenger name
            // Search for the passenger's booking by name
            for (int i = 0;i < BookingCounter; i++)
            {
                if (PassengerName_A[i] == passengerName)
                {
                    index = i; //Store the index of the passenger booking 
                }
            }
            // Ask user to confirm the cancellation
            bool res = ConfirmAction("Cancel Flight Booking");
            if (res) 
            {
                // Shift all elements after the cancelled booking one position to the left
                for (int i = index; i < BookingCounter; i++)
                {
                    
                    PassengerName_A[i] = PassengerName_A[i + 1];
                    GenerateBookingID_A[i] = GenerateBookingID_A[i + 1];
                    BookingFlightCode_A[i] = BookingFlightCode_A[i + 1];
                    SeatReserved_A[i] = SeatReserved_A[i + 1];
                }
                // Decrease the total booking count by one
                BookingCounter--;
                Console.WriteLine("Cancel successfully");
            }
            else
            {
                Console.WriteLine("Cancel unsuccessful!");
            }
        }

        //                    ========================= Passenger Booking Functions =============================
        //9. Book Flight +  Generate Booking ID + CalculateFare
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        { 

            int index = 0;
            string price = "";
            string TotalPrice = "";

            
            Console.WriteLine("How many tickets do you want");
            int tickets = int.Parse(Console.ReadLine());

            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCode_A[i] == flightCode)
                {
                    ISFound = true;
                    index = i;
                    SeatReserved_A[i] = SeatReserved_A[i] + tickets; // Resserved seat for every tickets
                    if (SeatReserved_A[i] <= SeatsNum_A[i]) 
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                        break;
                }
                else
                {
                    ISFound = false;
                }
            }

            if (isValid)
            {
                string bookingID = GenerateBookingID(passengerName);
                PassengerName_A[BookingCounter] = passengerName;
                BookingFlightCode_A[BookingCounter] = flightCode;
                GenerateBookingID_A[BookingCounter] = bookingID;
                booking_tickets[BookingCounter] = tickets;


                for (int i=0; i< FlightCounter; i++)
                {
                    if (flightCode_A[i] == flightCode)
                    {
                        price = Ticket_Price_A[i];
                    }
                         
                }
                

                Console.Write("Do you want to add a discount? (yes/no): ");
                string addDiscount = Console.ReadLine().ToLower();

                if (addDiscount == "yes")
                {
                    int discount = 3;

                    int basePriceint= int.Parse(price);
                    double total = CalculateFare(basePriceint, booking_tickets[BookingCounter], discount);
                    TotalPrice = total.ToString();


                }
                else
                {
                    // Try parsing as double first to check if base price is decimal
                    if (price.Contains("."))
                    {
                        double basePriceDouble = double.Parse(price);
                        double total = CalculateFare(basePriceDouble, booking_tickets[BookingCounter]);
                        TotalPrice = total.ToString();

                    }
                    else
                    {
                        int basePriceInt = int.Parse(price);
                        int total = CalculateFare(basePriceInt, booking_tickets[BookingCounter]);
                        TotalPrice = total.ToString();


                    }
                }
                Console.WriteLine("Booking Successfully");
                Console.WriteLine("===========================================")
                Console.WriteLine("Detail of Your Booking :");
                Console.WriteLine();
                Console.WriteLine($"passenger Name : {PassengerName_A[BookingCounter]}");
                Console.WriteLine($"Code of flight You booking : {BookingFlightCode_A[BookingCounter]}");
                Console.WriteLine($"Number of tickets : {booking_tickets[BookingCounter]}");
                Console.WriteLine($" Total Price: {TotalPrice}");


                

            }
            else
            {
                Console.WriteLine("Booking Unsuccessfully");
            }

            if (ISFound == false)
            {
                Console.WriteLine("Flight code do not exist");
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
//<<<<<<< HEAD
//            Random random = new Random();
//            string randomNum = random.Next(1, 100).ToString();
//            string BookingID = passengerName + randomNum;

           
//=======
//            //generate a random number
            Random random = new Random();
            string randomNumber = random.Next(1, 100).ToString();
            string BookingID = passengerName + randomNumber;
//>>>>>>> 6517a507f108c8373baeb9bdd72a23b3e935be96
            return BookingID;
        }

        // 12.  Display Flight Details
        public static void DisplayFlightDetails(string code)
        {
//<<<<<<< HEAD
//            for (int i = 0; i < FlightCounter; i++)
//            {
//                if (flightCode_A[i] == code)
//                {
//                    int countPassengerNumber = 0;
//                    for (int j = 0; j < count_seat; j++)
//                    {
//                        if (BookingFlightCode_A[j] == flightCode_A[i])
//                        {
//                            countPassengerNumber++;
//                        }
//                    }
//                    Console.WriteLine($"The flight code: {flightCode_A[i]}");
//                    Console.WriteLine($"From city: {fromCity_A[i]}");
//                    Console.WriteLine($"To city: {toCity_A[i]}");
//                    Console.WriteLine($"duration: {duration_A[i]}");
//                    Console.WriteLine($"departure Time: {departureTime_A[i]}");
//                    Console.WriteLine($"Number of passengers: {countPassengerNumber}");
//                    Console.WriteLine("===============================================");
//                    Console.WriteLine("passenger code: ");
//                }
//            }
//            for (int j = 0; j < BookingCounter; j++)
//            {
//                if (flightCode_A[j] == code)
//                {
//                    Console.WriteLine($"passenger name: {PassengerName_A[j]}");
//                    Console.WriteLine($"passenger code: {PassengerGenerateBookingID_A[j]}");
//                    Console.WriteLine("=================================================");
//                }
//            }
//        }
//=======
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
//>>>>>>> 6517a507f108c8373baeb9bdd72a23b3e935be96

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
        // 17.  Confirm Action 
        public static bool ConfirmAction(string action)
        {
            while (true)
            {
                Console.WriteLine($"{action} confirm (y/n):");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    char response = char.ToLower(input[0]);

                    if (response == 'y') return true;
                    if (response == 'n') return false;
                }

                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        }
        //  18. Start System method 
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
                DateTime departure_Time = DateTime.MinValue;
                int duration_1 = 0;
                int Seats_Num = 0;
                double Ticket_Price = 0;
                char ChoiceChar = 'y';
                bool AddMore = true;
                int traies = 0;

                // case 3
                string code3 = "";
                bool findanother = true;
                // case 4
                
                // Declare variables to store singe value of user input in case 6

                bool BookingMore = true;
                string passengerName_Input = null; //declare passengername variable 
                string flightCode_Input = null;

                switch (option)
                {
                    // add flight 
                    case 1:
                        while (AddMore && FlightCounter < Max_Flight)
                        {
                            Console.WriteLine($"Enter flight {FlightCounter + 1} Information");
                            // Flight Code Input..
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            try
                            {
                                do
                                {
                                    //Ask user to enter the flight code
                                    Console.WriteLine("Enter Flight Code :");
                                    flight_Code = Console.ReadLine();

                                    // validate the flight code input
                                    if (string.IsNullOrWhiteSpace(flight_Code))
                                    {
                                        Console.WriteLine("Flight code cannot be empty.");
                                        isValid = false;
                                        traies++;
                                        continue; // try agine
                                    }

                                    // validate if th code exist or not
                                    bool codeExists = false;
                                    for (int i = 0; i < FlightCounter; i++)
                                    {
                                        if (flightCode_A[i] == flight_Code)
                                        {
                                            Console.WriteLine("A flight with this code already exists. Try again.");
                                            codeExists = true;
                                            break;
                                        }
                                    }

                                    if (codeExists)
                                    {
                                        isValid = false;
                                        traies++;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }

                                }
                                while (!isValid && traies < 3); // iteration while isvalid is true and tries ia less than 3

                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid flight code after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                            }


                            traies = 0;

                            // From City Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            try
                            {
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
                                        traies++;
                                        continue;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }
                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user 

                                if (!isValid) // after traies 3 time and still the input is not validate
                                {
                                    Console.WriteLine("Failed to provide a valid From city after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                                isValid = false;
                                traies++;
                            }
                            // ressigne the traies variavle as 0
                            traies = 0;
                            // To City Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            try
                            {
                                do
                                {
                                    Console.WriteLine("Enter To City :");
                                    to_City = Console.ReadLine();

                                    // fromCity input validation 
                                    if (string.IsNullOrWhiteSpace(to_City))
                                    {
                                        Console.WriteLine("to city names cannot be empty.try agind");
                                        isValid = false;
                                        traies++;
                                        continue;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }

                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid to city after 3 tries.");
                                    return;
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                                isValid = false;
                                traies++;
                            }

                            traies = 0;
                            // Departure time input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            try
                            {
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
                                        Console.WriteLine("Invalid format! Please enter a valid date and time. try agine");
                                        isValid = false;
                                        traies++;
                                        continue;
                                    }
                                   

                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user 
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid date and time after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                                isValid = false;
                                traies++;
                            }

                            traies = 0;
                            // Duration Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            try
                            {

                                do
                                {
                                    Console.WriteLine("Enter duration:");
                                    string DurationInput = Console.ReadLine();

                                    // Duration input validation 
                                    if (int.TryParse(DurationInput, out duration_1))
                                    {
                                        if (duration_1 <= 0)
                                        {
                                            Console.WriteLine("Duration must be greater than zero. tray agine");
                                            isValid = false;
                                            traies++;
                                            continue ;
                                        }
                                        else
                                        {
                                            isValid = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter a duration valid number. tray agine");
                                        isValid = false;
                                        traies++;
                                    }
                                  
                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user 
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a duration valid number after 3 tries.");
                                    return;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                                isValid = false;
                                traies++;
                            }
                            traies = 0;

                            // Number of seats input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            try
                            {

                                do
                                {
                                    Console.WriteLine("Enter the Number of seats:");
                                    Seats_Num = int.Parse(Console.ReadLine());
                                    //seatsNum input validation
                                    if (Seats_Num <= 0)
                                    {
                                        Console.WriteLine("Number of seats must be greater than zero. tray agine");
                                        isValid = false;
                                        traies++;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }
                                    

                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user 
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid number of seat after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                                isValid = false;
                                traies++;
                            }
                            traies = 0;
                            // input of ticket price
                            try
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter the ticket price: ");
                                        Ticket_Price = double.Parse(Console.ReadLine());

                                        if (Ticket_Price > 0)
                                        {
                                            isValid = true;
                                        }


                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("there is unexpected error ");
                                        isValid = false;
                                        traies++;

                                    }
                                    
                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid number of seat after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                                isValid = false;
                                traies++;
                            }

                            // check is all inputs data is valid or not 
                            if (isValid)
                            {
                                // store all inputs data in the array 
                                AddFlight(flightCode: flight_Code, fromCity: from_City, toCity: to_City, departureTime: departure_Time, duration: duration_1, SeatsNum: Seats_Num, TicketPrice: Ticket_Price);
                                //Console.ReadKey();
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
                        while (findanother)
                        {
                            try
                            {
                                do
                                {
                                    //Ask user to enter the flight code
                                    Console.WriteLine("Enter Flight Code :");
                                    code3 = Console.ReadLine();

                                    // validate the flight code input
                                    if (string.IsNullOrWhiteSpace(code3))
                                    {
                                        Console.WriteLine("Flight code cannot be empty.");
                                        isValid = false;
                                        traies++;
                                        continue; // try agine
                                    }

                                    // validate if th code exist or not
                                    bool codeExists = false;
                                    for (int i = 0; i < FlightCounter; i++)
                                    {
                                        // if staement to compare the values
                                        if (flightCode_A[i] == code3)
                                        {
                                            codeExists = true;
                                            break;
                                        }
                                    }
                                    // take action if CodeExist variable has true value
                                    if (codeExists)
                                    {
                                        isValid = true; // put is valid as true if the value of codeExist is also true 

                                    }
                                    else
                                    {
                                        isValid = false;
                                        traies++;

                                    }

                                }
                                while (!isValid && traies < 3);
                                // exist if Failed to provide a valid flight code after 3 tries.
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid flight code after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                                traies++;
                            }
                            // if isValid falg is true that mean we can use code varible as input in FindFlightByCode function
                            if (isValid)
                            {
                                FindFlightByCode(code3); // call findFlightFunction()
                                Console.WriteLine("\nPress any key to return to the menu...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("code dose not exist");
                                continue;
                            }
                            
                           
                            //ask user if want to find onthor flight information '
                            Console.WriteLine("Do you want to anthor flight information (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            // use if statement to deal with ChoiceChar input if y or n
                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                findanother = true;
                            }
                            else
                            {
                                findanother = false; // display another as false 
                            }

                           
                            Console.ReadLine();
                        }
                        break;
                    //Update Flight Departure
                    case 4:
                        bool UpdateMore = true;
                        while (UpdateMore)
                        {
                            try
                            {
                                do
                                {
                                    Console.WriteLine("Enter the update departure time (e.g., 2025-04-12 14:30):");

                                    string input = Console.ReadLine();

                                    if (DateTime.TryParse(input, out departure_Time))
                                    {
                                        isValid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid format! Please enter a valid date and time. try agine");
                                        isValid = false;
                                        traies++;
                                        continue;
                                    }


                                } while (!isValid && traies < 3); // if the input is not vlidate repet ask the user 
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid date and time after 3 tries.");
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                                isValid = false;
                                traies++;
                            }

                            traies = 0;

                            if (isValid)
                            {
                                UpdateFlightDeparture(ref departure_Time);
                                Console.WriteLine("\nPress any key to return to the menu...");
                                Console.ReadKey();
                            }

                            //ask user if want to find onthor flight information '
                            Console.WriteLine("Do you want to Update  another flight departure (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            // use if statement to deal with ChoiceChar input if y or n
                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                UpdateMore = true;
                            }
                            else
                            {
                                UpdateMore = false; // display another as false 
                            }
                            Console.ReadLine();
                        }
                        break;
                    // CancelFlightBooking
                    case 5:

                        // Enter Passenger name from user 
                        try
                        {
                            do
                            {
                                Console.WriteLine("Enter passenger Name :");
                                passengerName_Input = Console.ReadLine();
                                //Check if the name contains special characters , use .IsMatch to Indicates whether the specified regular expression finds a match in the specified input string
                                if (!Regex.IsMatch(passengerName_Input, @"^[a-zA-Z\s]+$"))
                                {
                                    Console.WriteLine("Invalid name! Special characters and numbers are not allowed.");
                                    isValid = false;
                                    traies++;
                                    continue;
                                }
                                else
                                {
                                    isValid = true;
                                }

                                // If the name is empty or just spaces, also throw an error, use function to check whether the specified string is null or contains only white-space characters
                                if (string.IsNullOrWhiteSpace(passengerName_Input))
                                {
                                    Console.WriteLine("Name cannot be empty or spaces only.");
                                    isValid = false;
                                    traies++;
                                }

                                else
                                {
                                    isValid = true; //Set to false once valid input is entered , exit loop
                                }

                            } while (!isValid && traies < 3);
                            if (!isValid)
                            {
                                Console.WriteLine("Failed to provide a valid date and time after 3 tries.");
                                return;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.WriteLine("Press enter to continue...");
                        }

                        traies = 0;
                        if (isValid)
                        {
                            CancelFlightBooking(out passengerName_Input);
                            Console.ReadLine();
                        }
                        
                        break;
                    // BookFlight +  GenerateBookingID +// ValidateFlightCode functions
                    case 6:
                        while (BookingMore)
                        {
                            int FlightIndex = 0;
                            // Enter Passenger name from user 
                            try
                            {
                                do
                                {
                                    Console.WriteLine("Enter passenger Name :");
                                    passengerName_Input = Console.ReadLine();
                                    //Check if the name contains special characters , use .IsMatch to Indicates whether the specified regular expression finds a match in the specified input string
                                    if (!Regex.IsMatch(passengerName_Input, @"^[a-zA-Z\s]+$"))
                                    {
                                        Console.WriteLine("Invalid name! Special characters and numbers are not allowed.");
                                        isValid = false;
                                        traies++;
                                        continue;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }

                                    // If the name is empty or just spaces, also throw an error, use function to check whether the specified string is null or contains only white-space characters
                                    if (string.IsNullOrWhiteSpace(passengerName_Input))
                                    {
                                        Console.WriteLine("Name cannot be empty or spaces only.");
                                        isValid = false;
                                        traies++;
                                    }

                                    else
                                    {
                                        isValid = true; //Set to false once valid input is entered , exit loop
                                    }

                                } while (!isValid && traies < 3);
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid date and time after 3 tries.");
                                    return;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error: {e.Message}");
                                Console.WriteLine("Press enter to continue...");
                            }

                            traies = 0;
                            // enter the flight code he want to booking
                            try
                            {


                                do
                                {
                                    Console.WriteLine("Enter Flight Code: ");
                                    flightCode_Input = Console.ReadLine();
                                    // validate the flight code input
                                    if (string.IsNullOrWhiteSpace(flight_Code))
                                    {
                                        Console.WriteLine("Flight code cannot be empty.");
                                        isValid = false;
                                        traies++;
                                        continue; // try agine
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }

                                    // validate if th code exist or not
                                    bool VlidateFlight = ValidateFlightCode(flightCode_Input);
                                    if (VlidateFlight)
                                    {
                                        isValid = true;
                                    }
                                    else
                                    {
                                        isValid = false;
                                        traies++;
                                    }


                                } while (!isValid && traies < 3);
                                if (!isValid)
                                {
                                    Console.WriteLine("Failed to provide a valid date and time after 3 tries.");
                                    return;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error: {e.Message}");
                                Console.WriteLine("Press enter to continue...");
                            }
                            traies = 0;
                            if (isValid) /// if statement to make sure the enter code is exist in the flight code list
                            {
                                if (BookingCounter < SeatsNum_A[FlightIndex]) // check if number of booking is less than number of seats, if yes so there is seat to booking
                                {
                                    BookFlight(passengerName: passengerName_Input, flightCode: flightCode_Input);
                                    Console.WriteLine("Flight booking successfully!");
                                    BookingCounter++;

                                }
                                else // if the condition is false so there is not seat to booking
                                {
                                    Console.WriteLine("No available seats on this flight.");
                                    BookingMore = false;
                                }
                            }
                            else // in case the code dose not exist
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
                    // DisplayFlightDetails
                    case 7:
                        Console.WriteLine("Enter the the flight code: ");
                        string flightCode = Console.ReadLine();
                        DisplayFlightDetails(flightCode);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();


                        break;
                    //  Search Bookings By Destination
                    case 8:

                        Console.WriteLine("Enter the To City name:");
                        string ToCityInput = Console.ReadLine();
                        SearchBookingsByDestination(ToCityInput);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    //  Function Overloading
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
