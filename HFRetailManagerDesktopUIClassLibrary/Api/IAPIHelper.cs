using HFRetailManagerDesktopUI.Models;
using System.Threading.Tasks;

namespace HFRetailManagerDesktopUIClassLibrary.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}