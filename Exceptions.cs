using System;

namespace Exceptions
{
    class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message){ }
    }

    class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message){ }
    }
}