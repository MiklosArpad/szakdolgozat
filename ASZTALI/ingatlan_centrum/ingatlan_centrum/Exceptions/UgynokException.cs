using System;

namespace IngatlanCentrum.Exceptions
{
    public class UgynokException : Exception
    {
        public UgynokException(string uzenet) : base(uzenet)
        {
        }
    }
}
