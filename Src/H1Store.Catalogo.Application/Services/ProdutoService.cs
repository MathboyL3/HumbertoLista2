using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using H1Store.Catalogo.Infra.EmailService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Services
{
    public class ProdutoService : IProdutoService
    {
		#region - Construtores
		private readonly IProdutoRepository _produtoRepository;
		private IMapper _mapper;
		private EmailConfig _emailConfig;

		public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IOptions<EmailConfig> emailConfig)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
			_emailConfig = emailConfig.Value;

        }
		#endregion

		#region - Funções
		public async Task Adicionar(NovoProdutoViewModel novoProdutoViewModel)
		{
			var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);

			Produto p = new Produto(novoProdutoViewModel.Descricao, novoProdutoViewModel.Descricao, novoProdutoViewModel.Ativo, novoProdutoViewModel.Valor, novoProdutoViewModel.DataCadastro, novoProdutoViewModel.Imagem, novoProdutoViewModel.QuantidadeEstoque);

			await _produtoRepository.Adicionar(novoProduto);

		}

        public async Task AlterarPreco(Guid id, decimal newPreco)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null) throw new ArgumentNullException("Produto não existente!");
            if (newPreco <= 0) throw new ArgumentNullException("O preço não não pode ser <= 0");

            await _produtoRepository.AlterarPreco(produto, newPreco);
        }
        public async Task AtualizarEstoque(Guid id, int quantidade)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);
            if (quantidade > 0)
                buscaProduto.ReporEstoque(quantidade);
            else
                buscaProduto.DebitarEstoque(quantidade * -1);

			if (buscaProduto.AlertaEstoque())
			{
				string corpo = $"Olá Comprador(a), o produto {buscaProduto.Descricao} está abaixo do estoque mínimo {buscaProduto.QuantidadeEstoqueMinimo} novo pedido de compra.";
                Email.Enviar("Estoque abaixo do mínimo", corpo, _emailConfig.Usuario, _emailConfig);
			}
			
            await _produtoRepository.AtualizarEstoque(buscaProduto);

        }

        public void Atualizar(ProdutoViewModel produto)
		{
			var _produto = _mapper.Map<Produto>(produto);
			_produtoRepository.Atualizar(_produto);

        }

        public async Task Desativar(Guid id)
		{
			var buscaProduto = await _produtoRepository.ObterPorId(id);

			if(buscaProduto == null)  throw new ApplicationException("Não é possível desativar um produto que não existe!");
			
			buscaProduto.Desativar();

			await _produtoRepository.Desativar(buscaProduto);

		}

		public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
		{
			return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorCategoria(codigo));
		}

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
		{
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoViewModel> ObterPorNome(string nome)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorNome(nome));
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
		{
			return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
		}

        public async Task Desativar(ProdutoViewModel produto)
        {
            Produto novoProduto = _mapper.Map<Produto>(produto);
            await _produtoRepository.Ativar(novoProduto);
        }

        public async Task Ativar(ProdutoViewModel produto)
        {
            Produto novoProduto = _mapper.Map<Produto>(produto);
            await _produtoRepository.Ativar(novoProduto);
        }
        #endregion
    }
}
