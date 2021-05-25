using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PhotoAlbum.BLL.Validation
{
    public class PhotoAlbumException : Exception
    {
        public string Property { get; protected set; }

        public PhotoAlbumException() : base() { }
        public PhotoAlbumException(string message) : base(message) { }
        public PhotoAlbumException(string message, Exception inner) : base(message, inner) { }
        public PhotoAlbumException(string message, string prop) : base(message)
        {
            Property = prop;
        }

        protected PhotoAlbumException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
