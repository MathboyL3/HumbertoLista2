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
	public class FornecedorService : IFornecedorService
	{
		private readonly IFornecedorRepository _fornecedorRepository;
		private readonly IMapper _Mapper;

		public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
		{
			_fornecedorRepository = fornecedorRepository;
			_Mapper = mapper;
		}

		public async Task Adicionar(NovoFornecedorViewModel novoFornecedorViewModel)
		{

			//regra de negocio verificar aqui se existe cpnj ja cadastrado
			//senao existir chama o repositoo
			//se existir da erro que ja existe fornecedor cadastrado
			Fornecedor fornecedor = await _fornecedorRepository.ObterPorCnpj(novoFornecedorViewModel.Cnpj);
			
			if (fornecedor != null)
			{
				throw new
					ApplicationException(
					"Cnpj já existe cadastrado em nossa base de dados, operação não pode ser realizada");
			}
			Fornecedor novoFornecedor = _Mapper.Map<Fornecedor>(novoFornecedorViewModel);
            await _fornecedorRepository.Adicionar(novoFornecedor);
        }

        public async Task Ativar(string cnpj)
        {
            var novoFornecedor = _Mapper.Map<Fornecedor>(await _fornecedorRepository.ObterPorCnpj(cnpj));
			novoFornecedor.Ativar();
            await _fornecedorRepository.Atualizar(novoFornecedor);

        }


        public void Atualizar(string cnpj, NovoFornecedorViewModel fornecedor)
        {
            var novoFornecedor = _Mapper.Map<Fornecedor>(fornecedor);
            _fornecedorRepository.Atualizar(novoFornecedor);
        }

        public async Task Desativar(string cnpj)
        {
            var novoFornecedor = _Mapper.Map<Fornecedor>(await _fornecedorRepository.ObterPorCnpj(cnpj));
			novoFornecedor.Desativar();
            await _fornecedorRepository.Atualizar(novoFornecedor);
        }

        public async Task<FornecedorViewModel> ObterPorCnpj(string cnpj)
		{
			return _Mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterPorCnpj(cnpj));
		}

		public async Task<FornecedorViewModel> ObterPorId(Guid id)
		{
            return _Mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterPorId(id));
        }

        public async Task<FornecedorViewModel> ObterPorNome(string nome)
        {
            return _Mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterPorNome(nome));
        }

        public async  Task<IEnumerable<FornecedorViewModel>> ObterTodos()
		{
			var listaFornecedores = await _fornecedorRepository.ObterTodos();
			return _Mapper.Map<IEnumerable<FornecedorViewModel>>(listaFornecedores);
		  //return _Mapper.Map<IEnumerable<FornecedorViewModel>>
		  //(await _fornecedorRepository.ObterTodos());

		}

		public async Task Remover(FornecedorViewModel fornecedor)
		{
            var _fornecerdor = _Mapper.Map<Fornecedor>(fornecedor);
            await _fornecedorRepository.Remover(_fornecerdor);
        }
	}
}
