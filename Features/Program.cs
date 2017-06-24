using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerableDemo();
            //UnderstandingLambdaExpressions();

        }

        private static void UnderstandingLambdaExpressions()
        {
            var cities = new List<string>(){"London", "Paris", "Seattle", "Lisbon"};

            IEnumerable<string> filteredCities = cities.Where(city => city.StartsWith("L"));

            foreach (var city in filteredCities)
            {
                Console.WriteLine(city);
            }

        }

        private static void IEnumerableDemo()
        {
            IEnumerable<Employee> developers = new Employee[]
                        {
                new Employee { Id = 1, Name = "Scott" },
                new Employee { Id = 2, Name = "Chris" }
                        };
            Console.WriteLine("Number of developers : {0}", developers.Count());

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Alex" }
            };
            Console.WriteLine("Number of sales : {0}", sales.Count());

            //IEnumerator<Employee> enumerator = sales.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}

            foreach (var employee in developers.Where(dev => dev.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
