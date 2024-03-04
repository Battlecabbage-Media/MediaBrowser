using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Kiosk
{
    public int KioskId { get; set; }

    public string Address { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public DateTime? InstallDate { get; set; }
}
