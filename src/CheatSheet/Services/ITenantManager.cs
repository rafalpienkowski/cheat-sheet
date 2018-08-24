using System;
using CheatSheet.Database;

namespace CheatSheet.Services
{
    public interface ITenantManager : IActionManager
    {
        Tenant GetTenant(Guid id);
    }
}