# Simple Alarm Clock

This is a simple alarm clock application created as a project for CS305 at the International University of Sarajevo. The aim of this project is to demonstrate proficiency in C#, Python, and JavaScript by implementing the same functionality in each of these programming languages. Additionally, the project features a display imitation for the alarm clock interface.

The project was completed by a team of three students:
- Munever Hasanovic
- Harun Subasic
- Amra Hozic

## Features

The alarm clock application allows the user to set a desired alarm time and provides an audible alert when the alarm time is reached. The application is implemented in three separate versions, one for each of the following programming languages:

1. C#
2. Python
3. JavaScript

All three versions of the alarm clock application include a display imitation to mimic the look and feel of a traditional alarm clock display.

# Alarm Clock - C# Version

This is the **C# version** of the Alarm Clock project, created as part of CS305 at the International University of Sarajevo. The project demonstrates proficiency in C# by implementing a simple alarm clock with a display imitation.

---
## C# Version
## Features

- **Set Alarm**: Users can input a future time in `HH:mm` format to set an alarm.
- **Real-Time Clock Display**: The current time is displayed in a **7-segment display imitation** using ASCII art, updating every second.
- **Alarm Notification**: When the alarm time is reached, the application plays a **beep sound** and displays a notification.
- **Snooze Functionality**: Users can snooze the alarm for a predefined duration (default: 1 minute).
- **Turn Off Alarm**: Users can turn off the alarm completely.

---

## Installation and Usage

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (v6 or higher)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)

### Steps to Run the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/alarmclock.git
Navigate to the csharp branch:

bash
Copy
git checkout csharp
Navigate to the project directory:

bash
Copy
cd alarmclock/csharp
Run the project:

bash
Copy
dotnet run
Project Structure
Copy
alarmclock/
├── Program.cs            # Main C# file
├── AlarmClock.csproj     # Project configuration file
├── README.md             # This file
└── .gitignore            # Files and directories to ignore in Git
How It Works
The program starts by displaying the current time in a 7-segment display imitation.

Users can set an alarm by entering a time in HH:mm format.

When the alarm time is reached:

The application plays a beep sound.

Users can snooze the alarm or turn it off.

Example Output
Time Display
Copy
    ╔══════════════════════════════╗
    ║                              ║
    ║          14:25:03            ║
    ║                              ║
    ╚══════════════════════════════╝
Alarm Notification
Copy
ALARM! ALARM! ALARM! ⏰
Press 'S' to snooze or 'O' to turn off the alarm.
Contributing
If you would like to contribute to this project, please follow the standard Git workflow:

Fork the repository.

Create a new branch: git checkout -b feature/my-new-feature.

Commit your changes: git commit -am 'Add some feature'.

Push to the branch: git push origin feature/my-new-feature.

Submit a pull request.

License
This project is licensed under the MIT License.

Team
This project was completed by:

Munever Hasanovic

Harun Subasic

Amra Hozic
