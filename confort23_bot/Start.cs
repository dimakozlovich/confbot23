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
 
        public List<KeyboardButton> Buttons = new List<KeyboardButton>() 
        {
           new KeyboardButton(Messages.ContactsMessage),
           new KeyboardButton(Messages.QuestionMessage),
           new KeyboardButton(Messages.SeminarsMessage),
           new KeyboardButton(Messages.RegistrationSeminar)
        }; 
        public virtual ReplyKeyboardMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup(Buttons);
        }
    }
}
