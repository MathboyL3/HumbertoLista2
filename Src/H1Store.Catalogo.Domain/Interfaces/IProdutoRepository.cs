using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Interfaces
{
	public interface IProdutoRepository
	{
		IEnumerable<Produto> ObterTodos();
		Task<Produto> ObterPorId(Guid id);
		Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
        Task<Produto> ObterPorNome(string nome);
        Task Adicionar(Produto produto);
		Task Desativar(Produto produto);
		Task Ativar(Produto produto);
        void Atualizar(Produto produto);
        Task AlterarPreco(Produto produto, decimal newPreco);
        Task AtualizarEstoque(Produto produto);
    }
}
