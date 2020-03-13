using Core;
using Implementation;
using System;
using System.IO;

namespace MobileT9
{
    class Program
    {
        static void Main(string[] args)
        {
            Provider provider = new Provider(new T9Parser());
            provider.Add(new StringProvider());
            provider.Add(new ArrayProvider());
            provider.Add(new FileProvider());

            var str = provider.GetResult("hi");
            Console.WriteLine($"Case #1: {str}");

            string[] arr = { "hi", "yes", "foo  bar", "hello world" };
            int idx = 1;
            foreach (var item in (string[])provider.GetResult(arr))
            {
                Console.WriteLine($"Case #{idx}: {item}");
            }
            var curDir = Directory.GetCurrentDirectory();
            Console.WriteLine(curDir);
            FileInfo file = new FileInfo(curDir+ "\\samples\\C-small-practice.in");
            var resfile = provider.GetResult(file);
            Console.WriteLine(resfile);
            Console.ReadLine();
        }
    }
}
