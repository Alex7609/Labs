using System;

namespace PZ2
{
    internal class Task_1
    {
        public void Run()
        {
            int[][] Array = new int[3][];

            InitializationArrayRandom(Array);
            PrintArray(Array);
            
            for (int i = 0; i < Array.Length; i++)
            {
                AvarageGroup(Array[i], i);
            }
            for (int i = 0; i < Array.Length; i++)
            {
                MinGradesGroup(Array[i], i);
            }
            for (int i = 0; i < Array.Length; i++)
            {
                MaxGradesGroup(Array[i], i);
            }

            AvarageAllGroup(Array);
            MinGradesAllGroup(Array);
            MaxGradesAllGroup(Array);
        }

        public void InitializationArrayRandom(int[][] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[random.Next(10,31)];

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = random.Next(0, 101);
                }
            }
        }

        public void PrintArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Row{i}:");
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.WriteLine(array[i][j]);
                }
                Console.WriteLine();
            }
        }



        public void AvarageGroup(int[] array, int index)
        {
            double AvarageGroup = 0;
            double Sum = 0;
            for (int i = 0; i < array.Length ; i++)
            {
                Sum += array[i];
            }
            AvarageGroup = Sum / array.Length;
            Console.WriteLine($"Avarage group {index}: {AvarageGroup}");
        }

        public void AvarageAllGroup(int[][] array)
        {
            double AvarageAllGroup = 0;
            double Sum = 0;
            int TotalStudents = 0;
            for (int i = 0;i < array.Length ; i++)
            {
                for(int j = 0;j < array[i].Length; j++)
                {
                    Sum += array[i][j];
                    TotalStudents++;
                }
                
            }
            AvarageAllGroup = Sum / TotalStudents;
            Console.WriteLine($"Avarage all group: {AvarageAllGroup}");
        }

        public void MinGradesGroup(int[] array, int index)
        {
            int Min = array[0];
            for(int i = 1; i < array.Length ; i++)
            {
                if (array[i] < Min) Min = array[i];
            }
            Console.WriteLine($"Minimal grades in group {index}: {Min}");
        }

        public void MinGradesAllGroup(int[][]array)
        {
            int Min = array[0][0];
            for (int i = 0;i < array.Length ; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < Min)
                    { 
                        Min = array[i][j]; 
                    }
                }
            }
            Console.WriteLine($"Minimal grade all group {Min}");
        }

        public void MaxGradesGroup( int[] array, int index)
        {
            int Max = array[0];
            for(int i = 0;  i < array.Length ; i++)
            {
                if (array[i] > Max)
                {
                    Max = array[i];
                }
            }
            Console.WriteLine($"Max grades in group {index} {Max}");
        }

        public void MaxGradesAllGroup(int[][]array)
        {
            int Max = array[0][0];
            for(int i =0; i < array.Length ;i++)
            {
                for(int j = 0; j < array[i].Length;j++)
                {
                    if(array[i][j] > Max)
                    {
                        Max = array[i][j];
                    }

                }
            }
            Console.WriteLine($"Max grade all group: {Max}");
        }


    }
}
