using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class Поставщики
{
    public string Поставщик { get; set; } = null!;

    public int КодПоставщика { get; set; }

    public virtual ICollection<Товары> Товарыs { get; set; } = new List<Товары>();
}
