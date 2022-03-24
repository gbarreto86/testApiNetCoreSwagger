using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class AuthenticateRequestEntity
    {
        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}
