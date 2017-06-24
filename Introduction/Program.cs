using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Windows";
            ShowLargestFileWithoutLinq(path);
            Console.WriteLine("****************************");
            ShowLargestFileWithLinq(path);
        }

        private static void ShowLargestFileWithLinq(string path)
        {
            //var query = from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file;

            var query = new DirectoryInfo(path).GetFiles()
                            .OrderByDescending(file => file.Length)
                            .Take(5);

            //foreach (var file in query.Take(5))
            foreach (var file in query)
            {
                Console.WriteLine("{0, -20} : {1, 10:N0}", file.Name, file.Length);
            }

        }

        private static void ShowLargestFileWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            //foreach (var file in files)
            //{
            //    Console.WriteLine("{0} : {1}", file.Name, file.Length);
            //}
            Console.WriteLine("The 5 largest file in the path \"{0}\" are : ", path);
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine("{0, -20} : {1, 10:N0}", file.Name, file.Length);
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
