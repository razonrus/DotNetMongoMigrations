namespace MongoMigrations.Tests.TestImplementations
{
	public class TestMigration : Migration
	{
		public TestMigration() : base("1.0.0")
		{
		}

		public override void Update()
		{
			throw new System.NotImplementedException();
		}

		public bool HasConfig => Configuration != null;
	}
}