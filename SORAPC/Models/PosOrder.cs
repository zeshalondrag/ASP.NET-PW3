using System;
using System.Collections.Generic;

namespace SORAPC.Models;

public partial class PosOrder
{
    public int IdPosOrders { get; set; }

    public int? OrdersId { get; set; }

    public int? CatalogsId { get; set; }

    public int? Counts { get; set; }

    public decimal? Price { get; set; }

    public virtual Catalogss? Catalogs { get; set; }

    public virtual Orderss? Orders { get; set; }
}
