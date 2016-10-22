using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomBot
{
    public class Program
    {
        
        private const string TelegramToken = "280025842:AAEHYw3viM7TD4km44OaM7rjyoXWAU4mp5c";
        public static void Main(string[] args)
        {
            PomBot p = new PomBot(TelegramToken);
            var task = p.Start();
            task.Wait();
        }
    }
}
