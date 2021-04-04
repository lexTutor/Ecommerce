﻿// <auto-generated />
using System;
using HomeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeManagement.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210313103802_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("HomeManagement.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HomeManagement.Models.Chats", b =>
                {
                    b.Property<string>("ChatsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsersId")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatsId");

                    b.HasIndex("UsersId");

                    b.ToTable("AppUserMessages");
                });

            modelBuilder.Entity("HomeManagement.Models.Messages", b =>
                {
                    b.Property<string>("MessagesId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attachment")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatsId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MessagesId");

                    b.HasIndex("ChatsId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("HomeManagement.Models.PersonalIssue", b =>
                {
                    b.Property<string>("PersonalIssueId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueFromId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReactionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonalIssueId");

                    b.HasIndex("IssueFromId");

                    b.HasIndex("ReactionsId");

                    b.ToTable("PersonalIssues");
                });

            modelBuilder.Entity("HomeManagement.Models.Reactions", b =>
                {
                    b.Property<string>("ReactionsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Emoji")
                        .HasColumnType("TEXT");

                    b.Property<string>("TasksId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserWhoReactedId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReactionsId");

                    b.HasIndex("ChatsId");

                    b.HasIndex("TasksId");

                    b.HasIndex("UserWhoReactedId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("HomeManagement.Models.TaskIssue", b =>
                {
                    b.Property<string>("TaskIssueId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueFromId")
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueWithTasksId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReactionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskIssueId");

                    b.HasIndex("IssueFromId");

                    b.HasIndex("IssueWithTasksId");

                    b.HasIndex("ReactionsId");

                    b.ToTable("TaskIssues");
                });

            modelBuilder.Entity("HomeManagement.Models.TaskType", b =>
                {
                    b.Property<string>("TaskTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskName")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskTypeId");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("HomeManagement.Models.Tasks", b =>
                {
                    b.Property<string>("TasksId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Returned")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TaskCreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskCreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskTypeId")
                        .HasColumnType("TEXT");

                    b.HasKey("TasksId");

                    b.HasIndex("TaskCreatorId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("HomeManagement.Models.UserTasks", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppUserId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HomeManagement.Models.Chats", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", "Users")
                        .WithMany("Messages")
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HomeManagement.Models.Messages", b =>
                {
                    b.HasOne("HomeManagement.Models.Chats", "Chat")
                        .WithMany("Message")
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("HomeManagement.Models.PersonalIssue", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", "IssueFrom")
                        .WithMany("PersonalIssues")
                        .HasForeignKey("IssueFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeManagement.Models.Reactions", "Reactions")
                        .WithMany()
                        .HasForeignKey("ReactionsId");

                    b.Navigation("IssueFrom");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("HomeManagement.Models.Reactions", b =>
                {
                    b.HasOne("HomeManagement.Models.Chats", "Chat")
                        .WithMany("Reactions")
                        .HasForeignKey("ChatsId");

                    b.HasOne("HomeManagement.Models.Tasks", "Task")
                        .WithMany("Reactions")
                        .HasForeignKey("TasksId");

                    b.HasOne("HomeManagement.Models.AppUser", "UserWhoReacted")
                        .WithMany("Reactions")
                        .HasForeignKey("UserWhoReactedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Task");

                    b.Navigation("UserWhoReacted");
                });

            modelBuilder.Entity("HomeManagement.Models.TaskIssue", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", "IssueFrom")
                        .WithMany()
                        .HasForeignKey("IssueFromId");

                    b.HasOne("HomeManagement.Models.Tasks", "IssueWith")
                        .WithMany("Issues")
                        .HasForeignKey("IssueWithTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeManagement.Models.Reactions", "Reactions")
                        .WithMany()
                        .HasForeignKey("ReactionsId");

                    b.Navigation("IssueFrom");

                    b.Navigation("IssueWith");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("HomeManagement.Models.Tasks", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", "TaskCreator")
                        .WithMany()
                        .HasForeignKey("TaskCreatorId");

                    b.HasOne("HomeManagement.Models.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId");

                    b.Navigation("TaskCreator");

                    b.Navigation("TaskType");
                });

            modelBuilder.Entity("HomeManagement.Models.UserTasks", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", "AppUser")
                        .WithMany("Tasks")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeManagement.Models.Tasks", "Task")
                        .WithMany("TaskAsignees")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HomeManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeManagement.Models.AppUser", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("PersonalIssues");

                    b.Navigation("Reactions");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("HomeManagement.Models.Chats", b =>
                {
                    b.Navigation("Message");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("HomeManagement.Models.Tasks", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Reactions");

                    b.Navigation("TaskAsignees");
                });
#pragma warning restore 612, 618
        }
    }
}
