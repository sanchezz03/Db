using System;
using System.Collections.Generic;

namespace Центр_зайнятості.Models;

public partial class Клієнт
{
    public int КодКлієнта { get; set; }

    public int? КодПідприємства { get; set; }

    public string? Імя { get; set; }

    public string? ФормаВласності { get; set; }

    public string? НомерТелефону { get; set; }

    public string? Email { get; set; }

    public string? Адреса { get; set; }

    public DateTime? ДатаЗнайденоїРоботи { get; set; }

    public virtual ICollection<Відмови> Відмовиs { get; set; } = new List<Відмови>();

    public virtual Підприємство? КодПідприємстваNavigation { get; set; }
}
