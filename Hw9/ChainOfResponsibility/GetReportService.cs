using System;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.ChainOfResponsibility
{
    public class GetReportService
    {
        private FileHandler _handler;

        public GetReportService()
        {
            _handler = new TxtHandler(null);
            _handler = new CsvHandler(_handler);
            _handler = new XlsxHandler(_handler);
            _handler = new NoneHandler(_handler);
        }

        public IReportService Validate(string[] args)
        {
            return _handler.Validate(args);
        } 
    }
    public abstract class FileHandler
    {
        private readonly FileHandler _nextHandler;
        
        protected FileHandler(FileHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        

        public virtual IReportService Validate(string[] args)
        {
            return _nextHandler.Validate(args);
        }
    }

    public class TxtHandler : FileHandler
    {
        public override IReportService Validate(string[] args)
        {
            var filename = args[0];
            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }
            
            return base.Validate(args);
        }

        public TxtHandler(FileHandler nextHandler) : base(nextHandler) {}
    }
    
    public class CsvHandler : FileHandler
    {
        public override IReportService Validate(string[] args)
        {
            var filename = args[0];
            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }
            return base.Validate(args);
        }

        public CsvHandler(FileHandler nextHandler) : base(nextHandler) {}
    }
    
    public class XlsxHandler : FileHandler
    {
        public override IReportService Validate(string[] args)
        {
            var filename = args[0];
            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }
            return base.Validate(args);
        }
        
        public XlsxHandler(FileHandler nextHandler) : base(nextHandler) {}
    }
    
    public class NoneHandler : FileHandler
    {
        public override IReportService Validate(string[] args)
        {
            var filename = args[0];
            if (!(filename.EndsWith(".txt") || filename.EndsWith(".csv") || filename.EndsWith(".xlsx")))
            {
                throw new NotSupportedException("this extension not supported");
            }
            return base.Validate(args);
        }

        public NoneHandler(FileHandler nextHandler) : base(nextHandler) {}
    }
}