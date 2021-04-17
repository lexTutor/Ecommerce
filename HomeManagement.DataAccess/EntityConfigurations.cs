using HomeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DataAccess
{
    public class EntityConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasOne(chat => chat.UserFrom)
                .WithMany()
                .HasForeignKey(Chat => Chat.UserFromId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(chat => chat.UserTo)
                .WithMany()
                .HasForeignKey(Chat => Chat.UserToId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
