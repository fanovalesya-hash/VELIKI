using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class Производители
{
    public string Производитель { get; set; } = null!;

    public int КодПроизводителя { get; set; }

    public virtual ICollection<Товары> Товарыs { get; set; } = new List<Товары>();
}
