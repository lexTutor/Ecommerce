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

            //Repository
            service.AddScoped<IChatRepository, ChatRepository>();
            service.AddScoped<IReactionRepository, ReactionRepository>();
            service.AddScoped<IMessageRepository, MessageRepository>();
            service.AddScoped<ITaskIssueRepository, TaskIssueRepository>();
            service.AddScoped<ITaskRepository, TaskRepository>();
            service.AddScoped<IFamilyRepository, FamilyRepository>();
            service.AddScoped<IPersonalIssueRepository, PersonalIssueRepository>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //Services
            service.AddScoped<IFamilyService, FamilyServices>();
            service.AddScoped<ITaskService, TaskService>();
            service.AddScoped<ITaskIssueService, TaskIssueService>();
            service.AddScoped<IPersonalIssueService, PersonalIssueService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IReactionService, ReactionService>();
            service.AddScoped<IChatService, ChatService>();
            service.AddScoped<IMessageService, MessageService>();
            service.AddTransient<IEmailServices, EmailServices>();
        }
    }
}
