using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Interfaces
{
	public interface ICategoriaRepository
	{
		IEnumerable<Categoria> ObterTodas();
		Task<Categoria> ObterPorId(Guid id);
		Task Adicionar(Categoria categoria);
		Task Desativar(Categoria categoria);
		Task Ativar(Categoria categoria);
        void Atualizar(Categoria categoria);
	}
}
