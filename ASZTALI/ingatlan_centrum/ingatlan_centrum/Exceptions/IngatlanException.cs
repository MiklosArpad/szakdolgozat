using System;

namespace IngatlanCentrum.Exceptions
{
    public class IngatlanException : Exception
    {
        public IngatlanException(string uzenet) : base(uzenet)
        {
        }
    }
}
