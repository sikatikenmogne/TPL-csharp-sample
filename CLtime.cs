using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_csharp_sample
{
    class CLtime
    {
        private static int time;
        static CLtime()
        {
            time = 0;
        }
        public static void start()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                System.Threading.Interlocked.Increment(ref time);
                Console.WriteLine(time.ToString());
            }
        }
        public static int get_time()
        {
            return time;
        }
    }
}
