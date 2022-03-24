using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class TransactionalResponseEntity
    {
        public ApiResultEntity Result { get; set; }
        public List<ApiResponseEntity> TransactionResponses { get; set; }
    }
}
