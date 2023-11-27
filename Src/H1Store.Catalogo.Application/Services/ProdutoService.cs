using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using H1Store.Catalogo.Infra.EmailService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
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
        private EmailMasterReport _email_to_report;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IOptions<EmailConfig> emailConfig, IOptions<EmailMasterReport> email_to_report)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
			_emailConfig = emailConfig.Value;
            _email_to_report = email_to_report.Value;
        }
		#endregion

		#region - Funções
		public async Task Adicionar(NovoProdutoViewModel novoProdutoViewModel)
		{
			var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);
			await _produtoRepository.Adicionar(novoProduto);
		}

        public async Task AlterarPreco(Guid id, decimal newPreco)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null) throw new ArgumentNullException("Produto não existente!");
            if (newPreco <= 0) throw new ArgumentNullException("O preço não não pode ser <= 0");

            produto.AlterarValor(newPreco);

            _produtoRepository.Atualizar(produto);
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
				string corpo = $@"Olá Comprador(a), o produto ""{buscaProduto.Descricao}"" está abaixo do estoque mínimo ({buscaProduto.QuantidadeEstoqueMinimo}), novo pedido de compra.";
                Email.Enviar("Estoque abaixo do mínimo", corpo, _email_to_report.EmailToReport, _emailConfig);
			}
			
            _produtoRepository.Atualizar(buscaProduto);
        }

        public void Atualizar(Guid id, NovoProdutoViewModel produto)
		{
			var _produto = _mapper.Map<Produto>(produto);
            _produto.CodigoId = id;
            _produtoRepository.Atualizar(_produto);

        }

        public async Task Desativar(Guid id)
		{
			var buscaProduto = await _produtoRepository.ObterPorId(id);
			buscaProduto.Desativar();
			_produtoRepository.Atualizar(buscaProduto);
		}

		public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(Guid codigo)
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

        public async Task Ativar(Guid id)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);
            buscaProduto.Ativar();
            _produtoRepository.Atualizar(buscaProduto);
        }
        #endregion
    }
}
