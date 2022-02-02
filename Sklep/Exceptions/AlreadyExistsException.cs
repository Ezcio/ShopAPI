using System;

namespace Sklep.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message)   
        {

        }
    }
}
