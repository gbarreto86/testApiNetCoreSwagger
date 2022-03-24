using ExigoWebService;

namespace System.Persitence.Service.Exigo
{
    public interface IConnectionExigo
    {
        static string WebServiceUrl { get; }

        static ApiAuthentication ApiAuthentication { get; }
    }
}
