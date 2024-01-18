namespace GerenciamentoDeCampanhas.Domain.Constantes
{
    public static class Parametros
    {
        public static class MongoDB
        {
            public static string ConnectionString = Environment.GetEnvironmentVariable("MongoDbConnection")!;
            public static string Database = "Campanhas-MongoDB";
        }

    }
}
