﻿namespace Order.Application.Common.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message)
        {
            
        }
    }
}
