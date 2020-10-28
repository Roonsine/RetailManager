using SRMDesktopUi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRMDesktopUi.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}