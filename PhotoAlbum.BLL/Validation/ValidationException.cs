using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PhotoAlbum.BLL.Validation
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException() : base() { }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
