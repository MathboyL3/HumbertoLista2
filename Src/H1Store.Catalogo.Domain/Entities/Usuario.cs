using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Entities
{
	public class Usuario
	{


		#region construtor
		public Usuario(string login, string senha, bool ativo)
		{
			Login = login;
			Senha = senha;
			Ativo = ativo;
		}

		#endregion
		#region Propiedades
		public string Login { get; private set; }
		public string Senha { get; private set; }
		public bool Ativo { get; private set; }
		#endregion

		#region funções

		#endregion
	}
}
