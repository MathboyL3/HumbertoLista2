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
	public class ApplicationToDomain : Profile
	{
		public ApplicationToDomain()
		{

			CreateMap<ProdutoViewModel, Produto>()
			   .ConstructUsing(q => new Produto(q.Nome,q.Descricao,q.Ativo,q.Valor,q.DataCadastro,q.Imagem,q.QuantidadeEstoque));

			CreateMap<NovoProdutoViewModel, Produto>()
			   .ConstructUsing(q => new Produto(q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque));

			CreateMap<FornecedorViewModel, Fornecedor>()
				.ConstructUsing(f => new Fornecedor(f.Nome, f.Cnpj, f.RazaoSocial, f.DataCadastro, f.Ativo));

			CreateMap<NovoFornecedorViewModel, Fornecedor>()
				.ConstructUsing(f => new Fornecedor(f.Nome,f.Cnpj, f.RazaoSocial, DateTime.Now, true));


			

		}
	}
}
