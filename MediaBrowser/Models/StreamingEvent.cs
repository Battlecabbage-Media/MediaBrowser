using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class StreamingEvent
{
    public Guid StreamingId { get; set; }

    public Guid SessionId { get; set; }

    public DateTime EventTime { get; set; }

    public int UserId { get; set; }

    public int MediaId { get; set; }

    public string EventType { get; set; } = null!;

    public int Duration { get; set; }

    public string PlatformType { get; set; } = null!;

    public string PlatformName { get; set; } = null!;
}
