using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AsyncStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.OurAsyncMethod().Wait();
        }
        public static async Task OurAsyncMethod()
        {
            Console.WriteLine("First part");
            var res = await Task.FromResult(true);

            Console.WriteLine("Second part");
            await Task.Delay(2000);
            
            Console.WriteLine("Third part");
            await Task.Yield();

            Console.WriteLine("Third part");
            await 2000;

            Console.WriteLine("Fourth part");
            throw new Exception();
        }
    }

    public static class not_important_name_of_public_static_class
    {
        public static TaskAwaiter GetAwaiter(this int milliseconds)
        {
            return Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).GetAwaiter();
        }
    }
}
