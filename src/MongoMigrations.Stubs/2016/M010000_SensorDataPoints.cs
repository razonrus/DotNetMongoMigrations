namespace MongoMigrations.Stubs
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;

    public class M010000SensorDataPoints : Migration
    {
        public M010000SensorDataPoints() : base("1.0.24")
        {
        }

        public override void Update()
        {
            var jsonData = this.GetData();

            var bsonArray = BsonSerializer.Deserialize<BsonArray>(jsonData);

            this.Database.GetCollection<BsonValue>("sensorDataPoints").InsertMany(bsonArray.ToList());
        }

        public string GetData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName()
                .Name;
            var resourceName = $"{assemblyName}._2016.M010000_data.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}