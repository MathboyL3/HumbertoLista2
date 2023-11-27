using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface IProdutoService
	{
		
		IEnumerable<ProdutoViewModel> ObterTodos();
		Task<ProdutoViewModel> ObterPorId(Guid id);
		Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(Guid codigo);
        Task<ProdutoViewModel> ObterPorNome(string nome);
        Task Adicionar(NovoProdutoViewModel produto);
		void Atualizar(Guid id, NovoProdutoViewModel produto);
		Task Desativar(Guid id);
		Task Ativar(Guid id);

        Task AlterarPreco(Guid id, decimal newPreco);
        Task AtualizarEstoque(Guid id, int quantidade);

    }
}
