using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Criticreview
{
    public int CriticReviewId { get; set; }

    public int MovieId { get; set; }

    public decimal CriticScore { get; set; }

    public string CriticReview1 { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
