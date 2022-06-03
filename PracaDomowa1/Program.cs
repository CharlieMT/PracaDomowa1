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
            DateTime dateTime = new DateTime(1900, 01, 01);
            try
            {
                Console.WriteLine("Podaj dzien urodzenia :");
                if (!int.TryParse(Console.ReadLine(), out int day))
                    throw new Exception("Podano nie prawidłową wartość");

                Console.WriteLine("Podaj miesiac w ktorym sie urodziles z zakresu 1-12 :");
                if (!int.TryParse(Console.ReadLine(), out int month))
                    throw new Exception("Podano nie prawidłową wartość");

                Console.WriteLine("Podaj rok w ktorym sie urodzileś :");
                if (!int.TryParse(Console.ReadLine(), out int year))
                    throw new Exception("Podano nie prawidłową wartość");

                if (year > DateTime.Now.Year)
                    throw new Exception("Nie mogles urodzic sie w przyszlosci :)");

                if (month > 12 || month < 1)
                    throw new Exception("Podano zla wartosc dla miesiaca :)");

                if (DateTime.DaysInMonth(year, month) < day || day < 1)
                    throw new Exception("Podano zla wartosc dla dnia miesiaca :)");

                dateTime = new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dateTime;

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
