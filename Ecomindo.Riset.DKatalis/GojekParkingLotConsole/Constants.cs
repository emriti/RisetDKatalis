namespace GojekParkingLot.Presentation
{
    public class Constants
    {
        public readonly static string APPLICATION_NAME = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        public class Commands
        {
            public readonly static string CREATE_PARKING_LOT = "create_parking_lot";
            public readonly static string PARK = "park";
            public readonly static string LEAVE = "leave";
            public readonly static string STATUS = "status";
            public readonly static string REGISTRATION_NUMBERS_FOR_CARS_WITH_COLOUR = "registration_numbers_for_cars_with_colour";
            public readonly static string SLOT_NUMBERS_FOR_CARS_WITH_COLOUR = "slot_numbers_for_cars_with_colour";
            public readonly static string SLOT_NUMBER_FOR_REGISTRATION_NUMBER = "slot_number_for_registration_number";
            public readonly static string HELP = "help";
        }
    }
}
