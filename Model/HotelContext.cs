using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Model;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdaptacaoQuarto> AdaptacaoQuartos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contum> Conta { get; set; }

    public virtual DbSet<Filial> Filials { get; set; }

    public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; }

    public virtual DbSet<Funcao> Funcaos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<ItemConsumivelFilial> ItemConsumivelFilials { get; set; }

    public virtual DbSet<ItemContum> ItemConta { get; set; }

    public virtual DbSet<ItemLavanderiaContum> ItemLavanderiaConta { get; set; }

    public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }

    public virtual DbSet<Quarto> Quartos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservaQuarto> ReservaQuartos { get; set; }

    public virtual DbSet<ServicoLavanderium> ServicoLavanderia { get; set; }

    public virtual DbSet<TipoQuarto> TipoQuartos { get; set; }

    public virtual DbSet<ValorQuartoFilial> ValorQuartoFilials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ANDRE\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdaptacaoQuarto>(entity =>
        {
            entity.HasKey(e => e.CodAdaptacao).HasName("Pk_codAdaptacao");

            entity.ToTable("AdaptacaoQuarto");

            entity.Property(e => e.CodAdaptacao).HasColumnName("codAdaptacao");
            entity.Property(e => e.TipoAdaptacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoAdaptacao");
            
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("Pk_idCliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nacionalidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nacionalidade");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Contum>(entity =>
        {
            entity.HasKey(e => e.CodConta).HasName("Pk_codConta");

            entity.Property(e => e.CodConta).HasColumnName("codConta");
            entity.Property(e => e.IdNotaConta).HasColumnName("idNotaConta");

            entity.HasOne(d => d.IdNotaContaNavigation).WithMany(p => p.Conta)
                .HasForeignKey(d => d.IdNotaConta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_numNota");
        });

        modelBuilder.Entity<Filial>(entity =>
        {
            entity.HasKey(e => e.IdFilial).HasName("Pk_idFilial");

            entity.ToTable("Filial");

            entity.Property(e => e.IdFilial).HasColumnName("idFilial");
            entity.Property(e => e.EnderecoFilial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("enderecoFilial");
            entity.Property(e => e.Estrelas).HasColumnName("estrelas");
            entity.Property(e => e.NomeFilial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomeFilial");
            entity.Property(e => e.QuartosCasal).HasColumnName("quartosCasal");
            entity.Property(e => e.QuartosFamilia).HasColumnName("quartosFamilia");
            entity.Property(e => e.QuartosPresidencial).HasColumnName("quartosPresidencial");
            entity.Property(e => e.QuartosSolteiro).HasColumnName("quartosSolteiro");
        });

        modelBuilder.Entity<FormaPagamento>(entity =>
        {
            entity.HasKey(e => e.CodTipoPagamento).HasName("Pk_codTipoPagamento");

            entity.ToTable("FormaPagamento");

            entity.Property(e => e.CodTipoPagamento).HasColumnName("codTipoPagamento");
            entity.Property(e => e.TipoPagamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipoPagamento");
        });

        modelBuilder.Entity<Funcao>(entity =>
        {
            entity.HasKey(e => e.CodFuncao).HasName("Pk_codFuncao");

            entity.ToTable("Funcao");

            entity.Property(e => e.CodFuncao).HasColumnName("codFuncao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Funcao1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("funcao");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("Pk_idFuncionario");

            entity.ToTable("Funcionario");

            entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");
            entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.IdFilialFuncionario).HasColumnName("idFilialFuncionario");
            entity.Property(e => e.IdFuncao).HasColumnName("idFuncao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("telefone");

            entity.HasOne(d => d.IdFilialFuncionarioNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdFilialFuncionario)
                .HasConstraintName("Fk_idFilialFuncionario");

            entity.HasOne(d => d.IdFuncaoNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdFuncao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_idFuncao");
        });

        modelBuilder.Entity<ItemConsumivelFilial>(entity =>
        {
            entity.HasKey(e => e.CodItem).HasName("Pk_codItem");

            entity.ToTable("ItemConsumivelFilial");

            entity.Property(e => e.CodItem).HasColumnName("codItem");
            entity.Property(e => e.IdFilialItem).HasColumnName("idFilialItem");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ValorUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valorUnitario");

            entity.HasOne(d => d.IdFilialItemNavigation).WithMany(p => p.ItemConsumivelFilials)
                .HasForeignKey(d => d.IdFilialItem)
                .HasConstraintName("Fk_idFilialItem");
        });

        modelBuilder.Entity<ItemContum>(entity =>
        {
            entity.HasKey(e => new { e.CodItem, e.CodConta }).HasName("Pk_ItemConta");

            entity.Property(e => e.CodItem).HasColumnName("codItem");
            entity.Property(e => e.CodConta).HasColumnName("codConta");
            entity.Property(e => e.AcrescimoEntrega)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("acrescimoEntrega");
            entity.Property(e => e.Item)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("item");
            entity.Property(e => e.Origem)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("origem");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.CodContaNavigation).WithMany(p => p.ItemConta)
                .HasForeignKey(d => d.CodConta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_codConta");

            entity.HasOne(d => d.CodItemNavigation).WithMany(p => p.ItemConta)
                .HasForeignKey(d => d.CodItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_codItem");
        });

        modelBuilder.Entity<ItemLavanderiaContum>(entity =>
        {
            entity.HasKey(e => e.CodItemLavanderia).HasName("Pk_ItemLavanderiaConta");

            entity.Property(e => e.CodItemLavanderia).HasColumnName("codItemLavanderia");
            entity.Property(e => e.CodConta).HasColumnName("codConta");
            entity.Property(e => e.IdServicoLavanderia).HasColumnName("idServicoLavanderia");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Servico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("servico");

            entity.HasOne(d => d.CodContaNavigation).WithMany(p => p.ItemLavanderiaConta)
                .HasForeignKey(d => d.CodConta)
                .HasConstraintName("Fk_codContaLavanderia");

            entity.HasOne(d => d.IdServicoLavanderiaNavigation).WithMany(p => p.ItemLavanderiaConta)
                .HasForeignKey(d => d.IdServicoLavanderia)
                .HasConstraintName("Fk_idServicoLavanderia");
        });

        modelBuilder.Entity<NotaFiscal>(entity =>
        {
            entity.HasKey(e => e.NumNota).HasName("Pk_numNota");

            entity.ToTable("NotaFiscal");

            entity.Property(e => e.NumNota).HasColumnName("numNota");
            entity.Property(e => e.CodTipoPagamento).HasColumnName("codTipoPagamento");
            entity.Property(e => e.ValorTotal)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valorTotal");

            entity.HasOne(d => d.CodTipoPagamentoNavigation).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.CodTipoPagamento)
                .HasConstraintName("Fk_idFormaPagamento");
        });

        modelBuilder.Entity<Quarto>(entity =>
        {
            entity.HasKey(e => e.NumQuarto).HasName("Pk_numQuarto");

            entity.ToTable("Quarto");

            entity.Property(e => e.NumQuarto).HasColumnName("numQuarto");
            entity.Property(e => e.IdAdaptacao).HasColumnName("idAdaptacao");
            entity.Property(e => e.IdFilialQuarto).HasColumnName("idFilialQuarto");
            entity.Property(e => e.IdTipoQuarto).HasColumnName("idTipoQuarto");

            entity.HasOne(d => d.IdAdaptacaoNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.IdAdaptacao)
                .HasConstraintName("Fk_idAdaptacao");

            entity.HasOne(d => d.IdFilialQuartoNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.IdFilialQuarto)
                .HasConstraintName("Fk_idFilialQuarto");

            entity.HasOne(d => d.IdTipoQuartoNavigation).WithMany(p => p.Quartos)
                .HasForeignKey(d => d.IdTipoQuarto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_idTipoQuarto");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("Pk_idReserva");

            entity.ToTable("Reserva");

            entity.Property(e => e.IdReserva).HasColumnName("idReserva");
            entity.Property(e => e.AdicionarColchao).HasColumnName("adicionarColchao");
            entity.Property(e => e.IdClienteReserva).HasColumnName("idClienteReserva");
            entity.Property(e => e.IdFuncionarioReserva).HasColumnName("idFuncionarioReserva");

            entity.HasOne(d => d.IdClienteReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdClienteReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_idClienteReserva");

            entity.HasOne(d => d.IdFuncionarioReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFuncionarioReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_idFuncionarioReserva");
        });

        modelBuilder.Entity<ReservaQuarto>(entity =>
        {
            entity.HasKey(e => e.IdReservaQuarto).HasName("Pk_idReservaQuarto");

            entity.ToTable("ReservaQuarto");

            entity.Property(e => e.IdReservaQuarto).HasColumnName("idReservaQuarto");
            entity.Property(e => e.Cancelada)
                .HasDefaultValue(false)
                .HasColumnName("cancelada");
            entity.Property(e => e.DataCheckIn).HasColumnName("dataCheckIn");
            entity.Property(e => e.DataCheckOut).HasColumnName("dataCheckOut");
            entity.Property(e => e.IdQuarto).HasColumnName("idQuarto");
            entity.Property(e => e.IdReserva).HasColumnName("idReserva");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaQuartos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("Fk_idReserva");
        });

        modelBuilder.Entity<ServicoLavanderium>(entity =>
        {
            entity.HasKey(e => e.IdServicoLavanderia).HasName("Pk_idServicoLavanderia");

            entity.Property(e => e.IdServicoLavanderia).HasColumnName("idServicoLavanderia");
            entity.Property(e => e.NomeServico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomeServico");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco");
        });

        modelBuilder.Entity<TipoQuarto>(entity =>
        {
            entity.HasKey(e => e.CodTipoQuarto).HasName("Pk_codTipoQuarto");

            entity.ToTable("TipoQuarto");

            entity.Property(e => e.CodTipoQuarto).HasColumnName("codTipoQuarto");
            entity.Property(e => e.CapacidadeMaxima).HasColumnName("capacidadeMaxima");
            entity.Property(e => e.CapacidadeOpcional).HasColumnName("capacidadeOpcional");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.TipoQuarto1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipoQuarto");
        });

        modelBuilder.Entity<ValorQuartoFilial>(entity =>
        {
            entity.HasKey(e => e.IdValorQuartoFilial).HasName("Pk_idValorQuartoFilial");

            entity.ToTable("ValorQuartoFilial");

            entity.Property(e => e.IdValorQuartoFilial).HasColumnName("idValorQuartoFilial");
            entity.Property(e => e.CodTipoQuarto).HasColumnName("codTipoQuarto");
            entity.Property(e => e.DiariaQuartoFilial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("diariaQuartoFilial");
            entity.Property(e => e.IdFilial).HasColumnName("idFilial");

            entity.HasOne(d => d.CodTipoQuartoNavigation).WithMany(p => p.ValorQuartoFilials)
                .HasForeignKey(d => d.CodTipoQuarto)
                .HasConstraintName("Fk_codTipoQuarto");

            entity.HasOne(d => d.IdFilialNavigation).WithMany(p => p.ValorQuartoFilials)
                .HasForeignKey(d => d.IdFilial)
                .HasConstraintName("Fk_idFilial");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
