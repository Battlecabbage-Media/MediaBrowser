using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
