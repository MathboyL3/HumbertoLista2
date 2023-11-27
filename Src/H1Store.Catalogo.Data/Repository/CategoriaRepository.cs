using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
	public class CategoriaRepository : ICategoriaRepository
	{
		private readonly IMongoRepository<CategoriaCollection> _categoriaRepository;
		private readonly IMapper _mapper;

		#region - Construtores
		public CategoriaRepository(IMongoRepository<CategoriaCollection> categoriaRepository, IMapper mapper)
		{
			_categoriaRepository = categoriaRepository;
			_mapper = mapper;
		}
		#endregion

		public async Task Adicionar(Categoria categoria)
		{
			await _categoriaRepository.InsertOneAsync(_mapper.Map<CategoriaCollection>(categoria));
		}

        public async void Atualizar(Categoria categoria)
		{
            var buscaCategoria = await _categoriaRepository.FindOneAsync(filter => filter.CodigoId == categoria.CodigoId);
            var cat = _mapper.Map<CategoriaCollection>(categoria);
            cat.Id = buscaCategoria.Id;
            await _categoriaRepository.ReplaceOneAsync(cat);
        }

		public async Task<Categoria> ObterPorId(Guid id)
		{
			var buscaCategoria = _categoriaRepository.FilterBy(filter => filter.CodigoId == id);

			return _mapper.Map<Categoria>(buscaCategoria.FirstOrDefault());

		}

        public  IEnumerable<Categoria> ObterTodas()
		{
			var categoriaList = _categoriaRepository.FilterBy(filter => true);

			return _mapper.Map<IEnumerable<Categoria>>(categoriaList);
		}
	}
}
