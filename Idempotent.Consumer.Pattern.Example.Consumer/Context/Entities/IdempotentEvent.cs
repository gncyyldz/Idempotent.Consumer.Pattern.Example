using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idempotent.Consumer.Pattern.Example.Consumer.Context.Entities
{
    public class IdempotentEvent
    {
        public DateTime OccuredOn { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string Type { get; set; } = null!;
        public Guid IdempotentToken { get; set; }
    }
}