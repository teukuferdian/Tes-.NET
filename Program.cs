using System;

class Program
{
    static void Main(string[] args)
    {
        var parkingSystem = new ParkingSystem();

        while (true)
        {
            Console.WriteLine("Masukkan perintah:");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Perintah tidak vid. Silakan coba lagi.");
                continue;
            }

            var commands = input.Split(' ');
            if (commands.Length == 0)
            {
                Console.WriteLine("Perintah tidak valid. Silakan coba lagi.");
                continue;
            }

            switch (commands[0].ToLower())
            {
                case "buat_tempat_parkir":
                    if (commands.Length == 2 && int.TryParse(commands[1], out int numberOfSlots))
                    {
                        parkingSystem.CreateParkingLot(numberOfSlots);
                    }
                    else
                    {
                        Console.WriteLine("Jumlah slot tidak valid. Gunakan: buat_tempat_parkir [jumlah_slot]");
                    }
                    break;
                case "parkir":
                    if (commands.Length == 4)
                    {
                        parkingSystem.Park(commands[1], commands[2], commands[3]);
                    }
                    else
                    {
                        Console.WriteLine("Perintah parkir tidak valid. Gunakan: parkir [nomor_pendaftaran] [warna] [jenis]");
                    }
                    break;
                case "keluar":
                    if (commands.Length == 2 && int.TryParse(commands[1], out int slotNumber))
                    {
                        parkingSystem.Leave(slotNumber);
                    }
                    else
                    {
                        Console.WriteLine("Perintah keluar tidak valid. Gunakan: keluar [nomor_slot]");
                    }
                    break;
                case "status":
                    parkingSystem.Status();
                    break;
                case "tipe_kendaraan":
                    if (commands.Length == 2)
                    {
                        parkingSystem.TypeOfVehicles(commands[1]);
                    }
                    else
                    {
                        Console.WriteLine("Perintah tipe_kendaraan tidak valid. Gunakan: tipe_kendaraan [jenis]");
                    }
                    break;
                case "nomor_pendaftaran_kendaraan_dengan_pelat_ganjil":
                    parkingSystem.RegistrationNumbersForVehiclesWithOddPlate();
                    break;
                case "nomor_pendaftaran_kendaraan_dengan_pelat_genap":
                    parkingSystem.RegistrationNumbersForVehiclesWithEvenPlate();
                    break;
                case "nomor_pendaftaran_kendaraan_dengan_warna":
                    if (commands.Length == 2)
                    {
                        parkingSystem.RegistrationNumbersForVehiclesWithColour(commands[1]);
                    }
                    else
                    {
                        Console.WriteLine("Perintah nomor_pendaftaran_kendaraan_dengan_warna tidak valid. Gunakan: nomor_pendaftaran_kendaraan_dengan_warna [warna]");
                    }
                    break;
                case "nomor_slot_kendaraan_dengan_warna":
                    if (commands.Length == 2)
                    {
                        parkingSystem.SlotNumbersForVehiclesWithColour(commands[1]);
                    }
                    else
                    {
                        Console.WriteLine("Perintah nomor_slot_kendaraan_dengan_warna tidak valid. Gunakan: nomor_slot_kendaraan_dengan_warna [warna]");
                    }
                    break;
                case "nomor_slot_untuk_nomor_pendaftaran":
                    if (commands.Length == 2)
                    {
                        parkingSystem.SlotNumberForRegistrationNumber(commands[1]);
                    }
                    else
                    {
                        Console.WriteLine("Perintah nomor_slot_untuk_nomor_pendaftaran tidak valid. Gunakan: nomor_slot_untuk_nomor_pendaftaran [nomor_pendaftaran]");
                    }
                    break;
                case "exit":
                    Console.WriteLine("Keluar dari sistem.");
                    return;
                default:
                    Console.WriteLine("Perintah tidak dikenal. Silakan coba lagi.");
                    break;
            }
        }
    }
}
