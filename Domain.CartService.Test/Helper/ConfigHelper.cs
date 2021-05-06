using RestMongo.Interfaces;
using RestMongo.Models;


public class ConfigHelper
{
    public static ConnectionSettings _config = new ConnectionSettings()
    {
        ConnectionString = "mongodb://localhost:27017",
        DatabaseName = "test"
    };

    public static IConnectionSettings GetMongoConfig()
    {
        return _config;
    }

}
