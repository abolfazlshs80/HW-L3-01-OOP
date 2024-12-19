using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tools.ConsoleDesign
{
    public class ConsoleDesign
    {

        public static void Menu(string Title = "Menu", ConsoleColor Color = ConsoleColor.Green)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine($"║             Welcome to Menu    ║");
            Console.WriteLine("╠════════════════════════════════╣");
            Console.WriteLine("║ 1. Show books                  ║");
            Console.WriteLine("║ 2. Chage Book  Status          ║");
            Console.WriteLine("║ 3. Find Book                   ║");
            Console.WriteLine("║ 4. Add Book                    ║");
            Console.WriteLine("║ 5. Exit                        ║");
            Console.WriteLine("╚════════════════════════════════╝");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void MenuForHospital(string Title = "Menu", ConsoleColor Color = ConsoleColor.Green)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine($"║Welcome to Menu For Hospital    ║");
            Console.WriteLine("╠════════════════════════════════╣");
            Console.WriteLine("║ 1. List Of Patient             ║");
            Console.WriteLine("║ 2. List Of Docter              ║");
            Console.WriteLine("║ 3. List Of Room                ║");
            Console.WriteLine("║ 4. Insert Of Patient           ║");
            Console.WriteLine("║ 5. Insert Of Docter            ║");
            Console.WriteLine("║ 6. Insert Of Room              ║");
            Console.WriteLine("║ 7. Handel Patient By Doctor    ║");
            Console.WriteLine("║ 8. Delete Patient Form Hospital║");
            Console.WriteLine("║ 8. Exit                        ║");
            Console.WriteLine("╚════════════════════════════════╝");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void MenuForProduct(string Title = "Menu", ConsoleColor Color = ConsoleColor.Green)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine($"║        Welcome to Menu         ║");
            Console.WriteLine("╠════════════════════════════════╣");
            Console.WriteLine("║ 1. Show   Product              ║");
            Console.WriteLine("║ 2. Insert Electronic Product   ║");
            Console.WriteLine("║ 3. Insert Clothing Product     ║");
            Console.WriteLine("║ 4. Set OffPrice For Product    ║");
            Console.WriteLine("║ 5. Exit                        ║");
            Console.WriteLine("╚════════════════════════════════╝");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void MenuForTable(string Title, ConsoleColor Color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"                            {Title}                                   ");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public static void Message(string Title, ConsoleColor Color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"                            {Title}                                   ");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        public static void ContentForTable(ConsoleColor Color = ConsoleColor.Yellow)
        {

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{"ID",-5} | {"Title",-20} | {"Author",-15} | {"ISBN",-10} | {"IsAvailable",-6}");


            Console.WriteLine(new string('-', 65));

        }

        public static void ContentPatientForTable(ConsoleColor Color = ConsoleColor.Yellow)
        {

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{"Id",-5} | {"Name",-20} | {"Room",-15} | {"PatientId",-10} | {"MedicalHistory",-6}");


            Console.WriteLine(new string('-', 65));

        }

        public static void ContentDoctorForTable(ConsoleColor Color = ConsoleColor.Yellow)
        {

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{"Id",-5} | {"Name",-20} | {"Age",-5} | {"DoctorId",-10} | {"Specialization",-6}");


            Console.WriteLine(new string('-', 65));

        }
   
        public static void ContentRoomForTable(ConsoleColor Color = ConsoleColor.Yellow)
        {

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{"Capacity",-5} | {"RoomNumber",-20} ");


            Console.WriteLine(new string('-', 65));

        }
        public static void ContentForTableInProduct(ConsoleColor Color = ConsoleColor.Yellow)
        {

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{"ID",-5} | {"Name",-20} | {"Price",-15} | {"Size/Date",-10} | {"Material",-6}");


            Console.WriteLine(new string('-', 65));

        }
        public static void HeaderInput(string Message)
        {

        }
        public static object InputValidation(string Message, bool isDigit = true, string Title = "Menu")
        {

            //Console.Clear();
            //MenuForTable("Change Of Book");

            if (isDigit)
            {
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.Write($"║ {Message} ");
                int Number;
                bool NumberStatus = int.TryParse(Console.ReadLine(), out Number);
                Console.WriteLine("╚══════════════════════════════════════════════╝");

                while (!NumberStatus)
                {
                    Console.WriteLine("╔══════════════════════════════════════════════╗");
                    Console.Write($"║ {Message} ");
                    NumberStatus = int.TryParse(Console.ReadLine(), out Number);
                    Console.WriteLine("╚══════════════════════════════════════════════╝");

                }

                return Number;
            }
            else
            {
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.Write($"║ {Message} ");

                string Number = Console.ReadLine();
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                bool status = Number == null;
                if (status)
                {
                    while (status)
                    {
                        Console.WriteLine("╔══════════════════════════════════════════════╗");
                        Console.Write($"║ {Message} ");
                        Number = Console.ReadLine();
                        Console.WriteLine("╚══════════════════════════════════════════════╝");

                    }


                }
                return Number;
            }

            //  return "";
        }

    }
}
