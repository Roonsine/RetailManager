using SRMDesktopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SRMDesktopUi.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string userName, string password);

        Task GetLoggedInUserInfo(string token);
    }
}