using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaDomowa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringData = CollectStringData();
            var date = CollectDateData();
            var age = AgeCount(date);
            Console.WriteLine($"{stringData} dnia {date} i masz {age} lat");
            Console.ReadLine();
        }

        private static String CollectStringData()
        {
            Console.WriteLine("Podaj swoje Imie :");
            var name = Console.ReadLine();
            Console.WriteLine("Podaj swoje Nazwisko :");
            var lastName = Console.ReadLine();
            Console.WriteLine("Podaj swoje miejsce urodzenia :");
            var birthPlace = Console.ReadLine();

            return $"Nazywasz sie {name}  {lastName}, urodziłeś sie w {birthPlace} ";

        }

        private static DateTime CollectDateData()
        {
            
            while (true)
            {
                Console.WriteLine("Podaj rok w ktorym sie urodzileś :");
                if (!int.TryParse(Console.ReadLine(), out int year) || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Podano nie prawidłową wartość \n Sprobuj jeszcze raz");
                    continue;
                }

                Console.WriteLine("Podaj miesiac w ktorym sie urodziles z zakresu 1-12 :");
                if (!int.TryParse(Console.ReadLine(), out int month) || month > 12 || month < 1)
                {
                    Console.WriteLine("Podano nie prawidłową wartość \n Sprobuj jeszcze raz");
                    continue;
                }

                Console.WriteLine("Podaj dzien urodzenia :");
                if (!int.TryParse(Console.ReadLine(), out int day) || DateTime.DaysInMonth(year, month) < day || day < 1)
                {
                    Console.WriteLine("Podano nie prawidłową wartość \n Sprobuj jeszcze raz");
                    continue;
                }

                var dateTime = new DateTime(year, month, day);
                return dateTime;

            }
        }

        private static int AgeCount(DateTime userDateTime)
        {
            int age = DateTime.Now.Year - userDateTime.Year;

            if (userDateTime.DayOfYear < DateTime.Now.DayOfYear)
                return age;

            return --age;
        }
    }
}
