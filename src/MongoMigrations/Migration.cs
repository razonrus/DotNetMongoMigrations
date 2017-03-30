using System;
using Microsoft.Extensions.Configuration;

namespace MongoMigrations
{
	using MongoDB.Driver;

	public abstract class Migration
	{
		protected Migration(MigrationVersion version)
		{
		    this.Version = version;
		}

		public MigrationVersion Version { get; protected set; }

        public string Description { get; protected set; }

		public IMongoDatabase Database { get; set; }

		protected IConfigurationRoot Configuration { get; private set; }

		public abstract void Update();

		internal void ApplyConfig(IConfigurationRoot configuration)
		{
			if(configuration == null) throw new ArgumentException("Can't apply a null configuration");

			Configuration = configuration;
		}
	}
}