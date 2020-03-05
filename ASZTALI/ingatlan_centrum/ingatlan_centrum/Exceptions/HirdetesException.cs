using System;

namespace IngatlanCentrum.Exceptions
{
    public class HirdetesException : Exception
    {
        public HirdetesException(string uzenet) : base(uzenet)
        {
        }
    }
}
