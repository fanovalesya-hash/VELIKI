using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class КатегорииТоваров
{
    public string КатегорияТовара { get; set; } = null!;

    public int КодКатегорииТовара { get; set; }

    public virtual ICollection<Товары> Товарыs { get; set; } = new List<Товары>();
}
