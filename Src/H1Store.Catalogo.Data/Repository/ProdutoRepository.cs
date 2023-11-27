using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly IMongoRepository<ProdutoCollection> _produtoRepository;
		private readonly IMapper _mapper;

		#region - Construtores
		public ProdutoRepository(IMongoRepository<ProdutoCollection> produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}
		#endregion
		#region - Funções
		public async Task Adicionar(Produto produto)
		{		
			await _produtoRepository.InsertOneAsync(_mapper.Map<ProdutoCollection>(produto));
		}

		public async void Atualizar(Produto produto)
		{
            var buscaProduto = await _produtoRepository.FindOneAsync(filter => filter.CodigoId == produto.CodigoId);
            var prod = _mapper.Map<ProdutoCollection>(produto);
            prod.Id = buscaProduto.Id;
            await _produtoRepository.ReplaceOneAsync(prod);
        }

		public async Task<IEnumerable<Produto>> ObterPorCategoria(Guid codigo)
		{
            var produtoList = _produtoRepository.FilterBy(filter => filter.CategoriaId.Equals(codigo));

            return _mapper.Map<IEnumerable<Produto>>(produtoList);
        }

		public async Task<Produto> ObterPorId(Guid id)
		{

			var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == id);

			var produto = _mapper.Map<Produto>(buscaProduto.FirstOrDefault());
			
			return produto;
		}

		public IEnumerable<Produto> ObterTodos()
		{
			var produtoList = _produtoRepository.FilterBy(filter => true);

			return _mapper.Map<IEnumerable<Produto>>(produtoList);

		}

        public async Task<Produto> ObterPorNome(string nome)
        {
			var buscaProduto = await _produtoRepository.FindOneAsync(filter => filter.Nome.Equals(nome));

            var produto = _mapper.Map<Produto>(buscaProduto);

            return produto;
        }

        #endregion

    }
}
