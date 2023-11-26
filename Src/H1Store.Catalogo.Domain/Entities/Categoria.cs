using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Entities
{
	public class Categoria : EntidadeBase
	{
		#region construtor
		public Categoria( string descricao, bool ativo)
		{
			Descricao = descricao;
			Ativo = ativo;
		}

		public Categoria(Guid codigoId, string descricao, bool ativo)
		{
			CodigoId = codigoId;
			Descricao = descricao;
			Ativo = ativo;
		}
		#endregion

		#region propriedades
		public string Descricao { get; private set; }
		public bool Ativo { get; private set; }
		#endregion

		#region comportamentos

		public void AlterarDescricao(string descricao) => Descricao = descricao;
		public void Ativar() => Ativo = true;

		public void Desativar() => Ativo = false;

		#endregion
	}
}
