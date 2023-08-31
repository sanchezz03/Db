using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class Вакансія
{
    public int КодВакансії { get; set; }

    public int КодПідприємства { get; set; }

    public string? Вік { get; set; }

    public string? Стать { get; set; }

    public string? Освіта { get; set; }

    public bool? СоцПакет { get; set; }

    public int? ТривалістьРобочогоДняГодини { get; set; }

    public string? НазваВакансії { get; set; }

    public DateTime? ДатаСтворення { get; set; }

    public int? ДосвідРоботиРоки { get; set; }

    public virtual ICollection<ЗакритаВакансія> ЗакритаВакансіяs { get; set; } = new List<ЗакритаВакансія>();

    public virtual ICollection<ПерелікВакансій> ПерелікВакансійs { get; set; } = new List<ПерелікВакансій>();
}
