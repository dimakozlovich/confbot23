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
        public const string ContactsMessage = "Контакты";
        public const string QuestionMessage = "Задать Вопрос";
        public const string SeminarsMessage = "Семинары";
        public const string Day1 = "8 Мая";
        public const string Day2 = "9 Мая";
        public const string GoBack = "Назад";
        public const string RegistrationSeminar = "Регистрация на семинар";
    }

}
