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

		public abstract void Update();
	}
}