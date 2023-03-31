﻿global using Telegram.Bot;
using confort23_bot;
using Microsoft.VisualBasic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

var botClient = new TelegramBotClient("6009835688:AAF43gPAMG_ZJKASWs6BKR4BTPbOcLswQEo");
using CancellationTokenSource cts = new();
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{

    Console.WriteLine(update.Message.Text);
    Mydelegate delegateSend = new Mydelegate(SendPhoto);
    switch (update.Message.Text)
        {
            
            case "/start":
            var start = new Start();
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, update.Message.Text, replyMarkup: start.GetButtons());
                break;
            case Messages.ContactsMessage:
                var contacts = new Contacts();
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, contacts.ContactsText, replyMarkup: contacts.GetButtons());
                break;
            case Messages.QuestionMessage:
                break;
            
            case Messages.SeminarsMessage:
               var seminars = new Seminars();
               await botClient.SendTextMessageAsync(update.Message.Chat.Id,"семинары",replyMarkup: seminars.GetButtons());
                break;
            case Messages.GoBack:
            start = new Start();
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "назад", replyMarkup: start.GetButtons());
            break;

            

            case Messages.Day1:
            var seminarsday1 = new Seminars(Messages.Day1);
            await seminarsday1.SendSeminarPiqture(delegateSend, update.Message.Chat.Id);
 
            break;
            case Messages.Day2:
              var seminarsday2 = new Seminars(Messages.Day2);
              await seminarsday2.SendSeminarPiqture(delegateSend, update.Message.Chat.Id);
            break;


        }
        
}
async Task SendPhoto(long chatId,string imagePath)
{
    using (var stream = System.IO.File.OpenRead(imagePath))
    {
        await botClient.SendPhotoAsync(chatId, new InputOnlineFile(stream));
    }
}
Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}