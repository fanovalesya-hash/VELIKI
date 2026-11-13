using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class Роли
{
    public string РольСотрудника { get; set; } = null!;

    public int КодРоли { get; set; }

    public virtual ICollection<Пользователи> Пользователиs { get; set; } = new List<Пользователи>();
}
