namespace Hw5
{
    public class DecoratorBuilder
    {
        private IChat _chat;

        public DecoratorBuilder(IChat chat)
        {
            _chat = chat;
        }

        public DecoratorBuilder WithHide()
        {
            _chat = new HideDecorator(_chat);
            return this;
        }

        public DecoratorBuilder WithEncode()
        {
            _chat = new EncodeDecorator(_chat);
            return this;
        }

        public IChat Build()
        {
            return _chat;
        }
    }
}