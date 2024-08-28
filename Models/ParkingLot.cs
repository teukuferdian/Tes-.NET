using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    public int SlotNumber { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Mobil atau Motor

    public ParkingLot(int slotNumber)
    {
        SlotNumber = slotNumber;
    }

    public bool IsAvailable()
    {
        return string.IsNullOrEmpty(RegistrationNumber);
    }

    public void Park(string registrationNumber, string color, string type)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        Type = type;
    }

    public void Leave()
    {
        RegistrationNumber = string.Empty;
        Color = string.Empty;
        Type = string.Empty;
    }
}

public class ParkingSystem
{
    private List<ParkingLot> parkingLots = new List<ParkingLot>();

    public void CreateParkingLot(int numberOfSlots)
    {
        parkingLots.Clear();
        for (int i = 1; i <= numberOfSlots; i++)
        {
            parkingLots.Add(new ParkingLot(i));
        }
        Console.WriteLine($"Telah dibuat tempat parkir dengan {numberOfSlots} slot.");
    }

    public void Park(string registrationNumber, string color, string type)
    {
        if (type != "Mobil" && type != "Motor")
        {
            Console.WriteLine("Hanya 'Mobil' dan 'Motor' yang diizinkan.");
            return;
        }

        var availableLot = parkingLots.FirstOrDefault(lot => lot.IsAvailable());
        if (availableLot != null)
        {
            availableLot.Park(registrationNumber, color, type);
            Console.WriteLine($"Slot parkir yang ditambahkan: {availableLot.SlotNumber}");
        }
        else
        {
            Console.WriteLine("Maaf, tempat parkir penuh.");
        }
    }

    public void Leave(int slotNumber)
    {
        var lot = parkingLots.FirstOrDefault(l => l.SlotNumber == slotNumber);
        if (lot != null && !lot.IsAvailable())
        {
            lot.Leave();
            Console.WriteLine($"Slot nomor {slotNumber} telah kosong.");
        }
        else
        {
            Console.WriteLine($"Slot nomor {slotNumber} sudah kosong atau tidak ada.");
        }
    }

    public void Status()
    {
        Console.WriteLine("No. Slot    Nomor Pendaftaran    Warna    Jenis");
        foreach (var lot in parkingLots.Where(lot => !lot.IsAvailable()))
        {
            Console.WriteLine($"{lot.SlotNumber,-10} {lot.RegistrationNumber,-20} {lot.Color,-10} {lot.Type,-10}");
        }
    }

    public void TypeOfVehicles(string type)
    {
        if (type != "Mobil" && type != "Motor")
        {
            Console.WriteLine("Jenis kendaraan tidak valid. Hanya 'Mobil' dan 'Motor' yang diizinkan.");
            return;
        }

        var count = parkingLots.Count(lot => lot.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Jumlah kendaraan {type}: {count}");
    }

    public void RegistrationNumbersForVehiclesWithOddPlate()
    {
        var oddPlates = parkingLots
            .Where(lot => !lot.IsAvailable() && IsOddPlate(lot.RegistrationNumber))
            .Select(lot => lot.RegistrationNumber);

        Console.WriteLine("Nomor pendaftaran dengan plat ganjil:");
        Console.WriteLine(string.Join(", ", oddPlates));
    }

    public void RegistrationNumbersForVehiclesWithEvenPlate()
    {
        var evenPlates = parkingLots
            .Where(lot => !lot.IsAvailable() && !IsOddPlate(lot.RegistrationNumber))
            .Select(lot => lot.RegistrationNumber);

        Console.WriteLine("Nomor pendaftaran dengan plat genap:");
        Console.WriteLine(string.Join(", ", evenPlates));
    }

    public void RegistrationNumbersForVehiclesWithColour(string color)
    {
        var registrations = parkingLots
            .Where(lot => !lot.IsAvailable() && lot.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(lot => lot.RegistrationNumber);

        Console.WriteLine($"Nomor pendaftaran kendaraan dengan warna {color}:");
        Console.WriteLine(string.Join(", ", registrations));
    }

    public void SlotNumbersForVehiclesWithColour(string color)
    {
        var slots = parkingLots
            .Where(lot => !lot.IsAvailable() && lot.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(lot => lot.SlotNumber);

        Console.WriteLine($"Nomor slot kendaraan dengan warna {color}:");
        Console.WriteLine(string.Join(", ", slots));
    }

    public void SlotNumberForRegistrationNumber(string registrationNumber)
    {
        var slot = parkingLots
            .FirstOrDefault(lot => lot.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));

        if (slot != null)
        {
            Console.WriteLine($"Nomor slot untuk nomor pendaftaran {registrationNumber}: {slot.SlotNumber}");
        }
        else
        {
            Console.WriteLine("Nomor pendaftaran tidak ditemukan.");
        }
    }

    private bool IsOddPlate(string registrationNumber)
    {
        if (string.IsNullOrEmpty(registrationNumber))
        {
            return false;
        }

        var lastChar = registrationNumber.Last();
        return char.IsDigit(lastChar) && (lastChar - '0') % 2 != 0;
    }
}
