# 🚗 Parking Management System (C# .NET Console App)

A console-based parking management system built using C# and .NET. This application simulates vehicle entry, parking slot allocation, exit processes, and generates reports based on vehicle data.

---

## 🚀 Features

* Vehicle entry & exit management
* Automatic parking slot allocation
* Real-time parking status display
* Command-based interaction (CLI)
* Vehicle reports:

  * Odd/Even license plate detection
  * Vehicle type summary (Car / Motorcycle)
  * Vehicle color grouping

---

## 🛠 Tech Stack

* C#
* .NET (Console Application)

---

## 🧩 System Design

* **Vehicle** → Stores vehicle data (plate number, color, type, check-in time)
* **ParkingLot** → Manages parking slots, vehicle allocation, and reports
* **Program** → Handles user input and command execution

---

## ▶️ How to Run

1. Open the project in **Visual Studio**
2. Build the solution
3. Run the application

Or using CLI:

```bash
dotnet run
```

---

## 🧪 Example Usage

```
create_parking_lot 6
park B-1234-XYZ Red Mobil
park B-5678-ABC Blue Motor
status
leave 1
report
```

### Output:

```
Allocated slot number: 1
Allocated slot number: 2

Slot No. Type   Registration No  Colour
1        Mobil  B-1234-XYZ       Red
2        Motor  B-5678-ABC       Blue

Report by Odd/Even Plates:
Odd Plate Numbers: B-1234-XYZ
Even Plate Numbers: B-5678-ABC

Report by Vehicle Type:
Motorcycles: 1
Cars: 1

Report by Vehicle Color:
Color Red: B-1234-XYZ
Color Blue: B-5678-ABC
```

---

## 💡 Key Concepts

This project demonstrates:

* Object-Oriented Programming (OOP)
* Data structure handling (List, Array)
* Command-based system design
* Basic algorithm & filtering logic

---

## 📌 Notes

This project was created as part of my learning process to strengthen backend logic and system design skills using C#.

---

## 📬 Future Improvements

* Improve data structure using Dictionary for better slot management
* Add validation for license plate format
* Convert into web-based application (ASP.NET / API)
* Add database integration

---
