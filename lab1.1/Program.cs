using System;
using System.IO;

namespace lab1._1
{
    internal class Program
    {
        public static string rand()
        {
            int N;
            string FileName;
            Console.Write("Enter N: ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter file name: ");
            FileName = Console.ReadLine();

            string FullPath = Path.Combine(FileName + ".txt");

            using (var new_out = new StreamWriter(FullPath))
            {
                new_out.WriteLine(N);

                Random r = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < N; i++)
                {
                    int x = r.Next(-100000, 100001);
                    new_out.Write(x + " ");
                }
            }

            Console.WriteLine("File " + FullPath + " was created!");
            return FullPath;
        }

        static void Main(string[] args)
        {
            string inputFilePath = rand();

            using (var new_in = new StreamReader(inputFilePath))
            using (var new_out = new StreamWriter(@"output.txt"))
            {
                int N = Convert.ToInt32(new_in.ReadLine());
                string str_all = new_in.ReadLine();
                string[] str_elem = str_all.Split(' ');

                int[] array = new int[N];
                for (int i = 0; i < N; i++)
                {
                    array[i] = Convert.ToInt32(str_elem[i]);
                }
                //1
                int sum = 0;
                bool chek = false;
                for (int i = 0; i < N; i++)
                {
                    if (array[i] % 10 == 0)
                    {
                        sum += array[i];
                        chek = true;
                    }

                }
                if (chek)
                {
                    new_out.Write(sum + ", ");
                    chek = false;
                }
                else
                {
                    new_out.Write("no items found, ");
                }
                //2
                decimal mul = 1;
                for (int i = 0; i < N; i++)
                {
                    if (array[i] > 0 && array[i] < 1000)
                    {
                        mul *= array[i];
                        chek = true;
                    }

                }
                if (chek)
                {
                    new_out.WriteLine(mul);
                }
                else
                {
                    new_out.WriteLine("no items found");
                }

                //3
               
                bool found = false;
                for (int i = 0; i < N; i++)
                {
                    if (array[i] % 11 == 0)
                    {
                        new_out.Write(array[i] + " ");
                        found = true;
                    }
                }
                if (!found)
                {
                    new_out.Write("no items found");
                }
            }
        }
    }
}
