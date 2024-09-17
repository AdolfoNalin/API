using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Execeptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) : base(message)
        {
            
        }
    }
}