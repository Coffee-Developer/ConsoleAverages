using System;

namespace ConsoleAverages
{
    internal class AverageManage
    {
        public static void Menu()
        {
        Start:
            Console.Clear();
            Console.WriteLine("1. See all averages\n\n2. Delete all averages\n\n3. Delete all averages by ID\n");
            switch (Console.ReadLine())
            {
                case "-1":
                    break;

                case "1":
                    Average.Show();
                    goto Start;

                case "2":
                    DeleteAll();
                    goto Start;

                case "3":
                    DeleteByID();
                    goto Start;

                default:
                    Console.WriteLine("Write a valid value !");
                    Console.ReadLine();
                    goto Start;
            }
        }

        private static void DeleteAll()
        {
            Console.Clear();
            Average.averages.Clear();
            Console.WriteLine("All averages were deleted !");
            Console.ReadLine();
        }

        private static void DeleteByID()
        {
            Console.Clear();
            Console.Write("Write the ID: ");
            string ID = Console.ReadLine();
            Console.Clear();
            if (Average.averages.Exists(average => average.ID == ID))
            {
                Average.averages.RemoveAll(average => average.ID == ID);
                Console.WriteLine($"All averages with ID {ID} were deleted !");
            }
            else Console.WriteLine($"The ID {ID} doesn't exist !");
            Console.ReadLine();
        }
    }
}