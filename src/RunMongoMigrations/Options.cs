namespace RunMongoMigrations
{
    using CommandLine;

    public class Options
    {
        [Option('h', "host", Required = false, Default = "localhost", HelpText = "Mongodb Server Ip Address")]
        public string Host { get; set; }

        [Option('p', "port", Required = false, Default = 27017, HelpText = "Mongodb Server Port")]
        public int Port { get; set; }

        [Option('d', "database", Required = true,  HelpText = "Database Name")]
        public string Database { get; set; }

        [Option('m', "migrations", Required = true, HelpText = "Migrations Assembly File")]
        public string Migrations { get; set; } 
    }
}