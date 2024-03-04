using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    public string Director1 { get; set; } = null!;

    public virtual ICollection<Directorstomoviesjoin> Directorstomoviesjoins { get; set; } = new List<Directorstomoviesjoin>();

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
