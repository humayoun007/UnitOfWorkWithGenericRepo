using System.Threading.Tasks;

namespace TestProject
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataContext context;
        public UnitOfWork(ApplicationDataContext context)
        {
            this.context = context;
        }        
        public IRepository<Role> RoleRepository =>  new Repository<Role>(context);
        public IRepository<Category> CategoryRepository => new Repository<Category>(context);
        public INotificationRepository NotificationRepository => new NotificationRepository(context);
        public async Task<bool> Complete() => await context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
