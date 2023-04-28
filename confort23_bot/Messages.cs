using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    public delegate Task Mydelegate(long chatId, string imagePath, Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup inline);
    public static class Messages
    {
        //Start
        public const string ContactsMessage = "Контакты";
        public const string QuestionMessage = "Задать Вопрос";
        public const string RegistrationSeminar = "Регистрация на семинар";
        public const string Chat = "Чат участников";
        public const string Timetable = "Рассписание";
        public const string ToGuests = "Гостям";
        //Seminars
        public const string Day1 = "8 Мая";
        public const string Day2 = "9 Мая";

        //Рассписание
        public const string GoBack = "Назад";

        public const string ConnectionString = "Server=217.28.223.127,17160;User Id=user_7fb27;Password=Pt4}3W%zo+7;Database=db_2eba2;TrustServerCertificate=True";
    }

}
