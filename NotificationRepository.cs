using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDataContext context):base(context)
        {

        }
        public async Task<int> CountUnreadNotifications(string userId)
        {
           return await context.Notifications.Where(n => n.UserId == userId && !n.IsRead).CountAsync();
        }

        public async Task<IEnumerable<Notification>> GetOrderedNotification(string userId)
        {
            return await context.Notifications.Where(n => n.UserId == userId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();                
        }
    }
}
