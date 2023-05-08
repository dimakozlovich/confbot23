using confort23_bot;
using Microsoft.VisualBasic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot.Types;

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
        cts.Cancel();



async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Mydelegate delegateSend = new Mydelegate(SendPhoto);
    if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message && update.Message.Text != null)
    {
       // var user = new confort23_bot.User(Convert.ToInt32(update.Message.Chat.Id));
        Console.WriteLine(update.Message.Text);
        switch (update.Message.Text)
        {

            case "/start":
                var start = new Start();
                var greetings = new Greetings();
                await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: greetings.Greetingstext,
                    parseMode: ParseMode.Html,
                    replyMarkup: start.GetButtons(),
                    cancellationToken: cancellationToken);
                break;

            case Messages.ContactsMessage:
                var contacts = new Contacts();
                await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: contacts.ContactsText,
                    parseMode: ParseMode.Html,
                    replyMarkup: contacts.GetButtons());

                break;
            case Messages.Chat:
                await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "https://t.me/+i8ljq57xYzMzZWU6"
                    );
                break;
            case Messages.Timetable:
                var schedule = new Schedule();
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: schedule.ScheduleText,
                parseMode: ParseMode.Html
                );
                break;
            //case Messages.GoBack:
            //    start = new Start();
            //    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "назад", replyMarkup: start.GetButtons());
            //    break;

            //case Messages.Day1:
            //    var seminarsday1 = new RegistrationSeminars(Messages.Day1);
            //    await seminarsday1.SendSeminarPiqture(delegateSend, update.Message.Chat.Id);

            //    break;

            //case Messages.Day2:
            //    var seminarsday2 = new RegistrationSeminars(Messages.Day2);
            //    await seminarsday2.SendSeminarPiqture(delegateSend, update.Message.Chat.Id);
            //    break;

            //case Messages.RegistrationSeminar:
            //    var registrationSeminars = new RegistrationSeminars();
            //    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "семинары", replyMarkup: registrationSeminars.GetButtons());
            //    break;
            case Messages.QuestionMessage:
                await botClient.SendTextMessageAsync(
                   chatId: update.Message.Chat.Id,
                   parseMode: ParseMode.Html,
                   text: @"Чтобы узнать ответ на Free Talk, отправь вопрос в формате <strong>
                         Вопрос:</strong><i>текст вопроса</i>");
                break;
            case Messages.ToGuests:
                var guest = new ToGuests();
                await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: guest.toGuestsText,
                    parseMode: ParseMode.Html);
                break;
            default:
                await botClient.SendTextMessageAsync(-976366983, update.Message.Text);
                break;
        }
    }
    if(update.Message.Text == null)
    {
        await botClient.SendTextMessageAsync(-976366983, "null message");
    }
}
async Task SendPhoto(long chatId,string imagePath, Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup inline)
{
    using (var stream = System.IO.File.OpenRead(imagePath))
    {
        var start = new Start();
        await botClient.SendPhotoAsync(chatId, new InputOnlineFile(stream),replyMarkup:inline);
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

