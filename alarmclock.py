import sys
import time
import os
from datetime import datetime, timedelta
import msvcrt  # Import msvcrt for Windows keypress detection

# Variables for alarm functionality
alarm_time = None  # Stores the alarm time set by the user
alarm_active = False  # Tracks whether the alarm is active or not
snooze_duration = 1  # Snooze duration in minutes

# Function to play a beep sound (cross-platform)
def play_beep():
    if os.name == 'nt':  # Windows
        import winsound
        winsound.Beep(1000, 500)  # Frequency: 1000 Hz, Duration: 500 ms
    elif os.name == 'posix':  # macOS or Linux
        if sys.platform == 'darwin':  # macOS
            os.system('afplay /System/Library/Sounds/Ping.aiff')  # macOS beep
        else:  # Linux
            os.system('beep -f 1000 -l 500')  # Linux beep (requires 'beep' utility)

# Function to display available menu options to the user
def show_options():
    print("\nOptions:")
    print("A - Set Alarm")  # Option to set the alarm
    print("E - Exit")       # Option to exit the program

# Function to display the current time in an ASCII-styled box
def display_time():
    current_time = datetime.now()  # Get the current date and time
    os.system('cls' if os.name == 'nt' else 'clear')  # Clear the console for a clean display
    print(f"Current Time:\n{get_ascii_time(current_time)}")  # Show current time in ASCII format

# Function to generate an ASCII box containing the current time
def get_ascii_time(time):
    time_string = time.strftime("%H:%M:%S")  # Format time as HH:mm:ss
    box_width = 30  # Width of the ASCII box
    time_width = len(time_string)  # Length of the time string
    total_padding = box_width - time_width - 2  # Total padding (subtract 2 for borders)
    left_padding = total_padding // 2  # Padding on the left
    right_padding = total_padding - left_padding  # Padding on the right

    # Return the formatted ASCII box with the time centered
    return f"""
    ╔══════════════════════════════╗
    ║                              ║
    ║{" " * left_padding}{time_string}{" " * right_padding}  ║
    ║                              ║
    ╚══════════════════════════════╝
    """

# Function to set the alarm time
def set_alarm():
    global alarm_time, alarm_active
    alarm_input = input("Enter alarm time (HH:mm): ")  # Get user input for alarm time
    try:
        hour, minute = map(int, alarm_input.split(":"))  # Parse the user's input
        now = datetime.now()  # Get the current date and time
        alarm = now.replace(hour=hour, minute=minute, second=0, microsecond=0)  # Create a new datetime object for the alarm

        # Validate the alarm time to ensure it's in the future
        if alarm > now:
            alarm_time = alarm  # Store the alarm time
            alarm_active = True  # Activate the alarm
            print(f"Alarm set for {alarm.strftime('%H:%M')}")  # Confirm the alarm time
            start_countdown()  # Start the countdown to the alarm
        else:
            print("Invalid time. Please set a future time.")  # Error message for past time
            set_alarm()  # Retry setting the alarm
    except ValueError:
        print("Invalid format. Please use HH:mm format.")  # Error message for invalid format
        set_alarm()  # Retry setting the alarm

# Function to continuously display the countdown until the alarm triggers
def start_countdown():
    global alarm_active
    while alarm_active:
        display_time()  # Show the current time
        now = datetime.now()  # Get the current time

        if alarm_time <= now:  # Check if it's time for the alarm to trigger
            trigger_alarm()  # Trigger the alarm
            break
        time.sleep(1)  # Refresh every second

# Function to trigger the alarm
def trigger_alarm():
    global alarm_active
    os.system('cls' if os.name == 'nt' else 'clear')  # Clear the console
    print("\nALARM! ALARM! ALARM! ⏰")  # Alarm notification
    print("Press 'S' to snooze or 'O' to turn off the alarm.")  # User instructions

    # Continuously beep until the user snoozes or turns off the alarm
    while alarm_active:
        play_beep()  # Play the beep sound
        time.sleep(0.5)  # Beep every 0.5 seconds

        # Check for user input without blocking (Windows-specific)
        if msvcrt.kbhit():  # Check if a key is pressed
            key = msvcrt.getch().decode('utf-8').upper()  # Read the key and decode it
            if key == "S":  # Snooze the alarm
                snooze_alarm()  # Activate snooze functionality
                break
            elif key == "O":  # Turn off the alarm
                turn_off_alarm()  # Deactivate the alarm
                break

# Function to snooze the alarm
def snooze_alarm():
    global alarm_time, alarm_active
    alarm_active = True  # Keep the alarm active
    alarm_time = datetime.now() + timedelta(minutes=snooze_duration)  # Set the alarm to snooze duration
    print(f"Alarm snoozed for {snooze_duration} minute(s).")  # Notify the user
    start_countdown()  # Restart the countdown for the snoozed alarm

# Function to turn off the alarm
def turn_off_alarm():
    global alarm_active
    alarm_active = False  # Deactivate the alarm
    print("\nAlarm turned off.")  # Notify the user on a new line
    sys.exit(0)  # Exit the program

# Main function to handle the program flow
def main():
    print("Welcome to the Command Line Alarm Clock")
    show_options()  # Show the menu options to the user
    while True:
        user_input = input().strip().upper()  # Convert user input to uppercase
        if user_input == "A":  # Handle the "Set Alarm" option
            set_alarm()
        elif user_input == "E":  # Handle the "Exit" option
            print("Goodbye! 👋")  # Farewell message
            sys.exit(0)  # Terminate the program
        else:  # Handle invalid input
            print("Invalid choice. Try again.")
            show_options()  # Redisplay the menu options

# Start the program
if __name__ == "__main__":
    main()