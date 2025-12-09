using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AsynchronousProgramming
{
    public class ThreadLogger
    {
        public static void WriteLine(string msg,
            bool isShowCallerName = false, [CallerMemberName] string caller = "")
        {
            string info = $"{DateTime.Now:HH:mm:ss} - 线程{Thread.CurrentThread.ManagedThreadId}";
            info += isShowCallerName ? $" - {caller,-20}: " : ": ";
            info += msg;
            Console.WriteLine(info);
        }
    }
}