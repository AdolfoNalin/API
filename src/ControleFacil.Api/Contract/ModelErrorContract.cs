using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract
{
    public class ModelErrorContract
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public ModelErrorContract()
        {
            
        }
    }
}