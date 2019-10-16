namespace Hw2.MyFactory
{
        #region Interfaces
    
        public interface ICarFactory
        {
            IBody CreateBody();
            IEngine CreateEngine();
            ICabin CreateCabin();
            ITransmission CreateTransmission();
            IWheels CreateWheels();
            ICar Assemble();
        }
    
        public interface IBody
        {
            string Name { get; }
        }
    
        public interface IEngine
        {
            string Name { get; }
        }
        
        public interface ICabin
        {
            string Name { get; }
        }
        
        public interface ITransmission
        {
            string Name { get; }
        }
        
        public interface IWheels
        { 
            string Name { get; }
        }
        
        public interface ICar
        { 
            string Name { get; }
        }
    
        #endregion
        
        #region Bmw Car

        public class BmwCar : ICarFactory
        {
            public IBody CreateBody()
            {
                return new BmwBody();
            }

            public IEngine CreateEngine()
            {
                return new BmwEngine();
            }
            
            public ICabin CreateCabin()
            {
                return new BmwCabin();
            }

            public ITransmission CreateTransmission()
            {
                return new BmwTransmission();
            }
            
            public IWheels CreateWheels()
            {
                return new BmwWheels();
            }

            public ICar Assemble()
            {
                return new Bmw();
            }
        }

        public class BmwBody : IBody
        {
            public string Name => "Make BMW Body";
        }

        public class BmwEngine : IEngine
        {
            public string Name => "Make BMW Engine";
        }
        
        public class BmwCabin : ICabin
        {
            public string Name => "Make BMW Cabin";
        }

        public class BmwTransmission : ITransmission
        {
            public string Name => "Make BMW Transmission";
        }
        
        public class BmwWheels : IWheels
        {
            public string Name => "Make BMW Wheels";
        }

        public class Bmw : ICar
        {
            public string Name => "Assemble BMW Car";
        }

        #endregion
        
        #region Audi Car

        public class AudiCar : ICarFactory
        {
            public IBody CreateBody()
            {
                return new AudiBody();
            }

            public IEngine CreateEngine()
            {
                return new AudiEngine();
            }
            
            public ICabin CreateCabin()
            {
                return new AudiCabin();
            }

            public ITransmission CreateTransmission()
            {
                return new AudiTransmission();
            }
            
            public IWheels CreateWheels()
            {
                return new AudiWheels();
            }

            public ICar Assemble()
            {
                return new Audi();
            }
        }

        public class AudiBody : IBody
        {
            public string Name => "Make AUDI Body";
        }

        public class AudiEngine : IEngine
        {
            public string Name => "Make AUDI Engine";
        }
        
        public class AudiCabin : ICabin
        {
            public string Name => "Make AUDI Cabin";
        }

        public class AudiTransmission : ITransmission
        {
            public string Name => "Make AUDI Transmission";
        }
        
        public class AudiWheels : IWheels
        {
            public string Name => "Make AUDI Wheels";
        }

        public class Audi : ICar
        {
            public string Name => "Assemble AUDI Car";
        }

        #endregion
}