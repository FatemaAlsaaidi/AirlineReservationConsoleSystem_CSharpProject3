using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace AirlineReservationConsoleSystem_CSharpProject3
{
    internal class Program
    {   // global variables and arraies for flight ....... 
        static int Max_Flight = 3;
        static int FlightCounter = 0;
        static string[] flightCode_A = new string[Max_Flight];
        static string[] fromCity_A = new string[Max_Flight];
        static string[] toCity_A = new string[Max_Flight];
        static DateTime[] departureTime_A = new DateTime[Max_Flight];
        static int[] duration_A = new int[Max_Flight];
        static int[] SeatsNum_A = new int[Max_Flight];
        static int[] SeatReserved_A = new int[Max_Flight];

        // flag to validate the user input 
        static bool isValid = false;

        // variables and arraies Passenger Booking Functions section
        //static int BookingCounter = 0;
        static string[] PassengerName_A = new string[200];
        static string[] BookingFlightCode_A = new string[200];
        static int count_seat = 0;
        static string[] GenerateBookingID_A = new string[200];

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
                if (SeatReserved_A[i] < SeatsNum_A[i])
                {
                    // Display all information of avilable flight
                    Console.WriteLine($"Avilable Flight {FlightCounter}: ");
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

            Console.WriteLine("All Not Avilable Flight Information ");
            // Loop through all flights up to the current number of not valiable flight
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is is not avilable
                if (SeatReserved_A[i] == SeatsNum_A[i])
                {
                    // display the information of not avilable flight
                    Console.WriteLine($"Avilable Flight : ");
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
        //9. Book Flight
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        { 
            PassengerName_A[count_seat] = passengerName;
            BookingFlightCode_A[count_seat] = flightCode;
            PassengerName_A[count_seat] = GenerateBookingID(passengerName);
            Console.ReadLine();


        }

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

            string BookingID = passengerName + "2025";
            return BookingID;
        }

        // 12.  Display Flight Details
        pu

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

                    case 2:
                        DisplayAllFlights();
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Enter the code of Flight : ");
                        string code = Console.ReadLine();
                        FindFlightByCode(code);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine($" Update Flight Departure of Flight : ");
                        DateTime departure = DateTime.Parse(Console.ReadLine());
                        UpdateFlightDeparture(ref departure);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();

                        break;
                    case 5:
                        // CancelFlightBooking(out string passengerName) 
                        break;
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
                                if (count_seat < SeatsNum_A[FlightIndex])
                                {
                                    BookFlight(passengerName: passengerName_Input, flightCode: flightCode_Input);
                                    Console.WriteLine("Flight booking successfully!");
                                    count_seat++;

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
                                    if (count_seat < SeatsNum_A[i])
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
                    case 7:
                        Console.WriteLine("Enter the flight code :");
                        string flightCodeInput = Console.ReadLine();
                        ValidateFlightCode(flightCodeInput);
                        Console.ReadKey();
                        break;

                    case 8:

                        break;

                    case 9:

                        break;

                    case 10:

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
