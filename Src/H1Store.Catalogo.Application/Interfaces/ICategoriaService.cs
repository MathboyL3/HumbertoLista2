using H1Store.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface ICategoriaService
	{
		IEnumerable<CategoriaViewModel> ObterTodas();

        Task<CategoriaViewModel> ObterPorId(Guid id);

		Task Adicionar(NovaCategoriaViewModel categoriaViewModel);
		void Atualizar(Guid id, NovaCategoriaViewModel categoriaViewModel);
        Task Desativar(Guid id);
        Task Ativar(Guid id);
    }
}
