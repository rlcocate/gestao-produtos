using AutoMapper;
using GestaoProdutos.Application.Mappers;
using GestaoProdutos.Application.Queries.ObterProdutoPorId;
using GestaoProdutos.Application.Queries.ObterProdutos;
using GestaoProdutos.Core.DTO;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Enums;
using GestaoProdutos.Core.Repositories;
using GestaoProdutos.Core.Repositories.UoW;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GestaoProdutos.Tests.Queries
{
    public class ProdutosQueryTests
    {
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;

        public ProdutosQueryTests()
        {
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _mockUnitOfWork
                .SetupGet(uow => uow.Produtos)
                .Returns(_mockProdutoRepository.Object);

            if (_mapper is null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ProdutoMapper());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task DeveriaRetornarUmaListaDeTodosProdutosAtivos()
        {
            List<Produto> produtos = new()
            {
                new Produto() {
                    Descricao = "Buzina",
                    Situacao = (char)SituacaoProdutoEnum.Ativo,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddYears(5),
                    FornecedorId = 2,
                    Fornecedor = new Fornecedor() {
                        Descricao = "Dts",
                        Cnpj = "86442724000100" }
                },
                new Produto() {
                    Descricao = "Limpador de Pára-Brisas",
                    Situacao = (char)SituacaoProdutoEnum.Inativo,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddYears(2),
                    FornecedorId = 4,
                    Fornecedor = new Fornecedor() {
                        Descricao = "Viemar",
                        Cnpj = "03146621000176" }
                },
                new Produto() {
                    Descricao = "Farol de Neblina",
                    Situacao = (char)SituacaoProdutoEnum.Ativo,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddYears(4),
                    FornecedorId = 1,
                    Fornecedor = new Fornecedor() {
                        Descricao = "Valeo",
                        Cnpj = "60688530000104" }
                },
            };

            List<Produto> produtosAtivos = produtos.Where(p => p.Situacao.Equals((char)SituacaoProdutoEnum.Ativo)).ToList();

            _mockProdutoRepository.Setup(p => p.GetAllAsync(25, 1)).ReturnsAsync(produtosAtivos);

            var query = new ObterProdutosQuery(25, 1);
            var queryHandler = new ObterProdutosQueryHandler(_mockUnitOfWork.Object, _mapper);
            var result = await queryHandler.Handle(query, new CancellationToken());

            Assert.NotEmpty(result);
            Assert.True(result.Count.Equals(produtosAtivos.Count));
        }

        //[Fact]
        public async Task DeveriaRetornarUmProdutoAtivoPorId()
        {
            var produto = new Produto()
            {
                Descricao = "Buzina",
                Situacao = (char)SituacaoProdutoEnum.Ativo,
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddYears(5),
                FornecedorId = 2,
                Fornecedor = new Fornecedor()
                {
                    Descricao = "Dts",
                    Cnpj = "86442724000100"
                }
            };

            int id = 1;
            _mockProdutoRepository.Setup(p => p.GetByCondition(w => w.Id.Equals(id) && w.Situacao.Equals((char)SituacaoProdutoEnum.Ativo))).ReturnsAsync(produto);

            var query = new ObterProdutoPorIdQuery(id);
            var handler = new ObterProdutoPorIdHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(query, new CancellationToken());

            //TODO: Implementar
            Assert.True(true);

            //Assert.NotNull(result);
            //Assert.Single(result);
        }
    }
}
