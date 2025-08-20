using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Lyre;

namespace NativeMessaging
{
    class Message
    {
    
        public Message(string message)
        {
            Value = message;
        }

        public string Value { get; set; }

   }
}