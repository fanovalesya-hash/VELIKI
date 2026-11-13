using System;
using System.Collections.Generic;

namespace VELIKI.Models;

public partial class Товары
{
    public string Артикул { get; set; } = null!;

    public string НаименованиеТовара { get; set; } = null!;

    public string ЕдиницаИзмерения { get; set; } = null!;

    public double Цена { get; set; }

    public int Поставщик { get; set; }

    public int Производитель { get; set; }

    public int КатегорияТовара { get; set; }

    public int ДействующаяСкидка { get; set; }

    public int КолВоНаСкладе { get; set; }

    public string ОписаниеТовара { get; set; } = null!;

    public string? Фото { get; set; }

    public int КодТовара { get; set; }

    public virtual КатегорииТоваров КатегорияТовараNavigation { get; set; } = null!;

    public virtual Поставщики ПоставщикNavigation { get; set; } = null!;

    public virtual Производители ПроизводительNavigation { get; set; } = null!;

    public virtual ICollection<СоставЗаказа> СоставЗаказаs { get; set; } = new List<СоставЗаказа>();
}
