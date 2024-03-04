using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Directorstomoviesjoin
{
    public int DirectorId { get; set; }

    public int MovieId { get; set; }


    public virtual Director Director { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
