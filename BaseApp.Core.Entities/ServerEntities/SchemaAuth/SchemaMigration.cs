using System;
using System.Collections.Generic;

namespace BaseApp.Core.Entities.ServerEntities.SchemaAuth;

/// <summary>
/// Auth: Manages updates to the auth system.
/// </summary>
public partial class SchemaMigration
{
    public string Version { get; set; } = null!;
}
