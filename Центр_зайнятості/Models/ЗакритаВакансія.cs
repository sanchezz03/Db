using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class ЗакритаВакансія
{
    public int НомерЗапису { get; set; }

    public int? КодВакансії { get; set; }

    public int? Влаштований { get; set; }

    public string? НазваВакансії { get; set; }

    public DateTime? ДатаЗакриття { get; set; }

    public virtual Працівник? ВлаштованийNavigation { get; set; }

    public virtual Вакансія? КодВакансіїNavigation { get; set; }
}
