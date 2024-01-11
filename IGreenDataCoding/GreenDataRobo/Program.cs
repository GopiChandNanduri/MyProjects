// See https://aka.ms/new-console-template for more information
using GreenDataRobo;
using GreenDataRobo.Commands;

Console.WriteLine("Hello, Welcome to Robo Simulator!");

while (true)
{
    Console.WriteLine("How you want to Input the commands :");
    Console.WriteLine("File - 'F' \t Commands - 'C' \t Exit the Simulator - 'E'");
    Console.WriteLine("Choose the option :");
    var selection = Console.ReadLine();
    if (selection == "F")
    {
        FileSelection();
    }
    else if (selection == "C")
    {
        CommandLineSelection();
    }
    else if (selection == "E")
    {
        break;
    }
    else
    {
        Console.WriteLine("Incorrect command. Please enter correct command.");
    }
}

void FileSelection()
{
    ToyRobot robot = null;
    CommandInvoker invoker = null;

    while (true)
    {
        string filePath = "InputFile.txt";

        // Read from file
        try
        {
            if (File.Exists(filePath))
            {
                robot = new ToyRobot();
                invoker = new CommandInvoker();
                string[] commands = File.ReadAllLines(filePath);

                foreach (var command in commands)
                {
                    ProcessCommand(robot, invoker, command);
                }

                invoker.ExecuteCommands();
                Console.WriteLine("End of File");

            }
            else
            {
                Console.WriteLine("File was not present");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please provide a valid file path.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }


        Console.WriteLine("Do you want to proceed with same selection ?");
        Console.WriteLine("No - 'N' \t press any key if yes");
        string selection = Console.ReadLine();
        if (selection == "N")
            break;
    }
}

void CommandLineSelection()
{
    ToyRobot robot = new ToyRobot();
    CommandInvoker invoker = null;

    Console.WriteLine("At any point of time, if you want to goto Home, press - 'H'");

    while (true)
    {
        invoker = new CommandInvoker();
        string inputCommand = Console.ReadLine();
        if (inputCommand == "H")
            break;
        else
        {
            ProcessCommand(robot, invoker, inputCommand);
            invoker.ExecuteCommands();
        }
    }

}

void ProcessCommand(ToyRobot robot, CommandInvoker invoker, string command)
{
    string[] parts = command.Split();
    switch (parts[0])
    {
        case "PLACE":
            if (parts.Length == 2)
            {
                string[] placeArgs = parts[1].Split(',');
                if (placeArgs.Length == 3)
                {
                    int x, y;
                    if (int.TryParse(placeArgs[0], out x) && int.TryParse(placeArgs[1], out y))
                    {
                        invoker.AddCommand(new PlaceCommand(robot, x, y, placeArgs[2]));
                    }
                }
            }
            break;
        case "MOVE":
            invoker.AddCommand(new MoveCommand(robot));
            break;
        case "LEFT":
            invoker.AddCommand(new LeftCommand(robot));
            break;
        case "RIGHT":
            invoker.AddCommand(new RightCommand(robot));
            break;
        case "REPORT":
            invoker.AddCommand(new ReportCommand(robot));
            break;
        default:
            Console.WriteLine($"Unknown command: {command}");
            break;
    }
}
