using System;
using System.Runtime.Serialization;

namespace Yotta.SoloGrit.SmsSender.Exceptions
{
    public class SoloGritSmsSenderException : Exception
    {
        public SoloGritSmsSenderException(string message) : base(message)
        {
        }

        public SoloGritSmsSenderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SoloGritSmsSenderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
