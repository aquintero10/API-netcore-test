
namespace API_ivolucion.Contracts
{

    public static class ApiRoutes
    {
        public const string main = "api/";

        public const string version = "v1/";

        public const string Base = main+version;

        public static class Test
        {
            public const string Get = Base + "GetCurrentTime";
            public const string Post = Base + "NumberDivision";
        }
    }
}
