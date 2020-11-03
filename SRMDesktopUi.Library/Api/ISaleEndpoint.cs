using SRMDesktopUi.Library.Models;
using System.Threading.Tasks;

namespace SRMDesktopUi.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}