using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
	public class FornecedorRepository : IFornecedorRepository
	{

		private readonly IMongoRepository<FornecedorCollection> _fornecedorRepository;
		private readonly IMapper _mapper;

		public FornecedorRepository(IMongoRepository<FornecedorCollection> fornecedorRepository,
			IMapper mapper
			)
		{
			_fornecedorRepository = fornecedorRepository;
			_mapper = mapper;
		}

		public async Task Adicionar(Fornecedor fornecedor)
		{
			var novoFornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);
			await _fornecedorRepository.InsertOneAsync(novoFornecedorCollection);
		}

        public async Task Atualizar(Fornecedor fornecedor)
		{
            var buscaFornecedor = await _fornecedorRepository.FindOneAsync(filter => filter.Cnpj.Equals(fornecedor.Cnpj));
            var _fornecedor = _mapper.Map<FornecedorCollection>(fornecedor);
            _fornecedor.Id = buscaFornecedor.Id;
            await _fornecedorRepository.ReplaceOneAsync(_fornecedor);
        }

        public async Task<Fornecedor> ObterPorCnpj(string cnpj)
		{
			//var resultadoBuscaCnpj =  _fornecedorRepository.FilterBy(filtro => filtro.Cnpj == cnpj)
			//	.FirstOrDefault();
			//return _mapper.Map<Fornecedor>(resultadoBuscaCnpj);

			var resultadoBuscaCnpj2 = await _fornecedorRepository.FindOneAsync(filtro => filtro.Cnpj.Equals(cnpj));
			return _mapper.Map<Fornecedor>(resultadoBuscaCnpj2);

		}

		public async Task<Fornecedor> ObterPorId(Guid id)
		{
            throw new NotImplementedException();
        }

        public async Task<Fornecedor> ObterPorNome(string nome)
        {
            var resultadoBuscaCnpj2 = await _fornecedorRepository.FindOneAsync(filtro => filtro.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<Fornecedor>(resultadoBuscaCnpj2);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
		{
			var listaDeFornecedores = _fornecedorRepository.FilterBy(filtro => true);
			
			return _mapper.Map<IEnumerable<Fornecedor>>(listaDeFornecedores);

		}

		public async Task Remover(Fornecedor fornecedor)
		{
            await _fornecedorRepository.DeleteOneAsync(filtro => filtro.Cnpj.Equals(fornecedor.Cnpj));
        }
	}
}
