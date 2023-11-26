using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface IUsuarioService
	{
		public Task<string> Autenticar(AutenticarUsuarioViewModel autenticarUsuarioViewModel);
		public Task Cadastrar(UsuarioViewModel usuario);
	}
}
