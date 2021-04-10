using System;
using System.Collections.Generic;

namespace ConsoleAverages
{
    internal class Average
    {
        public string ID;
        public float average;
        public float[] values;
        public Averages type;
        public DateTime creationDate;

        private Average(string ID, Averages type, float average, float[] values, DateTime creationDate)
        {
            this.ID = ID;
            this.type = type;
            this.average = average;
            this.values = values;
            this.creationDate = creationDate;
        }

        public static List<Average> averages = new List<Average>();

        public static void Calculate(Averages average)
        {
            string ID = GetID();
            float[] values = GetValues();
            float averageRes = 0;

            switch (average)
            {
                case Averages.Arithmetic:
                    averageRes = AverageFormulas.Arithmetic(values);
                    break;

                case Averages.Weighted:
                    averageRes = AverageFormulas.Weighted(values);
                    break;

                case Averages.Harmonic:
                    averageRes = AverageFormulas.Harmonic(values);
                    break;

                case Averages.Geometric:
                    averageRes = AverageFormulas.Geometric(values);
                    break;
            }
            var Useraverage = new Average(ID, average, averageRes, values, DateTime.Now);
            averages.Add(Useraverage);
            Console.Clear();
            Show(Useraverage);
            Console.ReadLine();
        }

        public static void Show()
        {
            Console.Clear();
            averages.ForEach(average => Show(average));
            Console.ReadLine();
        }

        private static string GetID()
        {
            Console.Clear();
            Console.Write("Write the average ID: ");
            return Console.ReadLine().Trim();
        }

        private static float[] GetValues()
        {
            float[] values = Array.Empty<float>();
        Start:
            Console.Clear();
            Console.Write("Write the average values separated by comma with period ( ; ): ");

            try { values = Array.ConvertAll(Console.ReadLine().Split(';'), value => float.Parse(value)); }
            catch (Exception)
            {
                Console.WriteLine("\nInvalid value !");
                Console.ReadLine();
                goto Start;
            }

        Checking:
            Console.Clear();
            Console.Write("Are these your values ?: ");
            for (int i = 0; i < values.Length; i++) Console.Write($"{values[i]} ");
            Console.WriteLine("\nS / N");
            switch (Console.ReadLine())
            {
                case "S":
                case "s":
                    return values;

                case "N":
                case "n":
                    goto Start;

                default:
                    goto Checking;
            }
        }

        private static void Show(Average average)
        {
            Console.Write($"ID: {average.ID}\nType: {average.type}\nAverage result: {average.average}\nCreation data: {average.creationDate}\nValues: ");
            for (int i = 0; i < average.values.Length; i++) Console.Write($"{average.values[i]} ");
            Console.WriteLine("\n");
        }
    }
}