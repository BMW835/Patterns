using System;
using System.Collections.Generic;
using System.Text;

namespace Hw5
{
    public class ChatDecoratorBase : IChat
    {
        protected readonly IChat Decoratee;

        protected ChatDecoratorBase(IChat chat)
        {
            Decoratee = chat;
        }

        public List<string> Send (string sender, string recipient, string text)
        {
            var mail =  Decoratee.Send(sender, recipient, text);
            return Convert(mail);
        }

        public List<string> Receive (string sender, string recipient, string text)
        {
            var mail =  Decoratee.Send(sender, recipient, text);
            return Convert(mail);
        }

        protected virtual List<string> Convert(List<string> mail)
        {
            return mail;
        }

    }
    
    public class HideDecorator : ChatDecoratorBase
    {
        public HideDecorator(IChat chat) : base(chat)
        { }

        protected override List<string> Convert(List<string> mail)
        {
            var hideSender = BitConverter.ToString(Encoding.ASCII.GetBytes(mail[0]));
            var hideRecipient = BitConverter.ToString(Encoding.ASCII.GetBytes(mail[1]));
            mail = new List<string>{hideSender, hideRecipient, mail[2]};
            return base.Convert(mail);
        }
        
    }
    
    public class EncodeDecorator : ChatDecoratorBase
    {
        public EncodeDecorator(IChat chat) : base(chat)
        { }

        protected override List<string> Convert(List<string> mail)
        {
            var encodeText = "Encoded<" + mail[2] + ">";
            mail = new List<string>{mail[0], mail[1], encodeText};
            return base.Convert(mail);
        }
        
    }
}