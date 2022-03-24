using System;
using System.Collections.Generic;
using System.Text;

namespace System.Application.Main.Dtos.Token
{
    public class TokenDto
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public DateTime Expired { get; set; }
    }
}
