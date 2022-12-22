namespace WPF_MVVMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main theread";

            var values = new List<int>();

            var threads = new Thread[10];
            object lock_object = new object();
            for (var i = 0; i < threads.Length; i++)
                threads[i] = new Thread(() =>
                {
                    for (var j = 0; j < 10; j++)
                    {
                        lock (lock_object)
                            values.Add(Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1);
                    }
                });

            Monitor.Enter(lock_object);
            try
            {

            }
            finally
            {
                Monitor.Exit(lock_object);
            }

            foreach (var thread in threads)
                thread.Start();


            Console.ReadLine();
            Console.WriteLine(string.Join(",", values));

            Console.ReadLine();


        }

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
            while (true)
            {
                Thread.Sleep(100);
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