using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class Пользователи
{
    public int РольСотрудника { get; set; }

    public string Фио { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public int КодПользователя { get; set; }

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();

    public virtual Роли РольСотрудникаNavigation { get; set; } = null!;
}
