using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject
{
    public interface INotifier
    {
        Task<IEnumerable<Notification>> GetNotification();
        Task<Notification> Push(string text, string userId);
    }
}