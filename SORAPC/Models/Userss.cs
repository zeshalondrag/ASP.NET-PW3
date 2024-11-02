using System;
using System.Collections.Generic;

namespace SORAPC.Models;

public partial class Userss
{
    public int IdUsers { get; set; }

    public string Logins { get; set; } = null!;

    public string Passwords { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Orderss> Ordersses { get; set; } = new List<Orderss>();
}
