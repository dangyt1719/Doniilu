using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersPolicy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа через пробел");

            var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);

            var result = arr.GroupBy(x => x).Where(w => w.Count() > 1).Select(s => s.Key).ToList();

            var result2 = new HashSet<int>();

            for(int i = 0; i < arr.Length; i++)
            {
                var exist = false;

                for(int j=i+1; j< arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    { 
                        result2.Add(arr[i]);
                        exist= true;
                        break;
                    }
                }

                if (exist) continue;
            }

            Console.WriteLine($"Повторяющиеся значения (алгоритм №1):{string.Join(" ", result)}");

            Console.WriteLine($"Повторяющиеся значения (алогритм №2):{string.Join(" ", result2)}");

            Console.ReadKey();
        }
    }
}
