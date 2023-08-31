using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class ІсторіяЗверненьДоБюро
{
    public int КодЗапису { get; set; }

    public int? КодПрацівника { get; set; }

    public DateTime? ДатаЗвернення { get; set; }

    public bool? Перекваліфікація { get; set; }

    public DateTime? ДатаПерекваліфікації { get; set; }

    public DateTime? ДатаВлаштування { get; set; }

    public bool? ВідмоваВідЗапропонованихВакансій { get; set; }

    public int? КількістьВідмов { get; set; }

    public virtual Працівник? КодПрацівникаNavigation { get; set; }
}
