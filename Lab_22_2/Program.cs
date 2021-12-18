using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_22_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Введите размер массива ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(1, 10);
                Console.WriteLine("{0}  ", array[i]);
            }

            Action action = () =>
            {
                int S = 0;
                for (int i = 0; i < n; i++)
                {
                    S += array[i];
                }
                int sum = S;
                Console.WriteLine("Сумма = {0}", sum);
                Thread.Sleep(1000);
            };

            Task task1 = new Task(action);

            Action<Task> actionTask = (Task)=>
            {
                int maxValue = array.Max();
                Console.WriteLine("Максимальное значение массива = {0}", maxValue);
            };
            Task task2 = task1.ContinueWith(actionTask);

            task1.Start();

            Console.ReadKey();
        }
        
    }
}
