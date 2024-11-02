﻿using System;
using System.Collections.Generic;

namespace SORAPC.Models;

public partial class Orderss
{
    public int IdOrders { get; set; }

    public int? UsersId { get; set; }

    public string? Dates { get; set; }

    public decimal? TotalSum { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<PosOrder> PosOrders { get; set; } = new List<PosOrder>();

    public virtual Statuss? Status { get; set; }

    public virtual Userss? Users { get; set; }
}