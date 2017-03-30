using System;
using System.Linq;
using MongoDB.Driver;
using MongoMigrations.Tests.TestImplementations;
using Moq;
using Xunit;

namespace MongoMigrations.Tests
{
	public class MigrationRunnerTests
	{
		private readonly IMongoDatabase _database;

		public MigrationRunnerTests()
		{
			var dbMock = new Mock<IMongoDatabase>();
			dbMock.Setup(db => db.Client).Returns(new MongoClient(Guid.NewGuid().ToString()));
			_database = dbMock.Object;
		}

		[Fact]
		public void UpdateToLatest_sets_Configuration_on_supplied_Migration_where_Configuration_exists()
		{
			// arrange
			var configuration = new TestConfigurationRoot();
			var runner = new MigrationRunner("mongodb://localhost:27017", "test-db", configuration);
			runner.MigrationLocator.LookForMigrationsInAssemblyOfType<TestMigration>();
			var migration = new TestMigration();

			// act
			runner.UpdateToLatest();

			// assert
			Assert.True(runner.MigrationLocator.AllMigrations.All(m => ((TestMigration)m).HasConfig));
		}
	}
}