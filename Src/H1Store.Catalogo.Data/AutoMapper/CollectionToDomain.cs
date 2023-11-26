using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.AutoMapper
{
	public class CollectionToDomain : Profile
	{
		public CollectionToDomain()
		{

			CreateMap<ProdutoCollection, Produto>()
			   .ConstructUsing(q => new Produto(q.CodigoId, q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque));

			CreateMap<CategoriaCollection, Categoria>()
			   .ConstructUsing(q => new Categoria(q.CodigoId, q.Descricao, q.Ativo));

			CreateMap<FornecedorCollection, Fornecedor>()
					.ConstructUsing(f => new Fornecedor(f.Nome, f.Cnpj, f.RazaoSocial, f.DataCadastro, f.Ativo));

			CreateMap<UsuarioCollection, Usuario>()
				.ConstructUsing(u => new Usuario(u.Login, u.Senha, u.Ativo));
		}
	}
}
