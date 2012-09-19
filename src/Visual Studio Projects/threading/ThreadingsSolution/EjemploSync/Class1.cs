using System;
using System.Threading;

namespace EjemploSync
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
        private AutoResetEvent evento;		

        private class PepeThread
        {
            private AutoResetEvent e;

            public PepeThread(AutoResetEvent ev)
            {
                e = ev;
            }
    
            public void PepeFunc()
            {
                Console.WriteLine("Empezo. espere 5");
                Thread.Sleep(5000);
                Console.WriteLine("Antes de activar");
                e.Set();
                Console.WriteLine("Despues de activar");
                Thread.Sleep(5000);
                Console.WriteLine("Pepe is dead");
            }
        }

        public void Execute()
        {
            Console.WriteLine("Empezamos...");

            evento = new AutoResetEvent(false);

            PepeThread pepe = new PepeThread(evento);
            Thread th = new Thread(new ThreadStart(pepe.PepeFunc));
            th.Start();
            Console.WriteLine("Esperando evento...");
            evento.WaitOne();            
            Console.WriteLine("Llego el evento... Nos vamos");
        }

        /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: Add code to start application here
			//
            Class1 c = new Class1();
            c.Execute();
		}
	}

    
}
