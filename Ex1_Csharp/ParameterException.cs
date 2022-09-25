using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Csharp
{
    public class ParameterException : Exception
    {
        public ParameterException(string message) : base(message)
        {

        }
    }
}
