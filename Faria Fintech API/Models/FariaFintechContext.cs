using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Faria_Fintech_API.Models
{
    public partial class FariaFintechContext : DbContext
    {
        public FariaFintechContext()
        {
        }

        public FariaFintechContext(DbContextOptions<FariaFintechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Contum> Conta { get; set; }
        public virtual DbSet<TipoContum> TipoConta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Faria Fintech;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTE__23A34130B3FE49E7");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("CIDADE");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CADASTRO");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("ENDERECO");

                entity.Property(e => e.IndAtivo).HasColumnName("IND_ATIVO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.SglEstado)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SGL_ESTADO");
            });

            modelBuilder.Entity<Contum>(entity =>
            {
                entity.HasKey(e => e.IdConta)
                    .HasName("PK__CONTA__48E8AE501EF63D10");

                entity.ToTable("CONTA");

                entity.Property(e => e.IdConta).HasColumnName("ID_CONTA");

                entity.Property(e => e.CodCliente).HasColumnName("COD_CLIENTE");

                entity.Property(e => e.CodTipoConta).HasColumnName("COD_TIPO_CONTA");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CADASTRO");

                entity.Property(e => e.IndAtivo).HasColumnName("IND_ATIVO");

                entity.Property(e => e.NumAgencia).HasColumnName("NUM_AGENCIA");

                entity.Property(e => e.NumConta).HasColumnName("NUM_CONTA");

                entity.Property(e => e.VlrSaldo)
                    .HasColumnType("money")
                    .HasColumnName("VLR_SALDO");

                entity.HasOne(d => d.CodTipoContaNavigation)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.CodTipoConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONTA__COD_CLIEN__267ABA7A");
            });

            modelBuilder.Entity<TipoContum>(entity =>
            {
                entity.HasKey(e => e.IdTipoConta)
                    .HasName("PK__TIPO_CON__7BB0E3D0A7A27063");

                entity.ToTable("TIPO_CONTA");

                entity.Property(e => e.IdTipoConta).HasColumnName("ID_TIPO_CONTA");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CADASTRO");

                entity.Property(e => e.DscTipoConta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("DSC_TIPO_CONTA");

                entity.Property(e => e.IndAtivo).HasColumnName("IND_ATIVO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
