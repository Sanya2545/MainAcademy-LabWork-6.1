using System;
using System.Threading;

namespace CSharp_Net_module1_6_1_lab
{
    class ThreadManipulator
    {
        //declare private ConsoleKey  _key  field
        private ConsoleKey key;
        //In general, avoid locking on a public type, or instances beyond your code's control. The common constructs lock (this), lock (typeof (MyType)), and lock ("myLock") violate this guideline:
        //lock (this) is a problem if the instance can be accessed publicly.
        //lock (typeof (MyType)) is a problem if MyType is publicly accessible.
        //lock("myLock") is a problem because any other code in the process using the same string, will share the same lock.
        //Best practice is to define a private object to lock on, or a private static object variable to protect data common to all instances.

        //create static readonly object _block by new operator
        private static readonly object _block = new object();


        //private object _block = new object();    //lock

        public void AddingOne(object raw)
        {
            var number = (int)raw;
            int managedThreadID = Thread.CurrentThread.ManagedThreadId;
            lock (_block)
            {
                for(int i = 0; i < 2 && key != ConsoleKey.Q; ++i)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    raw = i % number;
                    Console.WriteLine("Current managed thread id : {0}\nResult of worked loop : {1}", managedThreadID, raw);
                    Thread.Sleep(5000);
                }
            }
        }
       


        public void AddingCustomValue(object args) 
        {
            int managedThreadID = Thread.CurrentThread.ManagedThreadId;
            //get ManagedThreadId

            //define
            var arr = (int[])args;
            //var arr = (int[])args;
            //var number = arr[0];
            var number = arr[0];
            //var step = arr[1];
            var step = arr[1];

            //use for loop for counter % number calculation
            
            
            for (var i = 0; i < 2 && key != ConsoleKey.W; i += step)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var result = i % number;
                Console.WriteLine("Current managed thread id : {0}\nResult of worked loop : {1}", managedThreadID, result);
                Thread.Sleep(5000);
                    //use Console.ForegroundColor = ConsoleColor.Green for output
                    //simulate the long process with Thread.Sleep
            }

        }

        public void Stop()
        {
            int managedThreadId = Thread.CurrentThread.ManagedThreadId;
            //get ManagedThreadId
            while(Console.ReadKey(true).Key != ConsoleKey.Q)
            //craete while loop to read key
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Managed thread ID : {0}", managedThreadId);
                //use Console.ForegroundColor = ConsoleColor.Red for output
            }
        }
    }
}
