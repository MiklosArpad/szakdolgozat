using System;

namespace IngatlanCentrum.Exceptions
{
    public class IngatlanKategoriaException : Exception
    {
        public IngatlanKategoriaException(string uzenet) : base(uzenet)
        {
        }
    }
}
