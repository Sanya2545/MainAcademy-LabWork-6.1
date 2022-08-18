using System;
using System.Threading;

namespace CSharp_Net_module1_6_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //use Console.ForegroundColor = ConsoleColor.Gray for output
            Console.ForegroundColor = ConsoleColor.Gray;

            //create ThreadManipulator object
            ThreadManipulator manipulator = new ThreadManipulator();

            //create first thread for AddingOne method
            Thread thread = new Thread(manipulator.AddingOne);
            

            //create second thread for AddingOne method
            Thread thread2 = new Thread(manipulator.AddingOne);
            

            //create thread for AddingCustomValue method
            Thread thread3 = new Thread(manipulator.AddingCustomValue);
            int[] arr = new int[2];
           
            //create Background thread for Stop method
            //start Background thread for Stop method

            //start first thread for AddingOne method with argument = 10
            thread.Start(10);
            //start second thread for AddingOne method with argument = 20
            thread2.Start(20);

            //start thread for AddingCustomValue method with argument new[] { 5, 15 }
            arr[0] = 5;
            arr[1] = 15;
            thread3.Start(arr);
            Thread backgroundThread = new Thread(manipulator.Stop);
            backgroundThread.Start();
            //join threads
            thread.Join();
            thread2.Join();
            thread3.Join();
            Console.ReadKey();
            
        }
    }
}
