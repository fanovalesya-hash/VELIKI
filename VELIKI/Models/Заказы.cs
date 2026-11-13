using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class Заказы
{
    public int КодНомераЗаказа { get; set; }

    public string ДатаЗаказа { get; set; } = null!;

    public DateOnly ДатаДоставки { get; set; }

    public int АдресПунктаВыдачи { get; set; }

    public int Клиент { get; set; }

    public short КодДляПолучения { get; set; }

    public int СтатусЗаказа { get; set; }

    public virtual ПунктыВыдачи АдресПунктаВыдачиNavigation { get; set; } = null!;

    public virtual Пользователи КлиентNavigation { get; set; } = null!;

    public virtual ICollection<СоставЗаказа> СоставЗаказаs { get; set; } = new List<СоставЗаказа>();

    public virtual СтатусыЗаказов СтатусЗаказаNavigation { get; set; } = null!;
}
