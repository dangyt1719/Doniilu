using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal R;

            var array = GetArray();
            var value = GetValue();
            var search_value = SearchNeighboard(array, value);
            if(search_value==null)
            {
                Console.WriteLine("Наиболее близкий к указанному значению элемент массива не найден");
            }
            else
            {
                Console.WriteLine($"Наиболее близкий к указанному значению элемент массива:{search_value}");
            }
            var modified_array = Plusplus(array);

            Console.WriteLine($"Измененный массив:{string.Join(" ", modified_array)}");

            var nechetnye = NotMode2(array);

            Console.WriteLine($"Индексы нечетных элементов массивв:{string.Join(" ", nechetnye)}");


            Console.ReadKey();


        }
        private static double[] GetArray()
        {
            bool is_valid_array = false;
            while (!is_valid_array)
            {
                try
                {
                    Console.WriteLine("Введите элементы массив через пробел");
                    double[] array = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);
                    is_valid_array = true;
                    return array.Cast<double>().ToArray();
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return new List<double>().ToArray();
        }
        private static double GetValue()
        {
            double R;
            bool valid_value = false;
            while (!valid_value)
            {
                Console.WriteLine("Введите вещественное число");
                var enter = Console.ReadLine();
                try
                {
                    R = Convert.ToDouble(enter);
                    valid_value = true;
                    return R;
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return default;
        }

        private static double SearchNeighboard(double[] array, double value)
        {
            double t = double.MaxValue;
            double result = 0;
            for (int j=0; j < array.Length; j++)
			{

                double a = Math.Abs(Math.Abs(array[j]) - Math.Abs(value));
                if (a < t)
                {
                    result = array[j];
                    t = a;
                }
            }
            return result;
        }

        private static double[] Plusplus(double[] array)
		{
            for(int i=1; i<array.Length-1; i++)
			{
				if (array[i] % 2 == 0)
				{
                    array[i] += array[array.Length - 1];
				}
			}
            return array;
		}
        private static List<int> NotMode2(double[] array)
        {
            var result = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    result.Add(i);
                }
            }
            return result;
        }

    }
    
}
