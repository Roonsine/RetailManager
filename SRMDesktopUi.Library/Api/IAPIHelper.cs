using SRMDesktopUI.Models;
using System.Threading.Tasks;

namespace SRMDesktopUi.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);

        Task GetLoggedInUserInfo(string token);
    }
}