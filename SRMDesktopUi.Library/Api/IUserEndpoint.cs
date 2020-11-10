using SRMDesktopUi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRMDesktopUi.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
    }
}