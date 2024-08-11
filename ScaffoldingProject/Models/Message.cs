using System;
using System.Collections.Generic;

namespace ScaffoldingProject.Models;

public partial class Message
{
    public long Id { get; set; }

    public string Topic { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public DateTime InsertedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
