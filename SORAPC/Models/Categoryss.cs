using System;
using System.Collections.Generic;

namespace SORAPC.Models;

public partial class Categoryss
{
    public int IdCategorys { get; set; }

    public string Names { get; set; } = null!;

    public virtual ICollection<Catalogss> Catalogsses { get; set; } = new List<Catalogss>();
}
