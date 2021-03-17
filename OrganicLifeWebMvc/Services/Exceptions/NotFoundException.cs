using System;

namespace OrganicLifeWebMvc.Services
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
