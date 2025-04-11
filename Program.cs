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
                // If all validations pass, save the data
                flightCode_A[FlightCounter] = flightCode;
                fromCity_A[FlightCounter] = fromCity;
                toCity_A[FlightCounter] = toCity;
                departureTime_A[FlightCounter] = departureTime;
                duration_A[FlightCounter] = duration;
                AvailableFlights[FlightCounter] = true;
                return;

        }
        //                    ========================= System Utilities & Final Flow ===========================

        //  1. Start System method 
        public static void StartSystem()
        {
            // calling DisplayWelcomeMessage() function 
            DisplayWelcomeMessage();

            // Wait for user to press any key before continuing
            Console.ReadLine();

            // Declare variables to store singe value of user input 
            string flight_Code = null;
            string from_City = null;
            string to_City = null;
            DateTime departure_Time;
            int duration_1 = 0;
            int Seats_Num = 0;
            char ChoiceChar = 'y';
            bool AddMore = true;
            bool isValid = true;
            switch (ShowMainMenu())
            {
                case 1:
                    while (AddMore && FlightCounter < Max_Flight)
                    {
                        Console.WriteLine($"Enter flight {FlightCounter + 1} Information");

                        // Flight Code Input..
                        do
                        {
                            Console.WriteLine("Enter Flight Code :");
                            flight_Code = Console.ReadLine();

                            // flightCode input validation 
                            if (string.IsNullOrWhiteSpace(flight_Code))
                            {
                                Console.WriteLine("Flight code cannot be empty.");
                                isValid = false;
                            }

                            // (Optional) Check if flight code already exists
                            for (int i = 0; i < FlightCounter; i++)
                            {
                                if (flightCode_A[i] == flight_Code)
                                {
                                    Console.WriteLine("A flight with this code already exists.");
                                    isValid = false;
                                }
                            }
                        } while (!isValid);

                        // From City Input
                        do
                        {

                            Console.WriteLine("Enter From City :");
                            from_City = Console.ReadLine();


                            // fromCity input validation 
                            if (string.IsNullOrWhiteSpace(from_City))
                            {
                                Console.WriteLine("From city names cannot be empty.");
                                isValid = false;
                            }
                        }while(!isValid);

                        // To City Input

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

                        }while (!isValid);

                        // Departure time input
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

                        } while (!isValid);

                        // Duration Input

                        do {
                            Console.WriteLine("Enter duration:");
                            duration_1 = int.Parse(Console.ReadLine());

                            // Duration input validation 
                            if (duration_1 <= 0)
                            {
                                Console.WriteLine("Duration must be greater than zero.");
                                isValid = false;
                            }
                        }while (!isValid);

                        // Number of seats input
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

                        } while (!isValid);
                        if (isValid)
                        {
                            AddFlight(flightCode: flight_Code, fromCity: from_City, toCity: to_City, departureTime: departure_Time, duration: duration_1, SeatsNum: Seats_Num);
                            Console.WriteLine("Flight added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Flight added faild!");
                            break;

                        }

                        FlightCounter++;
                        Console.WriteLine("Do you want to add more flight information?! (y/n)");
                        ChoiceChar = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        Console.ReadLine();
                        if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                        {
                            if (FlightCounter == Max_Flight)
                            {
                                Console.WriteLine("Can Not Add More Flight Information");
                                AddMore = false;
                            }
                            else
                            {
                                AddMore = true;
                            }
                        }
                        else
                        {
                            ShowMainMenu();
                            AddMore = false;
                        }
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
