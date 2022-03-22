using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject
{
   
        public class Notifier: INotifier
        {
            private readonly IUnitOfWork unitOfWork;
            public Notifier(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Notification>> GetNotification() => await unitOfWork.NotificationRepository.GetOrderedNotification("hk");

            public async Task<Notification> Push(string text,string userId)
            {
                var notfication = Notification.Create(text, userId);
                unitOfWork.NotificationRepository.Add(notfication);
                return await unitOfWork.Complete() ? notfication : null;
            }

        }
    
}
