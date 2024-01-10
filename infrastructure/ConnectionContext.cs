using MongoDB.Driver;

namespace Synthesis.Connection
{
    public class ConnectionContext{

        public static IMongoDatabase ConnectionToMongo(){

        string? connectionURI = DotNetEnv.Env.GetString("MONGO_URI");
        var settings = MongoClientSettings.FromConnectionString(connectionURI);        
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        MongoClient client = new MongoClient(settings);
        IMongoDatabase database = client.GetDatabase("synthesis");
        return database;
        }
    }
}