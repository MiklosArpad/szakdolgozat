using System;

namespace IngatlanCentrum.Exceptions
{
    public class UgynokJogosultsagException : Exception
    {
        public UgynokJogosultsagException(string uzenet) : base(uzenet)
        {
        }
    }
}
