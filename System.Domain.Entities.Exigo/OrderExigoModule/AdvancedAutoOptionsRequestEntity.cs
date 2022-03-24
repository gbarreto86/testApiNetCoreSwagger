using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class AdvancedAutoOptionsRequestEntity
    {
        public DateTime? ProcessWhileDate { get; set; }
        public DateTime? SkipUntilDate { get; set; }
        public DateTime? DetailStartDate { get; set; }
        public DateTime? DetailEndDate { get; set; }
        public int? DetailInterval { get; set; }
    }
}
