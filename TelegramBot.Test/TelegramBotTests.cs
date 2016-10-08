using System.Threading.Tasks;
using Xunit;


namespace TelegramBot.Test
{
    public class Base
    {
        private const string TelegramToken = "x";

        [Fact]
        public async Task Test_Init()
        {
            var bot = new TelegramBot(TelegramToken);
            bool initOk = await bot.Init();
            Assert.Equal(true, initOk);
        }
    }
}
