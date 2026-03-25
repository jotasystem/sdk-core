using System;
using System.Collections.Generic;
using System.Text;

namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public interface IAuditableRequest
    {
        AuditDefinition GetAuditDefinition();
        AuditPayload? GetAuditPayload();
    }
}
