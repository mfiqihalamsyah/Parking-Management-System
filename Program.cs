using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public DateTime CheckInTime { get; set; }

        public Vehicle(string licensePlate, string color, string type)
        {
            LicensePlate = licensePlate;
            Color = color;
            Type = type;
            CheckInTime = DateTime.Now;
        }
    }

    public class ParkingLot
    {
        private List<Vehicle> parkedVehicles;
        private int totalSlots;
        private bool[] slots;

        public ParkingLot(int totalSlots)
        {
            this.totalSlots = totalSlots;
            this.slots = new bool[totalSlots];
            this.parkedVehicles = new List<Vehicle>();
        }

        public string ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < totalSlots; i++)
            {
                if (!slots[i])
                {
                    slots[i] = true;
                    parkedVehicles.Add(vehicle);
                    return $"Allocated slot number: {i + 1}";
                }
            }
            return "Sorry, parking lot is full";
        }

        public string LeaveVehicle(int slotNumber)
        {
            if (slotNumber <= 0 || slotNumber > totalSlots || !slots[slotNumber - 1])
            {
                return "Slot not found";
            }

            slots[slotNumber - 1] = false;
            Vehicle vehicle = parkedVehicles.FirstOrDefault(v => v.LicensePlate == parkedVehicles[slotNumber - 1].LicensePlate);
            parkedVehicles.Remove(vehicle);
            return $"Slot number {slotNumber} is free";
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\nSlot No.  Type   Registration No  Colour");
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i])
                {
                    Vehicle vehicle = parkedVehicles.FirstOrDefault(v => v.LicensePlate == parkedVehicles[i].LicensePlate);
                    Console.WriteLine($"{i + 1}        {vehicle.Type}   {vehicle.LicensePlate}  {vehicle.Color}");
                }
            }
        }

        public void GenerateReports()
        {
            var oddPlateVehicles = parkedVehicles.Where(v => int.Parse(v.LicensePlate.Split('-')[1]) % 2 != 0).ToList();
            var evenPlateVehicles = parkedVehicles.Where(v => int.Parse(v.LicensePlate.Split('-')[1]) % 2 == 0).ToList();

            Console.WriteLine("\nReport by Odd/Even Plates:");
            Console.WriteLine("Odd Plate Numbers: " + string.Join(", ", oddPlateVehicles.Select(v => v.LicensePlate)));
            Console.WriteLine("Even Plate Numbers: " + string.Join(", ", evenPlateVehicles.Select(v => v.LicensePlate)));

            Console.WriteLine("\nReport by Vehicle Type:");
            Console.WriteLine("Motorcycles: " + parkedVehicles.Count(v => v.Type == "Motor"));
            Console.WriteLine("Cars: " + parkedVehicles.Count(v => v.Type == "Mobil"));

            Console.WriteLine("\nReport by Vehicle Color:");
            var colorGroups = parkedVehicles.GroupBy(v => v.Color);
            foreach (var group in colorGroups)
            {
                Console.WriteLine($"Color {group.Key}: " + string.Join(", ", group.Select(v => v.LicensePlate)));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot(6);
            string command;
            while (true)
            {
                Console.WriteLine("\nEnter a command (create_parking_lot, park, leave, status, exit, report):");
                command = Console.ReadLine();

                if (command.StartsWith("create_parking_lot"))
                {
                    int slots = int.Parse(command.Split(' ')[1]);
                    parkingLot = new ParkingLot(slots);
                    Console.WriteLine($"Created a parking lot with {slots} slots.");
                }
                else if (command.StartsWith("park"))
                {
                    string[] parts = command.Split(' ');
                    string licensePlate = parts[1];
                    string color = parts[2];
                    string type = parts[3];
                    Vehicle vehicle = new Vehicle(licensePlate, color, type);
                    Console.WriteLine(parkingLot.ParkVehicle(vehicle));
                }
                else if (command.StartsWith("leave"))
                {
                    int slotNumber = int.Parse(command.Split(' ')[1]);
                    Console.WriteLine(parkingLot.LeaveVehicle(slotNumber));
                }
                else if (command == "status")
                {
                    parkingLot.DisplayStatus();
                }
                else if (command == "report")
                {
                    parkingLot.GenerateReports();
                }
                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }
            }
        }
    }
}
