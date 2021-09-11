﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteClasses.Models;

namespace TesteClasses.Migrations
{
    [DbContext(typeof(TesteClassesContext))]
    partial class TesteClassesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteClasses.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformacoesAdicionais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PessoaJuridica")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendedorResponsavel")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.HasIndex("VendedorResponsavel");

                    b.ToTable("ClienteModel");
                });

            modelBuilder.Entity("TesteClasses.Models.CondicaoPagamentoModel", b =>
                {
                    b.Property<int>("IdCp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<int>("QtdePadraoDias")
                        .HasColumnType("int");

                    b.Property<int>("QtdePadraoParcelas")
                        .HasColumnType("int");

                    b.HasKey("IdCp");

                    b.ToTable("CondicaoPagamentoModel");
                });

            modelBuilder.Entity("TesteClasses.Models.InteracoesModel", b =>
                {
                    b.Property<int>("IdInteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ClienteRespondeu")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("MeioContato")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInteracao");

                    b.HasIndex("IdCliente");

                    b.ToTable("InteracoesModel");
                });

            modelBuilder.Entity("TesteClasses.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Servico")
                        .HasColumnType("bit");

                    b.Property<string>("UnidadeMedida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProduto");

                    b.ToTable("ProdutoModel");
                });

            modelBuilder.Entity("TesteClasses.Models.PropostaItemModel", b =>
                {
                    b.Property<int>("IdPropostaItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("IdProposta")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPropostaItem");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdProposta");

                    b.ToTable("PropostaItemModel");
                });

            modelBuilder.Entity("TesteClasses.Models.PropostaModel", b =>
                {
                    b.Property<int>("IdProposta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssinaturaProposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdCp")
                        .HasColumnType("int");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdeDiasPrimeiraParcela")
                        .HasColumnType("int");

                    b.Property<int>("QtdeParcelas")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdProposta");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdCp");

                    b.ToTable("PropostaModel");
                });

            modelBuilder.Entity("TesteClasses.Models.UsuarioModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vendedor")
                        .HasColumnType("bit");

                    b.HasKey("IdUsuario");

                    b.ToTable("UsuarioModel");
                });

            modelBuilder.Entity("TesteClasses.Models.ClienteModel", b =>
                {
                    b.HasOne("TesteClasses.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("VendedorResponsavel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TesteClasses.Models.InteracoesModel", b =>
                {
                    b.HasOne("TesteClasses.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TesteClasses.Models.PropostaItemModel", b =>
                {
                    b.HasOne("TesteClasses.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClasses.Models.PropostaModel", "Proposta")
                        .WithMany()
                        .HasForeignKey("IdProposta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Proposta");
                });

            modelBuilder.Entity("TesteClasses.Models.PropostaModel", b =>
                {
                    b.HasOne("TesteClasses.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClasses.Models.CondicaoPagamentoModel", "CondicaoPagamento")
                        .WithMany()
                        .HasForeignKey("IdCp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("CondicaoPagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
