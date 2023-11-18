using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Pim___WEB.Models;


namespace Pim___WEB.Data
{
    public partial class db_folha_pagamento_pim_context : DbContext
    {
        private IConfiguration Configuration { get; }

        public db_folha_pagamento_pim_context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public db_folha_pagamento_pim_context(DbContextOptions<db_folha_pagamento_pim_context> opts, IConfiguration configuration) : base(opts)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<InformacoesPagamento> InformacoesPagamentos { get; set; }
        public virtual DbSet<RegistrosHorasTrabalhadas> RegistrosHorasTrabalhadas { get; set; }
        public virtual DbSet<RelatorioPagamento> RelatorioPagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Connection"));
            }
        }

        private void SetEntityProperties(PropertyBuilder property, int maxLength = -1)
        {
            if (maxLength > -1)
            {
                property.HasMaxLength(maxLength);
            }

            property.IsUnicode(false);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionarios>()
                .HasMany(Funcionarios => Funcionarios.RelatorioPagamentos)
                .WithOne(RelatorioPagamento => RelatorioPagamento.funcionarios)
                .HasForeignKey(RelatorioPagamento => RelatorioPagamento.CPF);

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(funcionarios => funcionarios.CPF);

                SetEntityProperties(entity.Property(funcionarios => funcionarios.CPF), 14);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.NomeCompleto), 150);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.TelefoneCelular), 15);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.DataNascimento));
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Cidade), 100);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Estado), 2);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Endereco), 100);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Bairro), 100);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Email), 100);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Cargo), 50);
                SetEntityProperties(entity.Property(funcionarios => funcionarios.Senha), 100);
            });

            modelBuilder.Entity<InformacoesPagamento>(entity =>
            {
                entity.HasKey(informacoesPagamento => informacoesPagamento.PagamentoId);

                SetEntityProperties(entity.Property(informacoesPagamento => informacoesPagamento.PagamentoId));
                SetEntityProperties(entity.Property(informacoesPagamento => informacoesPagamento.CPF), 14);
                SetEntityProperties(entity.Property(informacoesPagamento => informacoesPagamento.SalarioLiquido));
                SetEntityProperties(entity.Property(informacoesPagamento => informacoesPagamento.DataPagamento));
                SetEntityProperties(entity.Property(informacoesPagamento => informacoesPagamento.NumeroConta), 10);
                SetEntityProperties(entity.Property(informacoesPagamento => informacoesPagamento.NumeroAgencia), 10);
            });

            modelBuilder.Entity<RegistrosHorasTrabalhadas>(entity =>
            {
                entity.HasKey(registrosHorasTrabalhadas => registrosHorasTrabalhadas.RegistroId);

                SetEntityProperties(entity.Property(registrosHorasTrabalhadas => registrosHorasTrabalhadas.RegistroId));
                SetEntityProperties(entity.Property(registrosHorasTrabalhadas => registrosHorasTrabalhadas.CPF), 14);
                SetEntityProperties(entity.Property(registrosHorasTrabalhadas => registrosHorasTrabalhadas.Data));
                SetEntityProperties(entity.Property(registrosHorasTrabalhadas => registrosHorasTrabalhadas.HorasTrabalhadas));
                SetEntityProperties(entity.Property(registrosHorasTrabalhadas => registrosHorasTrabalhadas.ValorHora));
            });

            modelBuilder.Entity<RelatorioPagamento>(entity =>
            {
                entity.HasKey(relatorio => relatorio.HoleriteId);

                SetEntityProperties(entity.Property(relatorios => relatorios.HoleriteId));
                SetEntityProperties(entity.Property(relatorios => relatorios.CPF), 14);
                SetEntityProperties(entity.Property(relatorios => relatorios.MesReferencia));
                SetEntityProperties(entity.Property(relatorios => relatorios.SalarioBruto));
                SetEntityProperties(entity.Property(relatorios => relatorios.Descontos));
                SetEntityProperties(entity.Property(relatorios => relatorios.SalarioLiquido));
                SetEntityProperties(entity.Property(relatorios => relatorios.HorasTrabalhadasMensal));
            });

            OnModelCreatingPartial(modelBuilder);
        }
    }
}