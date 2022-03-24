using System;
using System.Collections.Generic;
using System.Text;
using ExigoWebService;
using Microsoft.Extensions.Configuration;
using System.Infrastructure.Tools.Configuration;
using static ExigoWebService.ExigoApiSoapClient;
using System.Net;

namespace System.Persitence.Service.Exigo
{
    public class ConnectionExigo : IConnectionExigo
    {
        private static string LoginName;
        private static string Password ;
        private static string CompanyKey;
        private static int sandboxID;

        //Clases imagen del appsetting.config
        private readonly AppSettings _appSettings;

        public ConnectionExigo(IConfiguration Configuration)
        {
            //Mapeo conexiones
            LoginName = Configuration["AppSettings:exigoLoginName"];
            Password = Configuration["AppSettings:exigoPassword"];
            CompanyKey = Configuration["AppSettings:exigoCompanyKey"];
            sandboxID = Convert.ToInt32(Configuration["AppSettings:exigosandboxID"].ToString() );
        }

        public static ExigoApiSoapClient ExigoApi()
        {
            
            System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
            result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
            return new ExigoApiSoapClient(EndpointConfiguration.ExigoApiSoap, GetWebServiceUrl(sandboxID));
        }
        public static ApiAuthentication GetApiAuthentication()
        {
            
            return GetApiAuthentication(LoginName, Password, CompanyKey);
        }
        private static string GetWebServiceUrl(int sandboxID)
        {
            var urlFormat = "https://{0}.exigo.com/3.0/ExigoApi.asmx";
            var cname = "fuxion-api";
            if (sandboxID > 0)
            {
                cname = "sandboxapi" + sandboxID;
            }

            return string.Format(urlFormat, cname);
        }

        private static ApiAuthentication GetApiAuthentication(string LoginName, string Password, string CompanyKey)
        {
            ApiAuthentication ApiAuthentication = new ApiAuthentication();
            ApiAuthentication.LoginName = LoginName;
            ApiAuthentication.Password = Password;
            ApiAuthentication.Company = CompanyKey;

            return ApiAuthentication;
        }
    }
}
