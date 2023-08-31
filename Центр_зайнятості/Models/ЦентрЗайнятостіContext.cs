using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Центр_зайнятості.Models;

public partial class ЦентрЗайнятостіContext : DbContext
{
    public ЦентрЗайнятостіContext()
    {
    }

    public ЦентрЗайнятостіContext(DbContextOptions<ЦентрЗайнятостіContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ІсторіяЗверненьДоБюро> ІсторіяЗверненьДоБюроs { get; set; }

    public virtual DbSet<Вакансія> Вакансіяs { get; set; }

    public virtual DbSet<Відмови> Відмовиs { get; set; }

    public virtual DbSet<ЗакритаВакансія> ЗакритаВакансіяs { get; set; }

    public virtual DbSet<Клієнт> Клієнтs { get; set; }

    public virtual DbSet<ПерелікВакансій> ПерелікВакансійs { get; set; }

    public virtual DbSet<Працівник> Працівникs { get; set; }

    public virtual DbSet<Підприємство> Підприємствоs { get; set; }
    public virtual DbSet<GetClientsByOwnershipForm> GetClientsByOwnershipForms { get; set; }
    public virtual DbSet<GetClientEmploymentPercentage> GetClientEmploymentPercentages { get; set; }
    public virtual DbSet<GetClientsAfterRequalification> GetClientsAfterRequalifications { get; set; }
    public virtual DbSet<GetClientsNotQualifiedAndRejected> GetClientsNotQualifiedAndRejecteds { get; set; }
    public virtual DbSet<GetCompaniesByWorkConditions> GetCompaniesByWorkConditions { get; set; } 
    public virtual DbSet<GetReturnedClients> GetReturnedClients { get; set; }
    public virtual DbSet<GetRepeatedlyContactedCompanies> GetRepeatedlyContactedCompanies { get; set; }
    public virtual DbSet<GetClientAndVacancyCounts> GetClientAndVacancyCounts { get; set; }
    public virtual DbSet<GetExcludedClients> GetExcludedClients { get; set; }   
    public virtual DbSet<GetUnfilledVacancies> GetUnfilledVacancies { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1ULUPV2; Database=Центр_зайнятості;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ІсторіяЗверненьДоБюро>(entity =>
        {
            entity.HasKey(e => e.КодЗапису).HasName("PK__Історія___C0C4DC9B708102AF");

            entity.ToTable("Історія_звернень_до_бюро", "Історія_звернень_до_бюро_schema", tb =>
                {
                    tb.HasTrigger("trgAfterInsertHistory");
                    tb.HasTrigger("trg_UpdateExperience");
                });

            entity.HasIndex(e => e.КодПрацівника, "IX_IstoriaZvernennya_KodPratsivnika");

            entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");
            entity.Property(e => e.ВідмоваВідЗапропонованихВакансій).HasColumnName("Відмова_від_запропонованих_вакансій");
            entity.Property(e => e.ДатаВлаштування)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Дата_влаштування");
            entity.Property(e => e.ДатаЗвернення)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Дата_звернення");
            entity.Property(e => e.ДатаПерекваліфікації)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Дата_перекваліфікації");
            entity.Property(e => e.КодПрацівника).HasColumnName("Код_працівника");
            entity.Property(e => e.КількістьВідмов).HasColumnName("Кількість_відмов");

            entity.HasOne(d => d.КодПрацівникаNavigation).WithMany(p => p.ІсторіяЗверненьДоБюроs)
                .HasForeignKey(d => d.КодПрацівника)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Історія_з__Код_п__4AB81AF0");
        });

        modelBuilder.Entity<Вакансія>(entity =>
        {
            entity.HasKey(e => e.КодВакансії).HasName("PK__Вакансія__E0D1F337274F8C02");

            entity.ToTable("Вакансія", "Вакансія_schema", tb => tb.HasTrigger("trgAfterUpdateVacancy"));

            entity.HasIndex(e => new { e.КодПідприємства, e.ДатаСтворення }, "IX_Vakansiya_KodPidpriyemstva_Dat");

            entity.Property(e => e.КодВакансії).HasColumnName("Код_вакансії");
            entity.Property(e => e.Вік)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ДатаСтворення)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Дата_створення");
            entity.Property(e => e.ДосвідРоботиРоки).HasColumnName("Досвід_роботи_роки");
            entity.Property(e => e.КодПідприємства).HasColumnName("Код_підприємства");
            entity.Property(e => e.НазваВакансії)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Назва_вакансії");
            entity.Property(e => e.Освіта)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.СоцПакет).HasColumnName("Соц_пакет");
            entity.Property(e => e.Стать)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ТривалістьРобочогоДняГодини).HasColumnName("Тривалість_робочого_дня_години");
        });

        modelBuilder.Entity<Відмови>(entity =>
        {
            entity.HasKey(e => e.КодВідмови).HasName("PK__Відмови__F96745356885A76F");

            entity.ToTable("Відмови", "Відмови_schema");

            entity.Property(e => e.КодВідмови).HasColumnName("Код_відмови");
            entity.Property(e => e.ДатаВідмови)
                .HasColumnType("date")
                .HasColumnName("Дата_відмови");
            entity.Property(e => e.КодКлієнта).HasColumnName("Код_клієнта");

            entity.HasOne(d => d.КодКлієнтаNavigation).WithMany(p => p.Відмовиs)
                .HasForeignKey(d => d.КодКлієнта)
                .HasConstraintName("FK__Відмови__Код_клі__619B8048");
        });

        modelBuilder.Entity<ЗакритаВакансія>(entity =>
        {
            entity.HasKey(e => e.НомерЗапису).HasName("PK__Закрита___0FD0EBA221094200");

            entity.ToTable("Закрита_вакансія", "Закрита_вакансія_schema", tb => tb.HasTrigger("trgAfterDeleteClosedVacancy"));

            entity.Property(e => e.НомерЗапису).HasColumnName("Номер_запису");
            entity.Property(e => e.ДатаЗакриття)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Дата_закриття");
            entity.Property(e => e.КодВакансії).HasColumnName("Код_вакансії");
            entity.Property(e => e.НазваВакансії)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Назва_вакансії");

            entity.HasOne(d => d.ВлаштованийNavigation).WithMany(p => p.ЗакритаВакансіяs)
                .HasForeignKey(d => d.Влаштований)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Закрита_в__Влашт__44FF419A");

            entity.HasOne(d => d.КодВакансіїNavigation).WithMany(p => p.ЗакритаВакансіяs)
                .HasForeignKey(d => d.КодВакансії)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Закрита_в__Код_в__440B1D61");
        });

        modelBuilder.Entity<Клієнт>(entity =>
        {
            entity.HasKey(e => e.КодКлієнта).HasName("PK__Клієнт__7210EB13C3880AB5");

            entity.ToTable("Клієнт", "Клієнт_schema");

            entity.Property(e => e.КодКлієнта).HasColumnName("Код_клієнта");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Імя).HasMaxLength(50);
            entity.Property(e => e.Адреса).HasMaxLength(200);
            entity.Property(e => e.ДатаЗнайденоїРоботи)
                .HasColumnType("date")
                .HasColumnName("Дата_знайденої_роботи");
            entity.Property(e => e.КодПідприємства).HasColumnName("Код_підприємства");
            entity.Property(e => e.НомерТелефону)
                .HasMaxLength(20)
                .HasColumnName("Номер_телефону");
            entity.Property(e => e.ФормаВласності)
                .HasMaxLength(50)
                .HasColumnName("Форма_власності");

            entity.HasOne(d => d.КодПідприємстваNavigation).WithMany(p => p.Клієнтs)
                .HasForeignKey(d => d.КодПідприємства)
                .HasConstraintName("FK__Клієнт__Код_підп__5CD6CB2B");
        });

        modelBuilder.Entity<ПерелікВакансій>(entity =>
        {
            entity.HasKey(e => e.КодЗапису).HasName("PK__Перелік___C0C4DC9B0E6E40BB");

            entity.ToTable("Перелік_вакансій", "Перелік_вакансій_schema");

            entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");
            entity.Property(e => e.КодВакансії).HasColumnName("Код_вакансії");
            entity.Property(e => e.КодПідприємства).HasColumnName("Код_підприємства");

            entity.HasOne(d => d.КодВакансіїNavigation).WithMany(p => p.ПерелікВакансійs)
                .HasForeignKey(d => d.КодВакансії)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Перелік_в__Код_в__3D5E1FD2");

            entity.HasOne(d => d.КодПідприємстваNavigation).WithMany(p => p.ПерелікВакансійs)
                .HasForeignKey(d => d.КодПідприємства)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Перелік_в__Код_п__3C69FB99");
        });

        modelBuilder.Entity<Працівник>(entity =>
        {
            entity.HasKey(e => e.КодПрацівника).HasName("PK__Працівни__A44513E83FCF02B4");

            entity.ToTable("Працівник", "Працівник_schema");

            entity.Property(e => e.КодПрацівника).HasColumnName("Код_працівника");
            entity.Property(e => e.Імя)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.АдресаПроживання)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Адреса_проживання");
            entity.Property(e => e.ДатаНародження)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Дата_народження");
            entity.Property(e => e.ДодатковіВміння)
                .HasColumnType("text")
                .HasColumnName("Додаткові_вміння");
            entity.Property(e => e.ДосвідРоботиРоки).HasColumnName("Досвід_роботи_роки");
            entity.Property(e => e.Навички).HasColumnType("text");
            entity.Property(e => e.НомерПаспорта)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Номер_паспорта");
            entity.Property(e => e.Освіта)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ПоБатькові)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("По_батькові");
            entity.Property(e => e.Прізвище)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.СеріяПаспорта)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Серія_паспорта");
        });

        modelBuilder.Entity<Підприємство>(entity =>
        {
            entity.HasKey(e => e.КодПідприємства).HasName("PK__Підприєм__82D21FA0451DF428");

            entity.ToTable("Підприємство", "Підприємство_schema", tb => tb.HasTrigger("trgAfterInsertCompany"));

            entity.HasIndex(e => e.Назва, "IX_Pidpriyemstvo_Nazva");

            entity.Property(e => e.КодПідприємства).HasColumnName("Код_підприємства");
            entity.Property(e => e.Назва)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.ПредставникПіб)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Представник_ПІБ");
            entity.Property(e => e.РозташуванняОфісу)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Розташування_офісу");
        });

        modelBuilder.Entity<GetClientsByOwnershipForm>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetClientEmploymentPercentage>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetClientsAfterRequalification>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetClientsNotQualifiedAndRejected>(entity =>
        {
            entity.HasNoKey();
        });
   
        modelBuilder.Entity<GetCompaniesByWorkConditions>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetReturnedClients>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetRepeatedlyContactedCompanies>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetClientAndVacancyCounts>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetExcludedClients>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetUnfilledVacancies>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
