using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string ExternalId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Tagline { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string MpaaRating { get; set; } = null!;

    public decimal PopularityScore { get; set; }

    public int GenreId { get; set; }

    public string? PosterUrl { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public virtual ICollection<Actorstomoviesjoin> Actorstomoviesjoins { get; set; } = new List<Actorstomoviesjoin>();

    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();

    public virtual ICollection<Director> Directors { get; set; } = new List<Director>();

    public virtual ICollection<Criticreview> Criticreviews { get; set; } = new List<Criticreview>();

    public virtual ICollection<Directorstomoviesjoin> Directorstomoviesjoins { get; set; } = new List<Directorstomoviesjoin>();

    public virtual Genre Genre { get; set; } = null!;
}
