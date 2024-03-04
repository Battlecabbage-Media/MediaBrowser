using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Actor
{
    public int ActorId { get; set; }

    public string Actor1 { get; set; } = null!;

    public virtual ICollection<Actorstomoviesjoin> Actorstomoviesjoins { get; set; } = new List<Actorstomoviesjoin>();

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
