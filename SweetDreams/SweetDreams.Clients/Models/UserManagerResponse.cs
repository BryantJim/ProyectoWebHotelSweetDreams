using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SweetDreams.Clients.Models
{
    public class UserManagerResponse
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public string[] Errors { get; set; }

        public Dictionary<string, string> UserInfo { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
