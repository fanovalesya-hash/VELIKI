using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class ПунктыВыдачи
{
    public int ИндексПочтовый { get; set; }

    public string Город { get; set; } = null!;

    public string Улица { get; set; } = null!;

    public byte Дом { get; set; }

    public int КодПвз { get; set; }

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();
}
