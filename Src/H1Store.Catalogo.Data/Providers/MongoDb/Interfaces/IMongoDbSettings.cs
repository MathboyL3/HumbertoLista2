using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Providers.MongoDb.Interfaces
{ 
	public interface IMongoDbSettings
	{
		string DatabaseName { get; set; }
		string ConnectionString { get; set; }
	}
}
