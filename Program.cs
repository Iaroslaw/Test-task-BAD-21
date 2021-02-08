using System;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        //Общее количество элементов в файле
        static int Amount_of_numbers(int Amount)
        {
            string path = @"D:\Всякие загрузки\10m_2021\10m_2021.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Amount++;
                }
            }
            return Amount;
        }

        static void Main(string[] args)
        {
            //Время на данный момент
            long Time = DateTime.Now.Second;

            //Общее количество элементов в файле
            int Amount = 0;
            Amount = Amount_of_numbers(Amount);

            //Чтение файла
            int[] arr_0 = new int[Amount];
            string path = @"D:\Всякие загрузки\10m_2021\10m_2021.txt";
            int mistake = 0;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        arr_0[i] = int.Parse(line);
                    }
                    catch
                    {
                        mistake++;
                    }
                    i++;
                }
            }

            //Наибольшая последовательность идущих подряд чисел, которые увеличиваются
            int start_high = 0;
            int end_high = 0;
            int Index_high = 0;
            while (Index_high < arr_0.Length - 1)
            {
                int current_start = Index_high;
                while (Index_high < arr_0.Length - 1 && arr_0[Index_high] < arr_0[Index_high + 1])
                {
                    Index_high++;
                }
                if (Index_high - current_start > end_high - start_high)
                {
                    start_high = current_start;
                    end_high = Index_high;
                }
                while (Index_high < arr_0.Length - 1 && arr_0[Index_high] >= arr_0[Index_high + 1])
                {
                    Index_high++;
                }
            }

            //Вывод наибольшей последовательности идущих подряд чисел, которые уменьшаются
            int start_low = 0;
            int end_low = 0;
            int Index_low = 0;
            while (Index_low < arr_0.Length - 1)
            {
                int current_start = Index_low;
                while (Index_low < arr_0.Length - 1 && arr_0[Index_low] > arr_0[Index_low + 1])
                {
                    Index_low++;
                }
                if (Index_low - current_start > end_low - start_low)
                {
                    start_low = current_start;
                    end_low = Index_low;
                }
                while (Index_low < arr_0.Length - 1 && arr_0[Index_low] <= arr_0[Index_low + 1])
                {
                    Index_low++;
                }
            }

            //Максимальное и минимальное число в файле
            double max = 0;
            double min = 0;
            double[] arr_sort = new double[arr_0.Length];
            for (int i = 0; i < arr_0.Length; i++)
            {
                arr_sort[i] = arr_0[i];
            }
            Array.Sort(arr_sort);
            min = arr_sort[0];
            max = arr_sort[arr_sort.Length - mistake];

            //Медиана числа
            double mediana = 0;
            if ((arr_sort.Length - mistake) % 2 == 0)
            {
                mediana = (arr_sort[(arr_sort.Length - mistake) / 2] + arr_sort[(arr_sort.Length - mistake) / 2 - 1]) / 2.0;
            }
            else
            {
                mediana = arr_sort[(arr_sort.Length - mistake) / 2];
            }

            //Среднее арифметическое число
            double sum = 0;
            for (int i = 0; i < arr_sort.Length; i++)
            {
                sum = sum + arr_sort[i];
            }
            double average = sum / (arr_sort.Length - mistake);

            //Вывод максимального и минимального числа
            Console.WriteLine("Минимальное число: " + min);
            Console.WriteLine("Максимальное число: " + max);

            //Вывод медианы
            Console.WriteLine("Медиана: " + mediana);

            //Вывод среднего арифметического числа
            Console.WriteLine("Среднее арифметическое число: " + average);

            //Вывод наибольшей последовательности идущих подряд чисел, которые увеличиваются
            Console.WriteLine("Наибольшая последовательность идущих подряд чисел, которые увеличиваются:");
            for (int i = start_high; i <= end_high; i++)
            {
                Console.WriteLine(arr_0[i]);
            }

            //Вывод наибольшей последовательности идущих подряд чисел, которые уменьшаются
            Console.WriteLine("Наибольшая последовательность идущих подряд чисел, которые уменьшаются:");
            for (int i = start_low; i <= end_low; i++)
            {
                Console.WriteLine(arr_0[i]);
            }

            //Время выполнения программы
            Time = (DateTime.Now.Second - Time);
            Console.WriteLine("Время: " + Time + " секунд");
            Console.ReadKey();
        }
    }
}
