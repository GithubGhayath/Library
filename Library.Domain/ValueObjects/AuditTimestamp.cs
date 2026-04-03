using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.ValueObjects
{
    public class AuditTimestamp
    {
        public DateTime? CreateAt { get; }
        public DateTime? UpdateAt { get;}
        public AuditTimestamp(DateTime? createAt, DateTime? updatedAt)
        {
            CreateAt = createAt;
            UpdateAt = updatedAt;
        }
        public AuditTimestamp() { }
    }
}
