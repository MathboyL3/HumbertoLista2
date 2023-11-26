using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Providers.MongoDb.Configuration
{
	public class MongoDbSettings : IMongoDbSettings
	{
		public string DatabaseName { get; set; }
		public string ConnectionString { get; set; }
	}
}
