using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Services
{
	public class CategoriaService : ICategoriaService
	{
		#region - Construtores
		private readonly ICategoriaRepository _categoriaRepository;
		private IMapper _mapper;

		public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
		{
			_categoriaRepository = categoriaRepository;
			_mapper = mapper;
		}
		#endregion



		public async Task Adicionar(NovaCategoriaViewModel categoriaViewModel)
		{
			var novaCategoria = _mapper.Map<Categoria>(categoriaViewModel);

			//Categoria categoria = new Categoria(categoriaViewModel.Descricao, categoriaViewModel.Ativo );

			await _categoriaRepository.Adicionar(novaCategoria);
		}

        public async Task Ativar(Guid id)
        {
            var novaCategoria = _mapper.Map<Categoria>(await _categoriaRepository.ObterPorId(id));
			novaCategoria.Ativar();
            _categoriaRepository.Atualizar(novaCategoria);
        }

        public void Atualizar(Guid id, NovaCategoriaViewModel categoriaViewModel)
		{
            var novaCategoria = _mapper.Map<Categoria>(categoriaViewModel);
            novaCategoria.CodigoId = id;
            _categoriaRepository.Atualizar(novaCategoria);

        }

        public async Task Desativar(Guid id)
        {
            var novaCategoria = _mapper.Map<Categoria>(await _categoriaRepository.ObterPorId(id));
            novaCategoria.Desativar();
            _categoriaRepository.Atualizar(novaCategoria);
        }

        public async Task<CategoriaViewModel> ObterPorId(Guid id)
		{
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id)); 
        }

        public IEnumerable<CategoriaViewModel> ObterTodas()
		{
			return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodas());

		}
	}
}
