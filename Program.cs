using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Static variables to store alarm time, alarm state, and snooze duration
    static DateTime alarmTime; // Stores the time when the alarm should ring
    static bool alarmActive = false; // Tracks whether the alarm is currently active
    static int snoozeDuration = 1; // Duration in minutes for snoozing the alarm

    // Main method, the entry point of the program
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the Command Line Alarm Clock");

        // Main loop to keep the program running
        while (true)
        {
            // Display options to the user
            ShowOptions();

            // Wait for user input (without displaying the key press)
            var key = Console.ReadKey(intercept: true).Key;

            // Handle user input
            if (key == ConsoleKey.A)
            {
                // Set Alarm
                SetAlarm();

                // Clear the console and display the time until the alarm rings
                Console.Clear();
                while (true)
                {
                    DisplayTime(); // Display the current time in an ASCII box

                    // Check if the alarm is active and the current time has reached the alarm time
                    if (alarmActive && DateTime.Now >= alarmTime)
                    {
                        // Alarm rings
                        Console.Clear(); // Clear the time display
                        await TriggerAlarm(); // Trigger the alarm
                        break; // Exit the loop after handling the alarm
                    }

                    Thread.Sleep(1000); // Wait for 1 second before refreshing the time display
                }
            }
            else if (key == ConsoleKey.E)
            {
                // Exit the program
                Console.WriteLine("Goodbye! 👋");
                Environment.Exit(0); // Terminate the program
            }
            else
            {
                // Handle invalid input
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    // Method to set the alarm time
    static void SetAlarm()
    {
        while (true)
        {
            Console.Write("Enter alarm time (HH:mm): ");
            string? input = Console.ReadLine(); // Read user input (nullable string)

            // Validate the input and parse it into a DateTime object
            if (input != null && DateTime.TryParse(input, out alarmTime))
            {
                // Ensure the alarm time is in the future
                if (alarmTime > DateTime.Now)
                {
                    alarmActive = true; // Activate the alarm
                    break; // Exit the loop if the time is valid
                }
                else
                {
                    Console.WriteLine("Invalid time. Please set a future time.");
                }
            }
            else
            {
                Console.WriteLine("Invalid time format. Please try again.");
            }
        }
    }

    // Method to trigger the alarm
    static async Task TriggerAlarm()
    {
        Console.WriteLine("\nALARM! ALARM! ALARM! ⏰");
        Console.WriteLine("Press 'S' to snooze or 'O' to turn off the alarm.");

        // Keep beeping until the alarm is snoozed or turned off
        while (alarmActive && DateTime.Now >= alarmTime)
        {
            Console.Beep(); // Play a beep sound
            Thread.Sleep(1000); // Beep every second

            // Check if the user has pressed a key
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;

                // Handle snooze or turn off
                if (key == ConsoleKey.S)
                {
                    SnoozeAlarm(); // Snooze the alarm
                    break;
                }
                else if (key == ConsoleKey.O)
                {
                    TurnOffAlarm(); // Turn off the alarm
                    break;
                }
            }
        }

        await Task.CompletedTask; // To satisfy async requirement
    }

    // Method to snooze the alarm
    static void SnoozeAlarm()
    {
        if (alarmActive)
        {
            // Set the new alarm time by adding the snooze duration
            alarmTime = DateTime.Now.AddMinutes(snoozeDuration);
            Console.WriteLine($"Alarm snoozed for {snoozeDuration} minute(s).");

            // Clear the console and resume time display
            Console.Clear();
            while (DateTime.Now < alarmTime)
            {
                DisplayTime(); // Display the current time
                Thread.Sleep(1000); // Wait for 1 second before refreshing
            }

            // Alarm rings again after snooze
            Console.Clear(); // Clear the time display
            TriggerAlarm().Wait(); // Trigger the alarm again
        }
        else
        {
            Console.WriteLine("No active alarm to snooze.");
        }
    }

    // Method to turn off the alarm
    static void TurnOffAlarm()
    {
        if (alarmActive)
        {
            alarmActive = false; // Deactivate the alarm
            Console.WriteLine("Alarm turned off.");
        }
        else
        {
            Console.WriteLine("No active alarm to turn off.");
        }
    }

    // Method to display the options menu
    static void ShowOptions()
    {
        Console.WriteLine("\nOptions:");
        Console.WriteLine("A - Set Alarm");
        Console.WriteLine("E - Exit");
    }

    // Method to display the current time in an ASCII art box
    static void DisplayTime()
    {
        Console.SetCursorPosition(0, 0); // Move cursor to the top-left corner
        Console.WriteLine("Current Time:");
        Console.WriteLine(GetAsciiTime(DateTime.Now)); // Display the time in an ASCII box
    }

    // Method to generate an ASCII art box with the current time
    static string GetAsciiTime(DateTime time)
    {
        string timeString = time.ToString("HH:mm:ss"); // Format the time as HH:mm:ss
        int boxWidth = 30; // Total width of the box (including borders)
        int timeWidth = timeString.Length; // Length of the time string (always 8 for HH:mm:ss)
        int totalPadding = boxWidth - timeWidth - 2; // Total padding needed (subtract 2 for borders)
        int leftPadding = totalPadding / 2; // Padding on the left side
        int rightPadding = totalPadding - leftPadding; // Padding on the right side

        // Create the ASCII art box with the time centered
        string asciiArt = @"
    ╔══════════════════════════════╗
    ║                              ║
    ║" + new string(' ', leftPadding) + timeString + new string(' ', rightPadding) + @"║
    ║                              ║
    ╚══════════════════════════════╝
    ";
        return asciiArt;
    }
}