namespace AirlineReservationConsoleSystem_CSharpProject3
{
    internal class Program
    {   // Declare variables and arraies we need them 
        static int Max_Flight = 3;
        static int FlightCounter = 0;
        static string[] flightCode_A = new string[Max_Flight];
        static string[] fromCity_A = new string[Max_Flight];
        static string[] toCity_A = new string[Max_Flight];
        static DateTime[] departureTime_A = new DateTime[Max_Flight];
        static int[] duration_A = new int[Max_Flight];

        static bool[] AvailableFlights = new bool[Max_Flight];

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
        }
        public static int ShowMainMenu()
        {
            Console.WriteLine("Airline Reservation System");
            Console.WriteLine("1. Add Flight");
            Console.WriteLine("2. Display All Flights");
            Console.WriteLine("3. Find Flight By Code");
            Console.WriteLine("4. Update Flight Departure");
            Console.WriteLine("5. Cancel Flight Booking");
            Console.WriteLine("Enter the option: ");

            int option = int.Parse(Console.ReadLine());
            return option;
        }

        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
            while (FlightCounter < Max_Flight)
            {


                if (FlightCounter < Max_Flight)
                {
                    flightCode_A[FlightCounter] = flightCode;
                    fromCity_A[FlightCounter] = fromCity;
                    toCity_A[FlightCounter] = toCity;
                    departureTime_A[FlightCounter] = departureTime;
                    duration_A[FlightCounter] = duration;
                    AvailableFlights[FlightCounter] = true;
                }
                else
                {
                    Console.WriteLine("Can not add more");
                }
            }

        }
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();


            switch (ShowMainMenu())
            {
                case 1:
                    while (FlightCounter < Max_Flight)
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

                        AddFlight(flightCode: flight_Code, fromCity: from_City, toCity: to_City, departureTime: departure_Time, duration: duration_1);
                    }
                    FlightCounter++;

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;

                default: 
                    Console.WriteLine("Invalid choice! Try again."); 
                break;
            }
        }
    }
}
