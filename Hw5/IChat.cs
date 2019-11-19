using System;
using System.Collections.Generic;

namespace Hw5
{
    public interface IChat
    {
        List<string> Send(string sender, string recipient, string text);
        List<string> Receive(string sender, string recipient, string text);
    }
}