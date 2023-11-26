using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.ViewModels
{
	public class NovoFornecedorViewModel
	{
		#region propriedades

		public string Nome { get; set; }
		public string Cnpj { get; set; }
		public string RazaoSocial { get; set; }
		public DateTime DataCadastro { get; set; }
		public bool Ativo { get; set; }
		#endregion
	}
}
