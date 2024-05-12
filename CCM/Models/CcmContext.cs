using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CCM.Models;

public partial class CcmContext : DbContext
{
    public CcmContext()
    {
    }

    public CcmContext(DbContextOptions<CcmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardClass> CardClasses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.97.2;database=CCM;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.6-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Bank");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.EnglishName)
                .HasMaxLength(255)
                .HasColumnName("englishName");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ShortName)
                .HasMaxLength(255)
                .HasColumnName("shortName");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Card");

            entity.HasIndex(e => e.CardClassId, "Card_CardClass_id_fk");

            entity.HasIndex(e => e.CustomerId, "Card_Customer_id_fk");

            entity.HasIndex(e => e.Number, "Card_pk_2").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CardClassId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("cardClassId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("customerId");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CardClass).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CardClassId)
                .HasConstraintName("Card_CardClass_id_fk");

            entity.HasOne(d => d.Customer).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("Card_Customer_id_fk");
        });

        modelBuilder.Entity<CardClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CardClass");

            entity.HasIndex(e => e.BankId, "CardType_Bank_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.BankId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("bankId");
            entity.Property(e => e.Bin)
                .HasMaxLength(255)
                .HasColumnName("bin");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DueDate)
                .HasColumnType("bigint(20)")
                .HasColumnName("dueDate");
            entity.Property(e => e.FreePeriod)
                .HasColumnType("bigint(20)")
                .HasColumnName("freePeriod");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.SampleLink)
                .HasMaxLength(255)
                .HasColumnName("sampleLink");
            entity.Property(e => e.StatementDate)
                .HasColumnType("bigint(20)")
                .HasColumnName("statementDate");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Bank).WithMany(p => p.CardClasses)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CardType_Bank_id_fk");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.PhoneNumber, "Customer_pk_2").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("displayName");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Store");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.CardId, "Transaction_Card_id_fk");

            entity.HasIndex(e => e.StoreId, "Transaction_Store_id_fk");

            entity.HasIndex(e => e.StatusId, "Transaction___fk");

            entity.HasIndex(e => e.Code, "Transation_pk_2").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CardId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("cardId");
            entity.Property(e => e.Code)
                .HasComment("(TID)")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Fee).HasColumnName("fee");
            entity.Property(e => e.StatusId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("statusId");
            entity.Property(e => e.StoreId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("storeId");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Card).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Transaction_Card_id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("Transaction___fk");

            entity.HasOne(d => d.Store).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("Transaction_Store_id_fk");
        });

        modelBuilder.Entity<TransactionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TransactionStatus");

            entity.HasIndex(e => e.Code, "TransactionStatus_pk").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
