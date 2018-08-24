using System;

namespace CheatSheet.Database
{
    public class Tenant: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}