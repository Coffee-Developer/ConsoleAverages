using System;

namespace ConsoleAverages
{
    internal static class AverageFormulas
    {
        public static float Arithmetic(float[] values)
        {
            float sum = 0;
            for (int i = 0; i < values.Length; i++) sum += values[i];
            return sum / values.Length;
        }

        public static float Weighted(float[] values)
        {
            float sum = 0, sumWeights = 0;
            float[] weights = GetWeights(values);
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i] * weights[i];
                sumWeights += weights[i];
            }
            return sum / sumWeights;
        }

        public static float Harmonic(float[] values)
        {
            float sum = 0;
            for (int i = 0; i < values.Length; i++) sum += 1 / values[i];
            return values.Length / sum;
        }

        public static float Geometric(float[] values)
        {
            float sum = 1;
            for (int i = 0; i < values.Length; i++) sum *= values[i];
            return (float)Math.Pow(sum, 1.0 / values.Length);
        }

        private static float[] GetWeights(float[] values)
        {
            float[] weights = new float[values.Length];
        Start:
            Console.Clear();
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write($"Write the weight of {values[i]}: ");
                try { weights[i] = float.Parse(Console.ReadLine()); }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value !");
                    Console.ReadLine();
                    goto Start;
                }
            }

        Checking:
            Console.Clear();
            Console.Write("Are these your values ?: ");
            for (int i = 0; i < weights.Length; i++) Console.Write($"{values[i]}: {weights[i]}\n");
            Console.WriteLine("\nS / N");
            switch (Console.ReadLine())
            {
                case "S":
                case "s":
                    return weights;

                case "N":
                case "n":
                    goto Start;

                default:
                    goto Checking;
            }
        }
    }
}