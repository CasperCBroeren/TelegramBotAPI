using System.Net;
using System.Threading.Tasks;
using PomBot;

private const string TelegramToken = "280025842:AAEHYw3viM7TD4km44OaM7rjyoXWAU4mp5c";
public static void Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info("Bot started");
    //ServeBot();
}

private static void ServeBot(TraceWriter log)
{
    try
    {
        PomBot p = new PomBot(TelegramToken);
        var task = p.Start();
        task.Wait();

    }
    catch (Exception ex)
    {
        log.Info("Bot restart because " + ex.Message);
        ServeBot(log); // I know this is infinite loopish

    }
}