using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Application.Main.Dtos.Token;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Infrastructure.Tools.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiFuxion.Custom
{
    public class Token : IToken
    {
        private readonly AppSettings _appSettings;
        public Token(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        
        public async Task<TokenDto> CreateToken(TokenDto objToken)
        {
            var secret = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var Decrypt = this.Decrypt(objToken.Key);
            var Encrypt = this.Encrypt("secret_ecuorder");
            var Decrypt_v2 = this.Decrypt(Encrypt);

            if ((objToken.User == _appSettings.User_wallet && objToken.Password == _appSettings.Pass_wallet && Decrypt == _appSettings.Key_wallet))
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var expired = DateTime.UtcNow.AddYears(10);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, objToken.User),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Version, "V1")
                    }),
                    Expires = expired,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                //Suscribe token
                objToken.Password = string.Empty;
                objToken.Key = tokenHandler.WriteToken(token);
                objToken.Expired = expired;

                return objToken;
            }

            return null;
        }

        public string Encrypt(string value)
        {
            string result = "";

            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    //byte[] bytes = System.Text.UnicodeEncoding.UTF8.GetBytes(value);
                    byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(value);
                    result = Convert.ToBase64String(bytes);
                }
            }
            catch { }

            return result;
        }

        private string Decrypt(string crypt)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(crypt);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                //result = System.Text.Encoding.UTF8.GetString(decryted);
                return result;
            }
            catch (Exception)
            {

            }
            return "";
        }
        public async Task<TokenOffixDto> CreateTokenOffix(object value, string sistema)
        {
            TokenOffixDto objToken = new TokenOffixDto();
            string resultToken = Encrypt(value, "SDFN0SD97FM09348590238M4");
            if (sistema == "BO")
            {
                objToken.Ruta = "https://offix.fuxion.com/silentlogin?token=" + resultToken;
            }
            else if (sistema == "RS")
            {
                objToken.Ruta = "https://ifuxion.com/silentloginService?token=" + resultToken;
            }
            else
            {
                objToken.Ruta = "";
            }
            

            return objToken;
        }
        public async Task<TokenOffixDto> CreateTokenOffixV2(object value, string sistema)
        {
            TokenOffixDto objToken = new TokenOffixDto();
            string resultToken = Encrypt(value, "SDFN0SD97FM09348590238M4");

            objToken.Ruta = sistema + "/silentlogin?token=" + resultToken;

            return objToken;
        }
        public string Encrypt(object value, object key)
        {
            var toEncrypt = JsonConvert.SerializeObject(value);
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key.ToString()));
            hashmd5.Clear();

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            var result = Convert.ToBase64String(resultArray, 0, resultArray.Length);

            result = EncryptionReplacements.Aggregate(result, (current, item) => current.Replace(item.Key, item.Value));
            return HttpUtility.UrlEncode(result);
            
        }

        /*public Task<TokenOffixDto> CreateTokenOffix(TokenOffixDto objToken)
        {
            throw new NotImplementedException();
        }*/

        private static readonly Dictionary<string, string> EncryptionReplacements = new Dictionary<string, string>
        {
            {"+", "_"},
            {"/", "-"},
            {"=", "!"}
        };

    }
}
