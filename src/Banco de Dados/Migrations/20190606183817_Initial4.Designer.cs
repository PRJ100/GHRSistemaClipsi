﻿// <auto-generated />
using System;
using Banco_de_Dados.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banco_de_Dados.Migrations
{
    [DbContext(typeof(DbContexto))]
    [Migration("20190606183817_Initial4")]
    partial class Initial4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Banco_de_Dados.Classes.Agendamento", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("convenio")
                        .HasMaxLength(50);

                    b.Property<string>("data")
                        .HasMaxLength(10);

                    b.Property<string>("horario")
                        .HasMaxLength(7);

                    b.Property<int?>("medico");

                    b.Property<string>("paciente")
                        .HasMaxLength(10);

                    b.Property<string>("tipo")
                        .HasMaxLength(50);

                    b.HasKey("codigo");

                    b.ToTable("agendamentos");
                });

            modelBuilder.Entity("Banco_de_Dados.Classes.Cliente", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ativo")
                        .HasMaxLength(50);

                    b.Property<string>("bairro")
                        .HasMaxLength(100);

                    b.Property<string>("cep")
                        .HasMaxLength(50);

                    b.Property<string>("cidade")
                        .HasMaxLength(100);

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<string>("email")
                        .HasMaxLength(100);

                    b.Property<string>("endereco")
                        .HasMaxLength(100);

                    b.Property<string>("estado")
                        .HasMaxLength(50);

                    b.Property<string>("nascimento")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("numero")
                        .HasMaxLength(50);

                    b.Property<string>("rg")
                        .HasMaxLength(16);

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("telefone")
                        .HasMaxLength(20);

                    b.HasKey("codigo");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Banco_de_Dados.Classes.Lancamento", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("data")
                        .HasMaxLength(10);

                    b.Property<string>("descricao")
                        .HasMaxLength(200);

                    b.Property<string>("forma_pagamento")
                        .HasMaxLength(18);

                    b.Property<int>("mes");

                    b.Property<string>("tipo")
                        .HasMaxLength(10);

                    b.Property<decimal>("valor");

                    b.HasKey("codigo");

                    b.ToTable("lancamentos");
                });

            modelBuilder.Entity("Banco_de_Dados.Classes.Medicamento", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao")
                        .HasMaxLength(200);

                    b.Property<string>("nomeMedicamento")
                        .HasMaxLength(100);

                    b.Property<int>("numeroRegistroMinisterio");

                    b.Property<string>("unidadeMedida")
                        .HasMaxLength(10);

                    b.HasKey("codigo");

                    b.ToTable("medicamentos");
                });

            modelBuilder.Entity("Banco_de_Dados.Classes.Medico", b =>
                {
                    b.Property<int>("crm");

                    b.Property<string>("especialidade")
                        .HasMaxLength(100);

                    b.Property<string>("nome")
                        .HasMaxLength(100);

                    b.Property<string>("telefone")
                        .HasMaxLength(20);

                    b.HasKey("crm");

                    b.ToTable("medico");
                });

            modelBuilder.Entity("Banco_de_Dados.Classes.Plano", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cnpj")
                        .HasMaxLength(50);

                    b.Property<string>("nome")
                        .HasMaxLength(100);

                    b.Property<string>("razao_social")
                        .HasMaxLength(100);

                    b.Property<string>("registro_ans")
                        .HasMaxLength(50);

                    b.HasKey("codigo");

                    b.ToTable("planos");
                });

            modelBuilder.Entity("Banco_de_Dados.Classes.Usuario", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("nivel_acesso");

                    b.Property<string>("senha")
                        .HasMaxLength(40);

                    b.Property<string>("usuario1")
                        .HasColumnName("usuario")
                        .HasMaxLength(50);

                    b.HasKey("codigo");

                    b.ToTable("usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
