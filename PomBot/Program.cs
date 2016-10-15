using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomBot
{
    public class Program
    {
        
        private const string TelegramToken = "x";
        public static void Main(string[] args)
        {
            PomBot p = new PomBot(TelegramToken);
            var task = p.Start();
            task.Wait();
        }
    }
}
