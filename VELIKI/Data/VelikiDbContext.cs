using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VELIKI.Models;

namespace VELIKI.Data;

public partial class VelikiDbContext : DbContext
{
    public VelikiDbContext()
    {
    }

    public VelikiDbContext(DbContextOptions<VelikiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Заказы> Заказыs { get; set; }

    public virtual DbSet<КатегорииТоваров> КатегорииТоваровs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Поставщики> Поставщикиs { get; set; }

    public virtual DbSet<Производители> Производителиs { get; set; }

    public virtual DbSet<ПунктыВыдачи> ПунктыВыдачиs { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }

    public virtual DbSet<СоставЗаказа> СоставЗаказаs { get; set; }

    public virtual DbSet<СтатусыЗаказов> СтатусыЗаказовs { get; set; }

    public virtual DbSet<Товары> Товарыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LAB5;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Заказы>(entity =>
        {
            entity.HasKey(e => e.КодНомераЗаказа);

            entity.ToTable("Заказы");

            entity.Property(e => e.КодНомераЗаказа)
                .ValueGeneratedNever()
                .HasColumnName("Код_номера_заказа");
            entity.Property(e => e.АдресПунктаВыдачи).HasColumnName("Адрес_пункта_выдачи");
            entity.Property(e => e.ДатаДоставки).HasColumnName("Дата_доставки");
            entity.Property(e => e.ДатаЗаказа)
                .HasMaxLength(50)
                .HasColumnName("Дата_заказа");
            entity.Property(e => e.КодДляПолучения).HasColumnName("Код_для_получения");
            entity.Property(e => e.СтатусЗаказа).HasColumnName("Статус_заказа");

            entity.HasOne(d => d.АдресПунктаВыдачиNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.АдресПунктаВыдачи)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказы_Пункты выдачи");

            entity.HasOne(d => d.КлиентNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.Клиент)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказы_Пользователи");

            entity.HasOne(d => d.СтатусЗаказаNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.СтатусЗаказа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказы_Статусы заказов");
        });

        modelBuilder.Entity<КатегорииТоваров>(entity =>
        {
            entity.HasKey(e => e.КодКатегорииТовара);

            entity.ToTable("Категории товаров");

            entity.Property(e => e.КодКатегорииТовара)
                .ValueGeneratedNever()
                .HasColumnName("КОД_категории_товара");
            entity.Property(e => e.КатегорияТовара)
                .HasMaxLength(50)
                .HasColumnName("Категория_товара");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.КодПользователя);

            entity.ToTable("Пользователи");

            entity.Property(e => e.КодПользователя)
                .ValueGeneratedNever()
                .HasColumnName("КОД_Пользователя");
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.РольСотрудника).HasColumnName("Роль_сотрудника");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.РольСотрудникаNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.РольСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пользователи_роли");
        });

        modelBuilder.Entity<Поставщики>(entity =>
        {
            entity.HasKey(e => e.КодПоставщика);

            entity.ToTable("Поставщики");

            entity.Property(e => e.КодПоставщика)
                .ValueGeneratedNever()
                .HasColumnName("КОД_поставщика");
            entity.Property(e => e.Поставщик).HasMaxLength(50);
        });

        modelBuilder.Entity<Производители>(entity =>
        {
            entity.HasKey(e => e.КодПроизводителя);

            entity.ToTable("Производители");

            entity.Property(e => e.КодПроизводителя)
                .ValueGeneratedNever()
                .HasColumnName("КОД_производителя");
            entity.Property(e => e.Производитель).HasMaxLength(50);
        });

        modelBuilder.Entity<ПунктыВыдачи>(entity =>
        {
            entity.HasKey(e => e.КодПвз);

            entity.ToTable("Пункты выдачи");

            entity.Property(e => e.КодПвз)
                .ValueGeneratedNever()
                .HasColumnName("КОД_пвз");
            entity.Property(e => e.Город).HasMaxLength(50);
            entity.Property(e => e.ИндексПочтовый).HasColumnName("Индекс_почтовый");
            entity.Property(e => e.Улица).HasMaxLength(50);
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.HasKey(e => e.КодРоли);

            entity.ToTable("роли");

            entity.Property(e => e.КодРоли)
                .ValueGeneratedNever()
                .HasColumnName("КОД_роли");
            entity.Property(e => e.РольСотрудника)
                .HasMaxLength(50)
                .HasColumnName("Роль_сотрудника");
        });

        modelBuilder.Entity<СоставЗаказа>(entity =>
        {
            entity.HasKey(e => e.КодСоставаЗаказа);

            entity.ToTable("Состав заказа");

            entity.Property(e => e.КодСоставаЗаказа)
                .ValueGeneratedNever()
                .HasColumnName("КОД_состава_заказа");
            entity.Property(e => e.КодЗаказа).HasColumnName("КОД_заказа");
            entity.Property(e => e.КодТовара).HasColumnName("КОД_товара");
            entity.Property(e => e.Колв).HasColumnName("колв");

            entity.HasOne(d => d.КодЗаказаNavigation).WithMany(p => p.СоставЗаказаs)
                .HasForeignKey(d => d.КодЗаказа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Состав заказа_Заказы");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.СоставЗаказаs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Состав заказа_Товары");
        });

        modelBuilder.Entity<СтатусыЗаказов>(entity =>
        {
            entity.HasKey(e => e.КодСтатусаЗаказа);

            entity.ToTable("Статусы заказов");

            entity.Property(e => e.КодСтатусаЗаказа)
                .ValueGeneratedNever()
                .HasColumnName("КОД_статуса_заказа");
            entity.Property(e => e.СтатусЗаказа)
                .HasMaxLength(50)
                .HasColumnName("Статус_заказа");
        });

        modelBuilder.Entity<Товары>(entity =>
        {
            entity.HasKey(e => e.КодТовара);

            entity.ToTable("Товары");

            entity.Property(e => e.КодТовара)
                .ValueGeneratedNever()
                .HasColumnName("КОД_товара");
            entity.Property(e => e.Артикул).HasMaxLength(50);
            entity.Property(e => e.ДействующаяСкидка).HasColumnName("Действующая_скидка");
            entity.Property(e => e.ЕдиницаИзмерения)
                .HasMaxLength(50)
                .HasColumnName("Единица_измерения");
            entity.Property(e => e.КатегорияТовара).HasColumnName("Категория_товара");
            entity.Property(e => e.КолВоНаСкладе).HasColumnName("Кол_во_на_складе");
            entity.Property(e => e.НаименованиеТовара)
                .HasMaxLength(100)
                .HasColumnName("Наименование_товара");
            entity.Property(e => e.ОписаниеТовара)
                .HasMaxLength(250)
                .HasColumnName("Описание_товара");
            entity.Property(e => e.Фото).HasMaxLength(500);

            entity.HasOne(d => d.КатегорияТовараNavigation).WithMany(p => p.Товарыs)
                .HasForeignKey(d => d.КатегорияТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Товары_Категории товаров");

            entity.HasOne(d => d.ПоставщикNavigation).WithMany(p => p.Товарыs)
                .HasForeignKey(d => d.Поставщик)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Товары_Поставщики");

            entity.HasOne(d => d.ПроизводительNavigation).WithMany(p => p.Товарыs)
                .HasForeignKey(d => d.Производитель)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Товары_Производители");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
