using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.Models
{
    public class AccountContext
    {
        // this would be set after the request is received by the API but before it reaches the controller
        // corresponds to platforms in StoreTable
        public int PlatformId;
        // ideally, these would be retrieved securely
        public string ConsumerKey;
        public string ConsumerSecret;
    }
}
