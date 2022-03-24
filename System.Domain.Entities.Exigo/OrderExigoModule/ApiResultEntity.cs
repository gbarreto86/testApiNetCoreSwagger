using System.Domain.Entities.Exigo;

namespace System.Domain.Entities.Exigo
{
    public class ApiResultEntity
    {
        public ResultStatus Status { get; set; }
        public string[] Errors { get; set; }
        public string TransactionKey { get; set; }
    }
}
