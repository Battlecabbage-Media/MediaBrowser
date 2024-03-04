using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Actorstomoviesjoin
{
    public int ActorId { get; set; }

    public int MovieId { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
