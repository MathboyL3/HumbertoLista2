using AutoMapper;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.AutoMapper
{
	public class DomainToApplication : Profile
	{
		public DomainToApplication()
		{
			CreateMap<Produto, ProdutoViewModel>();
			CreateMap<Fornecedor, FornecedorViewModel>();
		}
	}
}
