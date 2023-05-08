using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace confort23_bot
{
    public class Start
    {
 
        private List<KeyboardButton> Buttons1 = new List<KeyboardButton>() 
        {
           //new KeyboardButton(Messages.RegistrationSeminar),
           new KeyboardButton(Messages.ToGuests)
        };
        private List<KeyboardButton> Buttons2 = new List<KeyboardButton>()
        {
           new KeyboardButton(Messages.ContactsMessage),
          // new KeyboardButton(Messages.QuestionMessage)
        };
        private List<KeyboardButton> Buttons3 = new List<KeyboardButton>()
        {
           new KeyboardButton(Messages.QuestionMessage),
           new KeyboardButton(Messages.Chat),

        };
        public virtual IReplyMarkup GetButtons()
        {
        List<List<KeyboardButton>> Allbuttons = new List<List<KeyboardButton>>()
        {
            Buttons3,
            Buttons2,
            Buttons1
        };
            return new ReplyKeyboardMarkup(Allbuttons);
        }
    }
}
