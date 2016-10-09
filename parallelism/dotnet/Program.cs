using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("invalid argument");
                return;
            }

            var taskCount = Convert.ToInt64(args[0]);

            Console.WriteLine("Task to execute: {0}", taskCount);

            var sw = Stopwatch.StartNew();

            var tasks = new Task[taskCount];

            for (int i = 0; i < tasks.Length; i++)
            {
                 tasks[i] = Task.Run(()=>Work(i));
            }

            Task.WaitAll(tasks);

            // Parallel.For(0, taskCount, (i)=> {
            //     var t = string.Format("Task {0} done!", i);
            // });            

            sw.Stop();
            Console.WriteLine("{0} in {1}", taskCount, sw.Elapsed);
        }

        private static void Work(int i){
            var t = string.Format("Task {0} done!", i);
        }
    }
}
