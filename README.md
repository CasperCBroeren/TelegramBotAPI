![alt text](https://github.com/CasperCBroeren/TelegramBotAPI/raw/master/t_logo.png "Logo Telegram")
# Telegram Bot API
An **unofficial** dotNet implementation of the Telegram Bot API; https://core.telegram.org/bots/api
Current state is a **pre-release** which doesn't implement all API calls and is subject to change. The total repo features 3 project;

## TelegramBot
The core code for TelegramBot which allows you to use the Telegram API

## TelegramBot.Test
The xunit test project validating the TelegramBot code

## PomBot
The demo project featuring my cat (he's awsome)

### How to set things up?
First follow the Telegram BotFather creation guid; https://core.telegram.org/bots#6-botfather
Second put your token into the application
```C#
       var bot = new TelegramBot("110201543:AAHdqTcvCH1vGWJxfSeofSAs0K5PALDsaw");
```
Use the bot instance to do listin to longpolling or send a message just like the API

### Why are most methods async?
Well I believe that [TAP](https://msdn.microsoft.com/en-us/library/hh873175(v=vs.110).aspx) is realy the way to go when doing HTTP calls. It can be faster and if you can't do async, just use the task.wait();
