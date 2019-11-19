using System.Collections.Generic;

namespace Hw5
{
    public class Chat : IChat
    {
        public List<string> Send(string sender, string recipient, string text)
        {
            return new List<string> {sender, recipient, text};
        }
        
        public List<string> Receive(string sender, string recipient, string text)
        {
            return new List<string> {sender, recipient, text};
        }
    }
}