using Knila_Service.InfraStructure.Implementation;
using Knila_Service.InfraStructure.Interface;
using Knila_Service.Model;
using Microsoft.EntityFrameworkCore;

namespace Knila_Service.InfraStructure
{
    public static class DependencyInjectionInfra
    {
        public static IServiceCollection AddContext(this IServiceCollection service)
        {
            service.AddDbContext<MyTestDBContext>(x => x.UseSqlServer("Server=L-ID-052;Database=MyTestDB;Trusted_Connection=True;encrypt=false;"));

            service.AddScoped<IBook, BookImplementation>();
            return service;
        }

        public class Result<T>
        {
            public T Data { get; set; }
            public string Message { get; set; }
            public int StatusCode { get; set; }

            public Result()
            {
                Message = "Success";
                StatusCode = 200;
            }
        }
    }
}
