using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class СтатусыЗаказов
{
    public string СтатусЗаказа { get; set; } = null!;

    public int КодСтатусаЗаказа { get; set; }

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();
}
