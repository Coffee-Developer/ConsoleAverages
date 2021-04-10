using System;

namespace ConsoleAverages
{
    internal enum Averages
    {
        Arithmetic = 1,
        Weighted,
        Harmonic,
        Geometric,
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        Start:
            Console.Clear();
            Console.WriteLine("==========================\nWELLCOME TO MY PROGRAM\n==========================\n");

            if (Average.averages.Count == 0)
                Console.WriteLine("Select the average you want to calculate or exit writing -1: \n\n1. Arithmetic\n\n2. Weighted\n\n3. Harmonic\n\n4. Geometric\n");
            else
                Console.WriteLine("Select the average you want to calculate, exit writing -1 or Manage your averages: \n\n1. Arithmetic\n\n2. Weighted\n\n3. Harmonic\n\n4. Geometric\n\n5. Manage\n");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    Average.Calculate((Averages)int.Parse(option));
                    goto Start;

                case "5":
                    if (Average.averages.Count == 0)
                    {
                        Console.WriteLine("Write a valid value !");
                        Console.ReadLine();
                        goto Start;
                    }
                    else AverageManage.Menu();
                    goto Start;

                case "-1":
                    break;

                default:
                    Console.WriteLine("Write a valid value !");
                    Console.ReadLine();
                    goto Start;
            }
        }
    }
}