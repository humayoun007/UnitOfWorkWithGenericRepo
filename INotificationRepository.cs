using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject
{
    public interface INotificationRepository: IRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetOrderedNotification(string userId);
        Task<int> CountUnreadNotifications(string userId);
    }
}
