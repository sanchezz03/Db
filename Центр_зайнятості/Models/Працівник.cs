using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class Працівник
{
    public int КодПрацівника { get; set; }

    public string? Імя { get; set; }

    public string? Прізвище { get; set; }

    public string? ПоБатькові { get; set; }

    public DateTime? ДатаНародження { get; set; }

    public int? ДосвідРоботиРоки { get; set; }

    public string? Навички { get; set; }

    public string? Освіта { get; set; }

    public string? АдресаПроживання { get; set; }

    public string? СеріяПаспорта { get; set; }

    public string? НомерПаспорта { get; set; }

    public string? ДодатковіВміння { get; set; }

    public virtual ICollection<ІсторіяЗверненьДоБюро> ІсторіяЗверненьДоБюроs { get; set; } = new List<ІсторіяЗверненьДоБюро>();

    public virtual ICollection<ЗакритаВакансія> ЗакритаВакансіяs { get; set; } = new List<ЗакритаВакансія>();
}
