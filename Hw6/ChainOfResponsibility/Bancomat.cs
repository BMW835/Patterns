using System;
using System.Collections;

namespace Example_06.ChainOfResponsibility
{
    public enum CurrencyType
    {
        Euro,
        Dollar,
        Ruble
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    }

    public class Bancomat
    {
        private readonly BanknoteHandler _handler;

        public Bancomat(string banknote)
        {
            _handler = new FiveEuroHandler(null);
            _handler = new TenEuroHandler(_handler);
            _handler = new FiveThousandEuroHandler(_handler);
            _handler = new TenRubleHandler(_handler);
            _handler = new HundredRubleHandler(_handler);
            _handler = new ThousandRubleHandler(_handler);
            _handler = new TenDollarHandler(_handler);
            _handler = new FiftyDollarHandler(_handler);
            _handler = new HundredDollarHandler(_handler);
            _handler.Validate(banknote);
        }

        public bool Validate(string banknote)
        {
            return _handler.Validate(banknote);
        } 
    }

    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;
        
        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual bool Validate1(string banknote)
        {
            _nextHandler.Validate(banknote);
            return Int32.Parse(banknote.Split(' ')[0]) >= 10;
        }

        public virtual bool Validate(string banknote)
        {
            return _nextHandler != null && _nextHandler.Validate(banknote);
        }
    }

    public abstract class DollarHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.EndsWith("Dollar"))
            {
                while (Int32.Parse(banknote.Split(' ')[0]) >= Value)
                {
                    Console.WriteLine($"{Value} Dollar");
                    banknote = Int32.Parse(banknote.Split(' ')[0]) - Value + " Dollar";
                }
                if (Value == 10 && Int32.Parse(banknote.Split(' ')[0]) < Value)
                    Console.WriteLine("No " + banknote + " banknote");
            }
            
            if (banknote.Equals($"{Value}$"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        protected abstract int Value { get; }

        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }

    public class HundredDollarHandler : DollarHandlerBase
    {
        protected override int Value => 100;

        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class FiftyDollarHandler : DollarHandlerBase
    {
        protected override int Value => 50;

        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class TenDollarHandler : DollarHandlerBase
    {
        protected override int Value => 10;

        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
    
    public abstract class RubleHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.EndsWith("Ruble"))
            {
                while (Int32.Parse(banknote.Split(' ')[0]) >= Value)
                {
                    Console.WriteLine($"{Value} Ruble");
                    banknote = Int32.Parse(banknote.Split(' ')[0]) - Value + " Ruble";
                }
                if (Value == 10 && Int32.Parse(banknote.Split(' ')[0]) < Value)
                    Console.WriteLine("No " + banknote + " banknote");
            }
            
            if (banknote.Equals($"{Value}$"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        protected abstract int Value { get; }

        protected RubleHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }

    public class ThousandRubleHandler : RubleHandlerBase
    {
        protected override int Value => 1000;

        public ThousandRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class HundredRubleHandler : RubleHandlerBase
    {
        protected override int Value => 100;

        public HundredRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class TenRubleHandler : RubleHandlerBase
    {
        protected override int Value => 10;

        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
    
    public abstract class EuroHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.EndsWith("Euro"))
            {
                while (Int32.Parse(banknote.Split(' ')[0]) >= Value)
                {
                    Console.WriteLine($"{Value} Euro");
                    banknote = Int32.Parse(banknote.Split(' ')[0]) - Value + " Euro";
                }
                if (Value == 5 && Int32.Parse(banknote.Split(' ')[0]) < Value)
                    Console.WriteLine("No " + banknote + " banknote");
            }
            
            if (banknote.Equals($"{Value}$"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        protected abstract int Value { get; }

        protected EuroHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }

    public class FiveThousandEuroHandler : EuroHandlerBase
    {
        protected override int Value => 500;

        public FiveThousandEuroHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class TenEuroHandler : EuroHandlerBase
    {
        protected override int Value => 10;

        public TenEuroHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class FiveEuroHandler : EuroHandlerBase
    {
        protected override int Value => 5;

        public FiveEuroHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}