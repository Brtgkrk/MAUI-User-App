using System;
using System.Collections.Generic;

namespace ScaffoldingProject.Models;

public partial class Training
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime Date { get; set; }

    public string Place { get; set; } = null!;

    public string? Description { get; set; }

    public long UserId { get; set; }
}
