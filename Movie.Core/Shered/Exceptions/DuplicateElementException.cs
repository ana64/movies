using System;

namespace Movie.Core.Shered.Exceptions
{
    public class DuplicateElementException : Exception
    {
        public DuplicateElementException(string elementName) : base($"Same element {elementName} all ready exists.")
        {

        }

        protected DuplicateElementException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }

        public DuplicateElementException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
