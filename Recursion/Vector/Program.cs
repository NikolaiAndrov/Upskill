namespace Vector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            GenerateVector(vector, 0);
        }

        static void GenerateVector(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write(vector[i]);
                }
                Console.WriteLine();
                return;
            }

            vector[index] = 0;
            GenerateVector(vector, index + 1);

            vector[index] = 1;
            GenerateVector(vector, index + 1);
        }
    }
}
