using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] array = new int[21];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10, 101); 
            }

            Console.WriteLine("Початковий масив:");
            PrintArray(array);

            SelectionSort(array);

            Console.WriteLine("\nВідсортований масив:");
            PrintArray(array);

            Console.Write("\nВведіть ключове значення: ");
            int key = int.Parse(Console.ReadLine());

            int count = Count(array, key);
            Console.WriteLine($"\nКількість входжень значення {key} в масиві: {count}");

            int index = BinarySearch(array, key);
            if (index != -1)
            {
                Console.WriteLine($"\nЗначення {key} знайдено у масиві на позиції {index}");
            }
            else
            {
                Console.WriteLine($"\nЗначення {key} не знайдено у масиві");
            }
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }

        static int Count(int[] array, int key)
        {
            int count = 0;
            foreach (int number in array)
            {
                if (number == key)
                {
                    count++;
                }
            }
            return count;
        }
        static int BinarySearch(int[] array, int key)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == key)
                {
                    return mid;
                }
                else if (array[mid] < key)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1; 
        }

        static void PrintArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}