using System;
using System.Collections.Generic;

namespace ScaffoldingProject.Models;

public partial class TrainingPlan
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public long UserId { get; set; }
}
