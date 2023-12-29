using Knila_Service.Domain.Request;
using Knila_Service.Model;
using static Knila_Service.InfraStructure.DependencyInjectionInfra;

namespace Knila_Service.InfraStructure.Interface
{
    public interface IBook
    {
        Task<Result<bool>> AddBookDetails(AddBookDetailsRequest request, CancellationToken cancellationToken);
        Task<Result<List<Book>>> GetBookDetails(CancellationToken cancellationToken);
        Task<Result<List<Book>>> GetBookDetailsSort(CancellationToken cancellationToken);
        Task<Result<int>> TotalBookPrice(CancellationToken cancellationToken);
        Task<Result<Book>> ShowBookDetails(BookTotalPriceRequest request, CancellationToken cancellationToken);
    }
    
}
