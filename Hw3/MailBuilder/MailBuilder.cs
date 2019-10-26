using System.Collections.Generic;

namespace Hw3.MailBuilder
{
    public interface IMailBuilder
    {
        IMailBuilder SetReceiver(List<string> receiver);
        IMailBuilder SetCopy(List<string> copy);
        IMailBuilder SetTitle(string title);
        IMailBuilder SetBody(string text);
        Mail Result { get; }
    }

    public class MailBuilder : IMailBuilder
    {
        private List<string> _receiver;
        private List<string> _copy;
        private string _title;
        private string _text;
        
        public IMailBuilder SetReceiver(List<string> receiver)
        {
            _receiver = receiver;
            return this;
        }
        
        public IMailBuilder SetCopy(List<string> copy)
        {
            _copy = copy;
            return this;
        }
        
        public IMailBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }
        
        public IMailBuilder SetBody(string text)
        {
            _text = text;
            return this;
        }
        
        public Mail Result => new Mail {Receiver = _receiver, Copy = _copy, Title = _title, Text = _text};
    }

    public class MailBuilderDirector
    {
        private readonly IMailBuilder _mailBuilder;

        public MailBuilderDirector(IMailBuilder mailBuilder)
        {
            _mailBuilder = mailBuilder;
        }

        public void Build(List<string> receiver, List<string> copy, string title, string text)
        {
            _mailBuilder.SetReceiver(receiver);
            _mailBuilder.SetCopy(copy);
            _mailBuilder.SetTitle(title);
            _mailBuilder.SetBody(text);
        }
    }
    
    public class Mail
    {
        public List<string> Receiver { get; set; }
        public List<string> Copy { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}