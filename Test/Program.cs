using System;
using System.Collections.Generic;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Введите размер mass");
            //int count1 = 0;
            //while (true)
            //{
            //    Console.Write("Введите число: ");
            //    string count = Console.ReadLine();
            //    if (int.TryParse(count, out count1))
            //    {
            //        break;
            //    }

            //    Console.WriteLine("Не удалось распознать число, попробуйте еще раз.");
            //}
            //Console.WriteLine();

            //var sortmass = SortByMass(RandomStroc(count1));
            //for (int i = 0; i < sortmass.Length; i++)
            //{
            //    Console.WriteLine(sortmass[i]);
            //}
            List<Animal> animal = new List<Animal>();
            animal.Add(new Fish("Любая рыба","буль-буль-буль"));
            animal.Add(new Rabbit("белый кролик", "пищит"));
            animal.Add(new Tiger("бенгальский тишр", "Р-р-р-р-р-р"));
            animal.Add(new Dragon("Красный дракон", "Рау-ррр-рау"));
            foreach(var item in animal)
            {
                Console.WriteLine(item);
            }
          

        }
        public static string[] RandomStroc(int count)
        {
           ;
            Random random = new Random();
            string[] vs = new string[count];
            for(int i = 0; i < count; i++)
            {
                vs[i] = "Hello World!" + " " + i;
            }
            return vs;
        }
        public static string[] SortByMass(string[] vs)
        {
            int a = 0;
            string[] result = new string[vs.Length];
            for(int i = 0;i < vs.Length;i++)
            {
                if(i % 2 == 0)
                {
                    result[a] = vs[i];
                    a++;
                }
            }
            return result;
        }
    }
}
