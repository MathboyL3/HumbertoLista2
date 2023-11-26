using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.AutoMapper
{
	public class DomainToCollection : Profile
	{
		public DomainToCollection()
		{
			CreateMap<Produto, ProdutoCollection>();
			CreateMap<Categoria, CategoriaCollection>();
			CreateMap<Fornecedor, FornecedorCollection>();
			CreateMap<Usuario, UsuarioCollection>();
		}
	}
}