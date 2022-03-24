using System;
using System.Collections.Generic;
using System.Text;

namespace System.Infrastructure.Tools.Configuration
{
    public class AppSettings
    {
        public string ConnectionStringSQLReporting { get; set; }
        public string ConnectionStringSQLOffix { get; set; }

        public string ConnectionStringSQLFuxion { get; set; }

        public string ConnectionStringMySqlFuxion { get; set; }
        public string Secret { get; set; }
        public string Key { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string exigoLoginName { get; set; }
        public string exigoPassword { get; set; }
        public string exigoCompanyKey { get; set; }
        public string exigosandboxID { get; set; }

        public string Key_wallet { get; set; }
        public string User_wallet { get; set; }
        public string Pass_wallet { get; set; }

    }
}
