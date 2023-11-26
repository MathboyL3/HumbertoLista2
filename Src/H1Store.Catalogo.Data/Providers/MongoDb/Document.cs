using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Providers.MongoDb
{
	public abstract class Document  : IDocument
	{ 
		
		public ObjectId Id { get; set; }

		public DateTime CreatedAt => Id.CreationTime;
	}
}
