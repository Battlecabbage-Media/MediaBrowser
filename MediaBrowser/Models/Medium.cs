using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Medium
{
    public int MediaId { get; set; }

    public string? Title { get; set; }

    public int? YearReleased { get; set; }

    public int? RuntimeMinutes { get; set; }

    public double? AverageRating { get; set; }

    public int? NumberOfVotes { get; set; }
}
