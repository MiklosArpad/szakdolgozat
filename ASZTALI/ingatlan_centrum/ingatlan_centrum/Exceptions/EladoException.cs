using System;

namespace IngatlanCentrum.Exceptions
{
    public class EladoException : Exception
    {
        public EladoException(string uzenet) : base(uzenet)
        {
        }
    }
}
