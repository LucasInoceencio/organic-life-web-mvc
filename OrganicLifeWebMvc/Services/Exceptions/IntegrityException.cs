using System;

namespace OrganicLifeWebMvc.Services
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }
}
