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
            //FuncAndAction();

            //IEnumerableDemo();
            UnderstandingLambdaExpressions();

        }

        private static void FuncAndAction()
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(square(add(3, 5)));

            Action<int> write = x => Console.WriteLine(x);
            write(square(add(7, 3)));
        }

        private static void UnderstandingLambdaExpressions()
        {
            var cities = new List<string>(){"Boston","Los Angeles","London","Seattle","Hyderabad"};

            //IEnumerable<string> filteredCities = cities.Where(city => city.StartsWith("L"));
            IEnumerable<string> filteredCities = from city in cities
                                                 where city.StartsWith("L") && city.Length < 8
                                                 orderby city
                                                 select city;

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

            //foreach (var employee in developers.Where(dev => dev.Name.StartsWith("S")))
            //{
            //    Console.WriteLine(employee.Name);
            //}

            foreach (var employee in developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
