using GojekParkingLot.BLL;
using System;
using System.IO;

namespace GojekParkingLot.Presentation
{
    public class Program
    {
        private static ParkingService svc;

        public static void Main(string[] args)
        {
            svc = new ParkingService();

            if (args.Length > 0)
            {
                // get command
                string cmd1 = args[0];

                // run the app with file
                string filename = "";
                if (cmd1.Split(".").Length > 0)
                {
                    filename = cmd1;
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        while (reader.Peek() > 0)
                        {
                            string input = reader.ReadLine();
                            RunningApp(input);
                        }
                    }
                }
            }
            else
            {
                // run interactively
                while (true)
                {
                    string input = Console.ReadLine();
                    RunningApp(input);
                }
            }
        }

        public static void RunningApp(string input)
        {
            if (input.Trim() != "")
            {
                string[] inputs = input.Split(" ");

                if (inputs.Length == 2)
                {
                    if (inputs[1].ToLower() == "--help")
                    {
                        GenerateHelp(inputs[0].ToLower());
                        return;
                    }
                }

                switch (inputs[0].ToUpper())
                {
                    case nameof(Constants.Commands.CREATE_PARKING_LOT):
                        if (inputs.Length != 2)
                        {
                            GenerateParametersError(Constants.Commands.CREATE_PARKING_LOT);
                            break;
                        }
                        Console.WriteLine(svc.CreateParkingLot(inputs[1].ToString()));
                        break;
                    case nameof(Constants.Commands.PARK):
                        if (inputs.Length != 3)
                        {
                            GenerateParametersError(Constants.Commands.PARK);
                            break;
                        }
                        Console.WriteLine(svc.Park(inputs[1].ToString(), inputs[2].ToString()));
                        break;
                    case nameof(Constants.Commands.LEAVE):
                        if (inputs.Length != 2)
                        {
                            GenerateParametersError(Constants.Commands.LEAVE);
                            break;
                        }
                        Console.WriteLine(svc.Leave(inputs[1].ToString()));
                        break;
                    case nameof(Constants.Commands.STATUS):
                        if (inputs.Length != 1)
                        {
                            GenerateParametersError(Constants.Commands.STATUS);
                            break;
                        }
                        Console.WriteLine(svc.GetStatus());
                        break;
                    case nameof(Constants.Commands.REGISTRATION_NUMBERS_FOR_CARS_WITH_COLOUR):
                        if (inputs.Length != 2)
                        {
                            GenerateParametersError(Constants.Commands.REGISTRATION_NUMBERS_FOR_CARS_WITH_COLOUR);
                            break;
                        }
                        Console.WriteLine(svc.GetRegistrationNumbersByColour(inputs[1].ToString()));
                        break;
                    case nameof(Constants.Commands.SLOT_NUMBERS_FOR_CARS_WITH_COLOUR):
                        if (inputs.Length != 2)
                        {
                            GenerateParametersError(Constants.Commands.SLOT_NUMBERS_FOR_CARS_WITH_COLOUR);
                            break;
                        }
                        Console.WriteLine(svc.GetSlotNumbersByColour(inputs[1].ToString()));
                        break;
                    case nameof(Constants.Commands.SLOT_NUMBER_FOR_REGISTRATION_NUMBER):
                        if (inputs.Length != 2)
                        {
                            GenerateParametersError(Constants.Commands.SLOT_NUMBER_FOR_REGISTRATION_NUMBER);
                            break;
                        }
                        Console.WriteLine(svc.GetSlotNumberByRegistrationNumber(inputs[1].ToString()));
                        break;
                    case nameof(Constants.Commands.HELP):
                        GenerateHelp("all");
                        break;
                    default:
                        GenerateCommandError();
                        break;
                }
            }
        }

        private static void GenerateParametersError(string command)
        {
            Console.WriteLine("Parameters error!");
            Console.WriteLine($"See {Constants.APPLICATION_NAME} {command} --help\n");
        }

        private static void GenerateCommandError()
        {
            Console.WriteLine("Command not found!");
            Console.WriteLine($"See {Constants.APPLICATION_NAME} --help\n");
        }

        private static void GenerateHelp(string command)
        {
            string result = "";
            switch (command.ToUpper())
            {
                case nameof(Constants.Commands.CREATE_PARKING_LOT):
                    result = "create_parking_lot <number of lot>";
                    break;
                case nameof(Constants.Commands.PARK):
                    result = "park <registration no> <colour>";
                    break;
                case nameof(Constants.Commands.LEAVE):
                    result = "leave <slot no>";
                    break;
                case nameof(Constants.Commands.STATUS):
                    result = "status";
                    break;
                case nameof(Constants.Commands.REGISTRATION_NUMBERS_FOR_CARS_WITH_COLOUR):
                    result = "registration_numbers_for_cars_with_colour <colour>";
                    break;
                case nameof(Constants.Commands.SLOT_NUMBERS_FOR_CARS_WITH_COLOUR):
                    result = "slot_numbers_for_cars_with_colour <colour>";
                    break;
                case nameof(Constants.Commands.SLOT_NUMBER_FOR_REGISTRATION_NUMBER):
                    result = "slot_number_for_registration_number <slot number>";
                    break;
                case "ALL":
                    result = "commands available: create_parking_lot, park, leave, status, registration_numbers_for_cars_with_colour, slot_numbers_for_cars_with_colour, slot_number_for_registration_number";
                    break;
            }
            Console.WriteLine($"{result}\n");
        }

    }
}
