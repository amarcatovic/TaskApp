using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using RabbitMQ.Messaging.Infrastructure;
using Serilog;
using TaskApp.Auth.Data.UserService;
using TaskApp.Auth.Services;
using TaskApp.Users.Data.Commands;

namespace TaskApp.Auth.EventHandlers
{
    public class AuthHandler : IHostedService, IMessageHandlerCallback
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IServiceProvider _serviceProvider;

        public AuthHandler(IMessageHandler messageHandler,
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
                    case "UserCreated":
                        await HandleAsync(messageObject.ToObject<UserCreated>());
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while handling {messageType} event.");
            }

            return true;
        }

        private async Task HandleAsync(UserCreated user)
        {
            using var scope = _serviceProvider.CreateScope();
            var authService = scope.ServiceProvider.GetService<IAuthService>();
            await authService.RegisterUserAsync(user.Email, user.Password);
        }
    }
}
