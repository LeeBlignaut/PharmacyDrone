using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyDrone.Classes
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message) //CustomExecption for catcing and handling of errors
        {

        }
    }
}
