﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{   
    public static class MyLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            //var result = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    //result.Add(item);
                    yield return item;
                }
            }
            //return result;
        }

        public static IEnumerable<double> Random()
        {
            var random = new Random();

            while (true)
            {
                yield return random.NextDouble();
            }
        }
    }
}
