using System;
using System.Application.Main.Dtos.Token;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuxion.Custom
{
    public interface IToken
    {
        Task<TokenDto> CreateToken(TokenDto objToken);

        //Task<TokenOffixDto> CreateTokenOffix(object value,string sistema);

        //Task<TokenOffixDto> CreateTokenOffixV2(object value, string sistema);
    }
}
