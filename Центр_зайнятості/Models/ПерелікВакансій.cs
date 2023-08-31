using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class ПерелікВакансій
{
    public int КодЗапису { get; set; }

    public int? КодПідприємства { get; set; }

    public int? КодВакансії { get; set; }

    public virtual Вакансія? КодВакансіїNavigation { get; set; }

    public virtual Підприємство? КодПідприємстваNavigation { get; set; }
}
