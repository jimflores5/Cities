using System;
using System.Collections.Generic;
using Cities.Comparers;

namespace Cities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<City> cities = CityDataImporter.LoadData();
            IComparer<City> comparer;

            Console.WriteLine("Choose to sort by: \n" +
                "1) City name \n" +
                "2) State name \n" +
                "3) Population \n" +
                "4) Area");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                comparer = new NameComparer();
            }
            else if(choice == "2")
            {
                comparer = new StateComparer();
            }
            else if (choice == "3")
            {
                comparer = new PopulationComparer();
            }
            else
            {
                comparer = new AreaComparer();
            }

            // TODO Swap out comparers as desired
            //IComparer<City> comparer = new NameComparer();
            //IComparer<City> comparer = new StateComparer();
            //IComparer<City> comparer = new PopulationComparer();
            //IComparer<City> comparer = new AreaComparer();

            cities.Sort(comparer);

            PrintCities(cities);

            Console.ReadLine();
        }

        private static void PrintCities(List<City> cities)
        {
            Console.WriteLine(City.GetTableHeader());

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}
