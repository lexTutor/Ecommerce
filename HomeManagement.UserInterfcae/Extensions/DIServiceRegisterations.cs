using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.Services;
using HomeManagement.Services.Repositories;
using HomeManagement.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Extensions
{
    public static class DIServiceRegisterations
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddTransient<IEmailServices, EmailServices>();
            service.AddScoped<IChatRepository, ChatRepository>();
            service.AddScoped<IReactionRepository, ReactionRepository>();
            service.AddScoped<IMessageRepository, MessageRepository>();
            service.AddScoped<ITaskIssueRepository, TaskIssueRepository>();
            service.AddScoped<ITaskRepository, TaskRepository>();
            service.AddScoped<IFamilyRepository, FamilyRepository>();
            service.AddScoped<IFamilyService, FamilyServices>();
        }
    }
}
