namespace MongoMigrations.Stubs
{
    using MongoDB.Bson;

    public class Migration2 : Migration
    {
        public Migration2() : base("1.0.17")
        {
        }

        public override void Update()
        {
            var d = new BsonDocument(){
                { "a", 1 },
                { "b", new BsonArray
                    {
                        new BsonDocument("c", 1)
                    }}
            };

            this.Database.GetCollection<BsonDocument>("col2").InsertOne(d);
        }
    }
}