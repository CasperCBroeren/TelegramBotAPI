using System.Net;
using System.Threading.Tasks;


private const string TelegramToken = "280025842:AAEHYw3viM7TD4km44OaM7rjyoXWAU4mp5c";
public static async Task<HttpResponseMessage> Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info("Bot started");
    await ServeBot();
}

private static async Task ServeBot(TraceWriter log)
{
    try
    {
        PomBot p = new PomBot(TelegramToken);
        await p.Start();
        
    }
    catch (Exception ex)
    {
        log.Info("Bot restart because " + ex.Message);
        await ServeBot(); // I know this is infinite loopish

    }
}