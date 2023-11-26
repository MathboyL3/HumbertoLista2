using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Entities
{
	public class Fornecedor
	{
		#region Construtor

		public Fornecedor(string nome, string cnpj, string razaoSocial, DateTime dataCadastro, bool ativo)
		{
			Nome = nome;
			Cnpj = cnpj;
			RazaoSocial = razaoSocial;
			DataCadastro = dataCadastro;
			Ativo = ativo;
		}

		#endregion

		#region propriedades

		public string Nome { get; private set; }
		public string Cnpj { get; private set; }
		public string RazaoSocial { get; private set; }
		public DateTime DataCadastro { get; private set; }
		public bool Ativo { get; private set; }


		#endregion

		#region comportamentos

		public void Ativar() => Ativo = true;

		public void Desativar() => Ativo = false;

		public void AlterarNome(string nome) => Nome = nome;
		public void AlterarRazaoSocial(string razaoSocial) => RazaoSocial = razaoSocial;
		public void AlterarCNPJ(string cnpj) => Cnpj = cnpj;


		#endregion
	}
}
