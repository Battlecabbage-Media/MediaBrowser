using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class Rental
{
    public int RentalId { get; set; }

    public int UserId { get; set; }

    public DateTime? RentalDate { get; set; }

    public int? RentalDuration { get; set; }

    public DateTime? ScheduledReturnDate { get; set; }

    public int? ActualDuration { get; set; }

    public DateTime? ActualReturnDate { get; set; }

    public int? MediaId { get; set; }

    public double RentalAmount { get; set; }

    public double AdditionalFees { get; set; }

    public double TotalAmount { get; set; }

    public int KioskId { get; set; }
}
