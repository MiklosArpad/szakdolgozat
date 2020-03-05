using System;

namespace IngatlanCentrum.Exceptions
{
    public class IngatlanAllapotException : Exception
    {
        public IngatlanAllapotException(string uzenet) : base(uzenet)
        {
        }
    }
}
