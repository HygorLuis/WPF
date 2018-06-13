using System;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace Escola.Notifications
{
    public class  Notifications
    {
        public Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: App.CurrentWindow,
                corner: Corner.BottomRight,
                offsetX: 20,
                offsetY: -13);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2),
                maximumNotificationCount: MaximumNotificationCount.FromCount(1));

            cfg.DisplayOptions.Width = 150; 

            cfg.Dispatcher = App.CurrentWindow.Dispatcher;
        });
    }
}
