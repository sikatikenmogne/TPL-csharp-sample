using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_csharp_sample
{
    class Program
    {
        private delegate void DELG();

        static void Main(string[] args)
        {
            System.Threading.Thread t1;
            DELG d_it;
            DELG d_tpl;
            CLwork ow;
            IAsyncResult iasync_it;
            IAsyncResult iasync_tpl;

            t1 = new System.Threading.Thread(
                new System.Threading.ThreadStart(CLtime.start));
            ow = new CLwork();
            d_it = new DELG(() =>
            {
                Console.WriteLine(ow.m_work_it().ToString());
            });
            d_tpl = new DELG(() =>
            {
                Console.WriteLine(ow.m_work_tpl().ToString());
            });
            t1.Start();
            iasync_it = d_it.BeginInvoke((async) =>
            {
                DELG dlg = (DELG)
                    ((System.Runtime.Remoting.Messaging.AsyncResult)async).AsyncDelegate;
                dlg.EndInvoke(async);
                Console.WriteLine("fin du traitement itératif");
            }, d_it);
            iasync_tpl = d_tpl.BeginInvoke((async) =>
            {
                DELG dlg = (DELG)
                    ((System.Runtime.Remoting.Messaging.AsyncResult)async).AsyncDelegate;
                dlg.EndInvoke(async);
                Console.WriteLine("fin du traitement tpl");
            }, d_tpl);
            while ((!iasync_it.IsCompleted))
            {
                Console.WriteLine("En cours de traitement..."); System.Threading.Thread.Sleep(1000);
                Console.WriteLine(iasync_it.IsCompleted.ToString());
            }
            t1.Abort();
            Console.Read();
        }
    }
}
