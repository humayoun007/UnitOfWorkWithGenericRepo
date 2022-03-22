using System;
using System.Threading.Tasks;

namespace TestProject
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Role> RoleRepository { get; }
        IRepository<Category> CategoryRepository { get; }

        INotificationRepository NotificationRepository { get; }
        Task<bool> Complete();
    }
}
