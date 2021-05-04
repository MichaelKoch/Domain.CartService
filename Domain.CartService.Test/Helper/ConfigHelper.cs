using RestMongo.Interfaces;
using RestMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ConfigHelper
    {
        public static ConnectionSettings _config = new ConnectionSettings()
        {
            ConnectionString = "mongodb://localhost:27017",
            DatabaseName     = "test"
        };

        public static IConnectionSettings GetMongoConfig()
        {
            return _config;
        }

    }
