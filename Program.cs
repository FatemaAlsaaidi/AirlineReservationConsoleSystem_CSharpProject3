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
        static bool[] AvailableFlights = new bool[Max_Flight];

        //                                =====================Startup & Navigation=============

        // 1. display welcome message method..........
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
        }
        // 2. show main menu method
        public static int ShowMainMenu()
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
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter the option: ");

            int option = int.Parse(Console.ReadLine());
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
            // flightCode input validation 
            if (string.IsNullOrWhiteSpace(flightCode))
            {
                Console.WriteLine("Flight code cannot be empty.");
                return;
            }

            // fromCity input validation 
            if (string.IsNullOrWhiteSpace(fromCity))
            {
                Console.WriteLine("From city names cannot be empty.");
                return;
            }

            // Duration input validation 
            if (duration <= 0)
            {
                Console.WriteLine("Duration must be greater than zero.");
                return;
            }

            //seatsNum input validation
            if (SeatsNum <= 0)
            {
                Console.WriteLine("Number of seats must be greater than zero.");
                return;
            }
            // Flight Counter validation 
            if (FlightCounter >= Max_Flight)
            {
                Console.WriteLine("Maximum number of flights reached.");
                return;
            }

            // (Optional) Check if flight code already exists
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCode_A[i] == flightCode)
                {
                    Console.WriteLine("A flight with this code already exists.");
                    return;
                }
            }

            // If all validations pass, save the data
            flightCode_A[FlightCounter] = flightCode;
            fromCity_A[FlightCounter] = fromCity;
            toCity_A[FlightCounter] = toCity;
            departureTime_A[FlightCounter] = departureTime;
            duration_A[FlightCounter] = duration;
            AvailableFlights[FlightCounter] = true;
            Console.WriteLine("Flight added successfully!");

        }
        //                    ========================= System Utilities & Final Flow ===========================

        //  1. Start System method 
        public static void StartSystem()
        {
            // calling DisplayWelcomeMessage() function 
            DisplayWelcomeMessage();

            // Wait for user to press any key before continuing
            Console.ReadLine();

            char ChoiceChar = 'y';
            switch (ShowMainMenu())
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Enter Flight Code :");
                        string flight_Code = Console.ReadLine();

                        Console.WriteLine("Enter From City :");
                        string from_City = Console.ReadLine();

                        Console.WriteLine("Enter To City :");
                        string to_City = Console.ReadLine();

                        DateTime departure_Time = DateTime.Now;

                        Console.WriteLine("Enter duration:");
                        int duration_1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Number of seats:");
                        int Seats_Num = int.Parse(Console.ReadLine());

                        AddFlight(flightCode: flight_Code, fromCity: from_City, toCity: to_City, departureTime: departure_Time, duration: duration_1, SeatsNum: Seats_Num);

                    } while (FlightCounter < Max_Flight) ;

                    FlightCounter++;

                    Console.WriteLine("Do you want to add more flight information?! (y/n)");
                    ChoiceChar = Console.ReadKey().KeyChar;
                    if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                    {
                        if (FlightCounter == Max_Flight)
                            Console.WriteLine("Can Not Add More Flight Information");
                    }
                    else
                    {
                        Console.WriteLine("Ok!");
                    }
                        break; 
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

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

        //                    ======================= main method ==============================

        // 1. main method 
        static void Main(string[] args)
        {
            StartSystem();
        }
    }
}
