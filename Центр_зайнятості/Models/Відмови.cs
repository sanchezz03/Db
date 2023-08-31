using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class Відмови
{
    public int КодВідмови { get; set; }

    public int? КодКлієнта { get; set; }

    public DateTime? ДатаВідмови { get; set; }

    public virtual Клієнт? КодКлієнтаNavigation { get; set; }
}
