using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface IFornecedorService
	{
		public Task Adicionar(NovoFornecedorViewModel novoFornecedorViewModel);
		//public Task Atualizar(Fornecedor fornecedor);
		public Task Remover(FornecedorViewModel fornecedor);
		public Task<FornecedorViewModel> ObterPorId(int id);
		public Task<FornecedorViewModel> ObterPorCnpj(string cnpj);
		public Task<IEnumerable<FornecedorViewModel>> ObterTodos();
        Task<FornecedorViewModel> ObterPorNome(string nome);
        void Atualizar(NovoFornecedorViewModel model);
        Task Desativar(string cnpj);
        Task Ativar(string cnpj);
    }
}
