using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOONS.TDD.Chapter4.Logger
{
    public interface IWebService
    {
        void LogError(string message);
        
    }

    public class LogAnalyzer
    {
        private readonly IWebService _service;

        public LogAnalyzer(IWebService service)
        {
            this._service = service;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                _service.LogError("Filename too short:"
                                  + fileName);
            }
        }
    }

    
}
