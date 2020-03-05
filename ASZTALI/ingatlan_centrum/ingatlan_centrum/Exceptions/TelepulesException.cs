using System;

namespace IngatlanCentrum.Exceptions
{
    public class TelepulesException : Exception
    {
        public TelepulesException(string uzenet) : base(uzenet)
        {
        }
    }
}
