using System;

namespace Hw7.State
{
    public class Tracer
    {
        public int Money { get; }
        public string Device { get; }
        public string[] Docs { get; }
        public ITracer State { get; set; }

        public Tracer(int money, string device, string[] docs)
        {
            Money = money;
            Device = device;
            Docs = docs;
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
                Console.WriteLine("USB connection established");
            if (context.Device == "Wi-Fi")
                Console.WriteLine("Wi-Fi connection established");
        }
        public override void ChooseDoc(Tracer context) {}
        public override void PrintDoc(Tracer context) {}
        public override void GiveChange(Tracer context) {}
    }
}