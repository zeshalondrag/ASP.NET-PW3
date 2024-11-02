﻿using System;
using System.Collections.Generic;

namespace SORAPC.Models;

public partial class Catalogss
{
    public int IdCatalogs { get; set; }

    public string Names { get; set; } = null!;

    public string? Descriptions { get; set; }

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Categoryss? Category { get; set; }

    public virtual ICollection<PosOrder> PosOrders { get; set; } = new List<PosOrder>();
}