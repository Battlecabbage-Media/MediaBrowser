using System;
using System.Collections.Generic;

namespace MediaBrowser.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string? CreditCardNumber { get; set; }

    public DateTime CreditCardExpiration { get; set; }

    public DateTime MemberSince { get; set; }
}
