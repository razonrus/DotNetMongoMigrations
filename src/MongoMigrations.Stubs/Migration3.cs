namespace MongoMigrations.Stubs
{
    using MongoDB.Bson;

    public class Migration3 : Migration
    {
        public Migration3() : base("1.0.18")
        {
        }

        public override void Update()
        {
            var q = BsonDocument.Parse("{prop1: '1.0.4'}");

            this.Database.GetCollection<BsonDocument>("col1").InsertOne(q);
        }
    }
}