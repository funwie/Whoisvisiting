using System;

namespace Whoisvisiting.SqlDataAccess
{
    public abstract class DatabaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
