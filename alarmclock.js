const readline = require('readline');
const process = require('process');

// Variables for alarm functionality
let alarmTime; // Stores the alarm time set by the user
let alarmActive = false; // Tracks whether the alarm is active or not
const snoozeDuration = 1; // Snooze duration in minutes

// Create a readline interface for user input
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Initial welcome message
console.log("Welcome to the Command Line Alarm Clock");

// Function to display available menu options to the user
function showOptions() {
    console.log("\nOptions:");
    console.log("A - Set Alarm"); // Option to set the alarm
    console.log("E - Exit");      // Option to exit the program
}

// Function to display the current time in an ASCII-styled box
function displayTime() {
    const time = new Date(); // Get the current date and time
    console.clear(); // Clear the console for a clean display
    console.log(`Current Time:\n${getAsciiTime(time)}`); // Show current time in ASCII format
}

// Function to generate an ASCII box containing the current time
function getAsciiTime(time) {
    const timeString = time.toTimeString().split(" ")[0]; // Format time as HH:mm:ss
    const boxWidth = 30; // Width of the ASCII box
    const timeWidth = timeString.length; // Length of the time string
    const totalPadding = boxWidth - timeWidth - 2; // Total padding (subtract 2 for borders)
    const leftPadding = Math.floor(totalPadding / 2); // Padding on the left
    const rightPadding = totalPadding - leftPadding; // Padding on the right

    // Return the formatted ASCII box with the time centered
    return `
    ╔══════════════════════════════╗
    ║                              ║
    ║${" ".repeat(leftPadding)}${timeString}${" ".repeat(rightPadding)}  ║
    ║                              ║
    ╚══════════════════════════════╝
    `;
}

// Function to set the alarm time
function setAlarm() {
    rl.question("Enter alarm time (HH:mm): ", input => {
        const now = new Date(); // Get the current date and time
        const [hour, minute] = input.split(":").map(Number); // Parse the user's input
        const alarm = new Date(); // Create a new Date object for the alarm
        alarm.setHours(hour, minute, 0); // Set the alarm's hour and minute

        // Validate the alarm time to ensure it's in the future
        if (alarm > now) {
            alarmTime = alarm; // Store the alarm time
            alarmActive = true; // Activate the alarm
            console.log(`Alarm set for ${alarm.toTimeString().split(" ")[0]}`); // Confirm the alarm time
            startCountdown(); // Start the countdown to the alarm
        } else {
            console.log("Invalid time. Please set a future time."); // Error message for past time
            setAlarm(); // Retry setting the alarm
        }
    });
}

// Function to continuously display the countdown until the alarm triggers
function startCountdown() {
    const interval = setInterval(() => {
        if (!alarmActive) { // If the alarm is not active, stop the countdown
            clearInterval(interval);
            return;
        }
        displayTime(); // Show the current time
        const now = new Date(); // Get the current time

        if (alarmTime <= now) { // Check if it's time for the alarm to trigger
            clearInterval(interval); // Stop the countdown
            triggerAlarm(); // Trigger the alarm
        }
    }, 1000); // Refresh every second
}

// Function to trigger the alarm
function triggerAlarm() {
    console.clear(); // Clear the console
    console.log("\nALARM! ALARM! ALARM! ⏰"); // Alarm notification
    console.log("Press 'S' to snooze or 'O' to turn off the alarm."); // User instructions

    // Play a beep sound every second while the alarm is active
    const alarmInterval = setInterval(() => {
        if (alarmActive) {
            process.stdout.write('\x07'); // Beep sound in the terminal
        }
    }, 1000);

    // Handle user input to snooze or turn off the alarm
    process.stdin.setRawMode(true); // Enable raw input mode
    process.stdin.resume(); // Start listening for user input
    process.stdin.on("data", data => {
        const key = data.toString().trim().toUpperCase(); // Convert input to uppercase

        if (key === "S") { // Snooze the alarm
            clearInterval(alarmInterval); // Stop the beep sound
            snoozeAlarm(); // Activate snooze functionality
        } else if (key === "O") { // Turn off the alarm
            clearInterval(alarmInterval); // Stop the beep sound
            turnOffAlarm(); // Deactivate the alarm
        }
    });
}

// Function to snooze the alarm
function snoozeAlarm() {
    alarmActive = true; // Keep the alarm active
    alarmTime = new Date(Date.now() + snoozeDuration * 60000); // Set the alarm to snooze duration
    console.log(`Alarm snoozed for ${snoozeDuration} minute(s).`); // Notify the user
    startCountdown(); // Restart the countdown for the snoozed alarm
}

// Function to turn off the alarm
function turnOffAlarm() {
    alarmActive = false; // Deactivate the alarm
    console.log("\nAlarm turned off."); // Notify the user on a new line
    process.exit(0); // Exit the program
}

// Main function to handle the program flow
function main() {
    showOptions(); // Show the menu options to the user
    rl.on("line", input => {
        const key = input.trim().toUpperCase(); // Convert user input to uppercase
        if (key === "A") { // Handle the "Set Alarm" option
            setAlarm();
        } else if (key === "E") { // Handle the "Exit" option
            console.log("Goodbye! 👋"); // Farewell message
            process.exit(0); // Terminate the program
        } else { // Handle invalid input
            console.log("Invalid choice. Try again.");
            showOptions(); // Redisplay the menu options
        }
    });
}

// Start the program
main();
