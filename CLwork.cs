using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_csharp_sample
{
    class CLwork
    {
        public int m_work_it()
        {
            int val = 0;
            for (int i = 0; i < 1000; i++)
            {
                val = val + 1;
                System.Threading.Thread.Sleep(10);
            }
            Console.WriteLine("Fin du traitement it�ratif en {0} secondes", CLtime.get_time().ToString());
            return val;
        }
        public int m_work_tpl()
        {
            int val = 0;
            Parallel.For(0, 1000, (int i) =>
            {
                val = i;
                System.Threading.Thread.Sleep(10);
            });
            Console.WriteLine("Fin du traitement tpl en {0} secondes", CLtime.get_time().ToString());
            return val;
        }
    }
}
