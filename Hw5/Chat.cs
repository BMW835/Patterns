using System.Collections.Generic;

namespace Hw5
{
    public class Chat : IChat
    {
        public List<string> Send(string sender, string recipient, string mail)
        {
            var list = new List(sender, recipient, mail);
        
            return List<string>(sender, recipient, mail);
        }
        
        public List<string> Receive(string sender, string recipient, string mail)
        {
            return _func(input);
        }
    }
}