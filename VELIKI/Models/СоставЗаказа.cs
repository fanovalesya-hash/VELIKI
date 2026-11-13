using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class СоставЗаказа
{
    public int КодТовара { get; set; }

    public int Колв { get; set; }

    public int КодСоставаЗаказа { get; set; }

    public int КодЗаказа { get; set; }

    public virtual Заказы КодЗаказаNavigation { get; set; } = null!;

    public virtual Товары КодТовараNavigation { get; set; } = null!;
}
