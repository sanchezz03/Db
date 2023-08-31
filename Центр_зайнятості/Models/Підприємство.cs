using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class Підприємство
{
    public int КодПідприємства { get; set; }

    public string? Назва { get; set; }

    public string? РозташуванняОфісу { get; set; }

    public string? ПредставникПіб { get; set; }

    public virtual ICollection<Клієнт> Клієнтs { get; set; } = new List<Клієнт>();

    public virtual ICollection<ПерелікВакансій> ПерелікВакансійs { get; set; } = new List<ПерелікВакансій>();
}
