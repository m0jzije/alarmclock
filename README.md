# Python Alarm Clock

A simple command-line alarm clock implemented in Python. This project allows you to set an alarm, snooze it, or turn it off. It is designed to work on Windows, macOS, and Linux.

---

## Features

- **Set Alarm**: Set an alarm for a specific time in `HH:mm` format.
- **Snooze**: Snooze the alarm for a predefined duration (default: 1 minute).
- **Turn Off**: Turn off the alarm completely.
- **Cross-Platform Beep**: Plays a beep sound on Windows, macOS, and Linux.
- **ASCII Time Display**: Displays the current time in a stylized ASCII box.

---

## Requirements

- Python 3.x
- `winsound` (Windows only, included in Python standard library)
- `afplay` (macOS only, included by default)
- `beep` (Linux only, install via `sudo apt install beep`)

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name
2. Switch to the python branch:

     ```bash
    git checkout python
3. Run the Python script:

     ```bash

    python alarm_clock.py
4. Follow the on-screen instructions:
     ```bash

    Press A to set an alarm.

    Press E to exit the program.

5. When the alarm triggers, press S to snooze or O to turn it off.

Code Structure
alarm_clock.py: The main script containing the alarm clock logic.

set_alarm(): Prompts the user to set an alarm time.

start_countdown(): Continuously checks if the alarm time has been reached.

trigger_alarm(): Triggers the alarm and handles user input for snoozing or turning off.

play_beep(): Plays a beep sound (cross-platform).

display_time(): Displays the current time in an ASCII box.

Example Usage
Set an alarm for 10:30:

     ```bash

    Enter alarm time (HH:mm): 10:30
    Alarm set for 10:30
When the alarm triggers:

       ```bash

    ALARM! ALARM! ALARM! ⏰
    Press 'S' to snooze or 'O' to turn off the alarm.
Snooze the alarm:

    Alarm snoozed for 1 minute(s).
Turn off the alarm:


    Alarm turned off.
Supported Platforms
Windows: Uses winsound.Beep() for beeping.

macOS: Uses afplay to play a system sound.

Linux: Uses the beep utility (must be installed).

Contributing
Contributions are welcome! If you find any issues or want to add new features, feel free to open an issue or submit a pull request.

License
This project is licensed under the MIT License. See the LICENSE file for details.
