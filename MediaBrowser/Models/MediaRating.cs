using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class MediaRating
{
    public string Tconst { get; set; } = null!;

    public double AverageRating { get; set; }

    public int NumVotes { get; set; }
}
