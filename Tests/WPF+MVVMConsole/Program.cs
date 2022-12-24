using System.Runtime.CompilerServices;

namespace WPF_MVVMConsole
{
    class Program
    {
        private static bool __ThreadUpdate = true;

        static void Main(string[] args)
        {
            ManualResetEvent manual_reset_event = new ManualResetEvent(false);
            AutoResetEvent auto_reset_event = new AutoResetEvent(false);

            EventWaitHandle thread_guidance = auto_reset_event;

            var test_threads = new Thread[10];
            for (var i = 0; i < test_threads.Length; i++)
            {

                var local_i = i;
                test_threads[i] = new Thread(() =>
                {
                    Console.WriteLine("Поток id:{0} - стартовал", Thread.CurrentThread.ManagedThreadId);

                    thread_guidance.WaitOne();

                    Console.WriteLine("Value:{0}", local_i);
                    Console.WriteLine("Поток id:{0} - завершился", Thread.CurrentThread.ManagedThreadId);
                });
                test_threads[i].Start();
            }

            Console.WriteLine("Готов к запуску потоков");
            Console.ReadLine();

            thread_guidance.Set();
            thread_guidance.Reset();



            Console.ReadLine();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void PrintMethod(string Message, int Count, int Timeout)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine(Message);
                Thread.Sleep(Timeout);
            }
        }
        private static void ThreadMethod(object parameter)
        {
            var value = (int)parameter;
            Console.WriteLine(value);
            CheckThread();
            while (__ThreadUpdate)
            {
                Thread.Sleep(100);
                Thread.SpinWait(1000);
                Console.Title = DateTime.Now.ToString();
            }
        }
        private static void CheckThread()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("id:{0} - {1}", thread.ManagedThreadId, thread.Name);
        }
    }
}