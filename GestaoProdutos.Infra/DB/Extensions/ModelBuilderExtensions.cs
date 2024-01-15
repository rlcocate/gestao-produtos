using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace GestaoProdutos.Infra.DB.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedSuppliers(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Fornecedor>().HasData(
            //    new Fornecedor
            //    {
            //        Descricao = "Valeo",
            //        Cnpj = "60688530000104"
            //    },
            //    new Fornecedor
            //    {
            //        Descricao = "Dts",
            //        Cnpj = "86442724000100"
            //    },
            //    new Fornecedor
            //    {
            //        Descricao = "Arteb",
            //        Cnpj = "22928999000176"
            //    },
            //    new Fornecedor
            //    {
            //        Descricao = "Viemar",
            //        Cnpj = "03146621000176"
            //    });
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Produto>().HasData(
            //    new Produto
            //    {
            //        Descricao = "Terminal Axial Chevrolet Corsa Classic 2002 a 2021 Dianteiro Esquerdo Motorista Viemar - 2064819",
            //        Situacao = (char)SituacaoProdutoEnum.Ativo,
            //        DataFabricacao = new DateTime(2020, 01, 01),
            //        DataValidade = new DateTime(2021, 12, 31),
            //        FornecedorId = 1
            //    },
            //    new Produto
            //    {
            //        Descricao = "Parachoque Fiat Uno Novo Dianteiro 2017 a 2022 Preto Liso Com Furos Dts - 1803409",
            //        Situacao = (char)SituacaoProdutoEnum.Ativo,
            //        DataFabricacao = new DateTime(2017, 01, 01),
            //        DataValidade = new DateTime(2022, 12, 31),
            //        FornecedorId = 1
            //    },
            //    new Produto
            //    {
            //        Descricao = "Farol Principal Chevrolet Celta Direito Passageiro 2007 a 2015 Máscara Negra Manual Arteb - 1393879",
            //        Situacao = (char)SituacaoProdutoEnum.Ativo,
            //        DataFabricacao = new DateTime(2007, 01, 01),
            //        DataValidade = new DateTime(2015, 12, 31),
            //        FornecedorId = 1
            //    },
            //    new Produto
            //    {
            //        Descricao = "Farol Principal Citroen C3 Novo Direito Passageiro 2013 a 2021 Cromado Manual Valeo - 631619",
            //        Situacao = (char)SituacaoProdutoEnum.Ativo,
            //        DataFabricacao = new DateTime(2013, 01, 11),
            //        DataValidade = new DateTime(2021, 12, 31),
            //        FornecedorId = 1
            //    });
        }
    }
}
