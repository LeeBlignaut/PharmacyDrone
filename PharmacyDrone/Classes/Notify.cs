using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using System.Windows;
using System.Threading;

namespace PharmacyDrone.Classes
{

    
    class Notify
    {
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });


        public void information(string message)
        {
            notifier.ShowInformation(message);

        }
        public void warning(string message)
        {
            notifier.ShowWarning(message);
        }
        public void error(string message)
        {
            notifier.ShowError(message);
        }
        public void success(string message)
        {
            notifier.ShowSuccess(message);
        }

        public void Dispose()
        {

            notifier.Dispose();
        }
    }
}
