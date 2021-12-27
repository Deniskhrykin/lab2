using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            HDD hdd = new HDD();

            int choise = -1;

            while(choise != 0)
            {
                menu();
                Console.Write("операция: ");
                choise = int.Parse(Console.ReadLine());

                string filename;
                int length;
                switch(choise)
                {
                    case 1:
                        Console.Write("\nимя файла: ");
                        filename = Console.ReadLine();

                        Console.Write("размер: ");
                        length = int.Parse(Console.ReadLine());

                        if (!hdd.Write(new MyFileInfo(filename, length)))
                        {
                            Console.WriteLine("Недостаточно места для записи.");
                        }
                        break;
                    case 2:
                        Console.Write("\nимя файла: ");
                        filename = Console.ReadLine();

                        Console.Write("размер: ");
                        length = int.Parse(Console.ReadLine());

                        if (!hdd.Delete(new MyFileInfo(filename, length)))
                        {
                            Console.WriteLine("Файл не найден.");
                        }
                        break;
                    case 3:
                        Console.WriteLine(hdd.GetInfo());
                        break;
                    default:
                        Console.WriteLine("Попробуйте еще раз.");
                        break;
                }
            }
        }

        static void menu()
        {
            Console.WriteLine("\nВыберите действие: ");
            Console.WriteLine("1. Добавить файл.");
            Console.WriteLine("2. Удалить файл.");
            Console.WriteLine("3. Показать информацию о памяти.");
            Console.WriteLine("0. Выход.");
        }
    }
}
