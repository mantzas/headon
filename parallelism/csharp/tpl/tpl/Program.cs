using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace tpl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("invalid argument");
                return;
            }

            var taskCount = Convert.ToInt64(args[0]);

            Console.WriteLine("Task to execute: {0}", taskCount);

            var sw = Stopwatch.StartNew();

            Parallel.For(0, taskCount, (i)=> {
                var t = string.Format("Task {0} done!", i);
            });

            sw.Stop();
            Console.WriteLine("{0} in {1}", taskCount, sw.Elapsed);
        }
    }
}
