using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using RabbitMQ.Messaging.Infrastructure;
using Serilog;
using TaskApp.Notifications.Data.TaskService;
using TaskApp.Notifications.Services;

namespace TaskApp.Notifications.NotificationManager
{
    public class NotificationHandler : IHostedService, IMessageHandlerCallback
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IServiceProvider _serviceProvider;

        public NotificationHandler(IMessageHandler messageHandler,
            IServiceProvider serviceProvider)
        {
            _messageHandler = messageHandler;
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Start(this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Stop();
            return Task.CompletedTask;
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            try
            {
                JObject messageObject = MessageSerializer.Deserialize(message);
                switch (messageType)
                {
                    case "TaskCreated":
                        await HandleAsync(messageObject.ToObject<TaskCreated>());
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while handling {messageType} event.");
            }

            return true;
        }

        private async Task HandleAsync(TaskCreated task)
        {
            using var scope = _serviceProvider.CreateScope();
            var notificationService = scope.ServiceProvider.GetService<INotificationService>();
            await notificationService.SendEmailToTaskAssigneeAsync(task);
        }
    }
}
