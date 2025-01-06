### **README.md for JavaScript Version**

```markdown
# Alarm Clock - JavaScript Version

This is the **JavaScript version** of the Alarm Clock project, created as part of CS305 at the International University of Sarajevo. The project demonstrates proficiency in JavaScript by implementing a simple alarm clock with a 7-segment display imitation.

---

## Features

- **Set Alarm**: Users can input a future time in `HH:mm` format to set an alarm.
- **Real-Time Clock Display**: The current time is displayed in a **7-segment display imitation** using ASCII art, updating every second.
- **Alarm Notification**: When the alarm time is reached, the application plays a **beep sound** and displays a notification.
- **Snooze Functionality**: Users can snooze the alarm for a predefined duration (default: 1 minute).
- **Turn Off Alarm**: Users can turn off the alarm completely.

---

## Installation and Usage

### Prerequisites
- [Node.js](https://nodejs.org/) (v14 or higher)
- [npm](https://www.npmjs.com/) (comes with Node.js)
```
###Steps to Run the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/alarmclock.git
   ```
2. Navigate to the `javascript` branch:
   ```bash
   git checkout javascript
   ```
3. Install dependencies:
   ```bash
   npm install
   ```
4. Run the project:
   ```bash
   node index.js
   ```

---

## Project Structure

```
alarmclock/
├── index.js              # Main JavaScript file
├── package.json          # Project dependencies and configuration
├── README.md             # This file
└── .gitignore            # Files and directories to ignore in Git
```

---

## How It Works

1. The program starts by displaying the current time in a **7-segment display imitation**.
2. Users can set an alarm by entering a time in `HH:mm` format.
3. When the alarm time is reached:
   - The application plays a beep sound.
   - Users can snooze the alarm or turn it off.

---

## Example Output

### Time Display
```
    ╔══════════════════════════════╗
    ║                              ║
    ║          14:25:03            ║
    ║                              ║
    ╚══════════════════════════════╝
```

### Alarm Notification
```
ALARM! ALARM! ALARM! ⏰
Press 'S' to snooze or 'O' to turn off the alarm.
```

---

## Contributing

If you would like to contribute to this project, please follow the standard Git workflow:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/my-new-feature`.
3. Commit your changes: `git commit -am 'Add some feature'`.
4. Push to the branch: `git push origin feature/my-new-feature`.
5. Submit a pull request.

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Team

This project was completed by:
- Munever Hasanovic
- Harun Subasic
- Amra Hozic
```
