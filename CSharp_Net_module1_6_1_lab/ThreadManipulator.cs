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
            int CurrentManagedThreadID = Thread.CurrentThread.ManagedThreadId;
            lock (_block)
            {
                for(int i = 0; i < 100 && key != ConsoleKey.Q; ++i)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Current managed thread id : " + CurrentManagedThreadID);
                    raw = i % number;
                    Thread.Sleep(5000);
                }
            }
        }
       


        public void AddingCustomValue(object args) 
        {
            //get ManagedThreadId

            //define
            //var arr = (int[])args;
            //var number = arr[0];
            //var step = arr[1];

            //use for loop for counter % number calculation
            
            
            // for (var counter = 0; counter < 100 * step && _key != ConsoleKey.W; counter += step)
                {

                    //use Console.ForegroundColor = ConsoleColor.Green for output
                    //simulate the long process with Thread.Sleep
                }

        }

        //implement Stop() method
        {
            //get ManagedThreadId

            //craete while loop to read key
            {
                //use Console.ForegroundColor = ConsoleColor.Red for output
            }
        }
    }
}
