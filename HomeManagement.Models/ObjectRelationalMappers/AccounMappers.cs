using HomeManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.Models.ObjectRelationalMappers
{
    public static class AccounMappers
    {
        public static AppUser MapSignUpToAppUser(SignUpVM model)
        {
            return new AppUser
            {
                Email = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                //City = model.City,
                //State = model.State,
                //CountryOfResidence = model.CountryOfResidence,
                //CountryOfOrigin = model.CountryOfOrigin
            };
        }

        public static AppUser MapInviteToAppUser(SendInviteVM model)
        {
            return new AppUser
            {
                Email = model.EmailAddress,
                FirstName = "Invited User",
                LastName = "Invited User",
            };
        }

        public static AppUser UpdateAppUser(AppUser user, UpdateInfoVM model)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ImagePath = model.ImagePath;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
            user.Street = model.Street;
            user.State = model.State;
            user.CountryOfResidence = model.CountryOfResidence;
            user.City = model.City;
            user.CountryOfOrigin = model.CountryOfOrigin;

            return user;
        }
    }
}
