using System;

namespace Hw7.State
{
    public class Tracer
    {
        public int Money { get; set;}
        public string Device { get; }
        public string[] Docs { get; }
        public int DocNumber { get; set; }
        public ITracer State { get; set; }

        public Tracer(int money, string device, string[] docs)
        {
            Money = money;
            Device = device;
            Docs = docs;
            DocNumber = 0;
            State = new GetMoneyState();
        }

        public void GetMoney()
        {
            State.GetMoney(this);
        }
        
        public void ChooseDevice()
        {
            State.ChooseDevice(this);
        }
        
        public void ChooseDoc()
        {
            State.ChooseDoc(this);
        }
        
        public void PrintDoc()
        {
            State.PrintDoc(this);
        }
        
        public void GiveChange()
        {
            State.GiveChange(this);
        }
        
    }
    public interface ITracer
    {
        void GetMoney(Tracer context);
        void ChooseDevice(Tracer context);
        void ChooseDoc(Tracer context);
        void PrintDoc(Tracer context);
        void GiveChange(Tracer context);
    }
    
    public abstract class TracerBase : ITracer
    {
        public abstract void GetMoney(Tracer context);
        public abstract void ChooseDevice(Tracer context);
        public abstract void ChooseDoc(Tracer context);
        public abstract void PrintDoc(Tracer context);
        public abstract void GiveChange(Tracer context);
    }
    
    
    public class GetMoneyState : TracerBase
    {
        public override void GetMoney(Tracer context)
        {
            Console.WriteLine("Put your money");
            Console.WriteLine($"{context.Money} rubles accepted");
            context.State = new ChooseDeviceState();
        }
        public override void ChooseDevice(Tracer context) {}
        public override void ChooseDoc(Tracer context) {}
        public override void PrintDoc(Tracer context) {}
        public override void GiveChange(Tracer context) {}
    }
    
    public class ChooseDeviceState : TracerBase
    {
        public override void GetMoney(Tracer context)  {}
        public override void ChooseDevice(Tracer context)
        {
            if (context.Device == "USB")
            {
                Console.WriteLine("USB connection established");
                context.State = new ChooseDocState();
            }
            else if (context.Device == "Wi-Fi")
            {
                Console.WriteLine("Wi-Fi connection established");
                context.State = new ChooseDocState();
            }
            else context.State = new GiveChangeState();
            
        }
        public override void ChooseDoc(Tracer context) {}
        public override void PrintDoc(Tracer context) {}
        public override void GiveChange(Tracer context) {}
    }
    
    public class ChooseDocState : TracerBase
    {
        public override void GetMoney(Tracer context)  {}
        public override void ChooseDevice(Tracer context) {}
        public override void ChooseDoc(Tracer context)
        {
            Console.WriteLine($"Document {context.Docs[context.DocNumber]} is chosen");
            context.State = new PrintDocState();
        }
        public override void PrintDoc(Tracer context) {}
        public override void GiveChange(Tracer context) {}
    }
    
    public class PrintDocState : TracerBase
    {
        public override void GetMoney(Tracer context)  {}
        public override void ChooseDevice(Tracer context) {}
        public override void ChooseDoc(Tracer context) {}
        public override void PrintDoc(Tracer context)
        {
            Console.WriteLine($"Printing {context.Docs[context.DocNumber]} ...");
            context.Money = context.Money - 5;
            if (context.Docs.Length - 1 > context.DocNumber)
            {
                context.DocNumber++;
                context.State = new ChooseDocState();
            }
            else context.State = new GiveChangeState();
        }
        public override void GiveChange(Tracer context) {}
    }
    
    public class GiveChangeState : TracerBase
    {
        public override void GetMoney(Tracer context)  {}
        public override void ChooseDevice(Tracer context) {}
        public override void ChooseDoc(Tracer context) {}
        public override void PrintDoc(Tracer context) {}
        public override void GiveChange(Tracer context)
        {
            Console.WriteLine($"Take {context.Money} rubles change");
        }
    }
}