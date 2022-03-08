using HFRetailManagerDesktopUI.Models;
using System.Threading.Tasks;

namespace HFRetailManagerDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}