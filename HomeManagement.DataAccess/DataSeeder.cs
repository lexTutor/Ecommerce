using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeManagement.DataAccess
{
    public class DataSeeder
    {
        public static async System.Threading.Tasks.Task EnsureCreated(DataContext _ctx)
        {
            try
            {
             await _ctx.Database.EnsureCreatedAsync();

            }
            catch (Exception)
            {

            }
        }
        public static async System.Threading.Tasks.Task SeedeRoles(DataContext _ctx, RoleManager<IdentityRole> _roleManager)
        {
            try
            {
                //Checks if there is data in the roles table and seeds data into it, if empty.
                if (!_roleManager.Roles.Any())
                {
                    List<string> roles = new List<string> { "Parent", "Guardian", "Child"};
                    foreach (var item in roles)
                    {
                        var role = new IdentityRole(item);
                        await _roleManager.CreateAsync(role);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static async System.Threading.Tasks.Task SeedFamily(DataContext _ctx)
        {
            try
            {
                if (!_ctx.Family.Any())
                {
                    var DataConvertedToString = File.ReadAllText("../HomeManagement.DataAccess/SeedData/Family.json");
                    var families = JsonConvert.DeserializeObject<List<Family>>(DataConvertedToString);
                    foreach (var family in families)
                    {
                        _ctx.Family.Add(family);
                    }
                   await  _ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

            }
        }

        public static async System.Threading.Tasks.Task SeedeUsers(DataContext _ctx, UserManager<AppUser> _userManager)
        {
            try
            {
                if (!_ctx.AppUsers.Any())
                {
                    var DataConvertedToString = File.ReadAllText("../HomeManagement.DataAccess/SeedData/AppUsers.json");

                    var users = JsonConvert.DeserializeObject<List<AppUser>>(DataConvertedToString);

                    var families = _ctx.Family.Take(2).ToList();

                    List<string> roles = new List<string> { "Parent", "Guardian", "Child" };

                    var count = 0;
                    for (int i = 0; i < users.Count; i++)
                    {
                        users[i].FamilyId = families[i % 2].Id;
                        users[i].Role = roles[i % 2];
                        var result = await _userManager.CreateAsync(users[i], "P@ssW0rd");

                        if (result.Succeeded)
                        {
                          await  _userManager.AddToRoleAsync(users[i], roles[count]);
                            count = count == 2 ? count = 0 : count++;
                        }
                    }
                    await _ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        public static async System.Threading.Tasks.Task SeedTasks(DataContext _ctx)
        {
            try
            {
                if (!_ctx.Tasks.Any())
                {
                    var DataConvertedToString = File.ReadAllText("../HomeManagement.DataAccess/SeedData/Tasks.json");

                    var parents = _ctx.AppUsers.Where(user => user.Role == "Parent" || user.Role == "Guardian").Take(3).ToList();

                    var tasks = JsonConvert.DeserializeObject<List<Task>>(DataConvertedToString);

                    var count = 0;
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        tasks[i].TaskCreatorId = parents[count].Id;
                        _ctx.Tasks.Add(tasks[i]);
                        count = count == 2 ? count = 0 : count++;
                    }

                  await  _ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        public static async System.Threading.Tasks.Task SeedTaskIssues(DataContext _ctx)
        {
            if (!_ctx.TaskIssues.Any())
            {
                var DataConvertedToString = File.ReadAllText("../HomeManagement.DataAccess/SeedData/TaskIssues.json");

                var taskIssue = JsonConvert.DeserializeObject<List<TaskIssue>>(DataConvertedToString);

                var children = _ctx.AppUsers.Where(user => user.Role == "Child" || user.Role == "Guardian").Take(3).ToList();

                var tasks = _ctx.Tasks.Take(3).ToList();

                var count = 0;
                for (int i = 0; i < tasks.Count; i++)
                {
                    taskIssue[i].IssueWith = tasks[count];
                    taskIssue[i].IssueFrom = children[count];
                    _ctx.TaskIssues.Add(taskIssue[i]);
                    count = count == 2 ? count = 0 : count++;
                }

                await _ctx.SaveChangesAsync();
            }
        }

        public static async System.Threading.Tasks.Task SeedPersonalIssues(DataContext _ctx)
        {
            if (!_ctx.PersonalIssues.Any())
            {
                var DataConvertedToString = File.ReadAllText("../HomeManagement.DataAccess/SeedData/PersonalIssues.json");

                var personalIssue = JsonConvert.DeserializeObject<List<PersonalIssue>>(DataConvertedToString);

                var children = _ctx.AppUsers.Where(user => user.Role == "Child" || user.Role == "Guardian").Take(3).ToList();

                var tasks = _ctx.Tasks.Take(3).ToList();

                var count = 0;
                for (int i = 0; i < tasks.Count; i++)
                {
                    personalIssue[i].IssueFrom = children[count];
                    _ctx.PersonalIssues.Add(personalIssue[i]);
                    count = count == 2 ? count = 0 : count++;
                }

                await _ctx.SaveChangesAsync();
            }
        }

        public static async System.Threading.Tasks.Task SeedChat(DataContext _ctx)
        {
            if (!_ctx.Chat.Any())
            {
                var users = _ctx.AppUsers.Take(2).ToList();

                Chat chat = new Chat();
                chat.UserFromId = users[0].Id;
                chat.UserToId = users[1].Id;
                chat.Message = new List<Message> { new Message { MessageDetails = "Hello, this is a seeded chat 😎" } };

                _ctx.Chat.Add(chat);
              await  _ctx.SaveChangesAsync();
            }
        }
    }
}
