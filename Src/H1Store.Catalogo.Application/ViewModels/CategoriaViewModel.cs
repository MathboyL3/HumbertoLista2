using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.ViewModels
{
	public class CategoriaViewModel
	{
		public Guid CodigoId { get; set; }
		public string Descricao { get;  set; }
		public bool Ativo { get;  set; }
	}
}
