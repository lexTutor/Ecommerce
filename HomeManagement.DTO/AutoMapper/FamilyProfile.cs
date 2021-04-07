using AutoMapper;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO.Profiles
{
    public class FamilyProfile: Profile
    {
        public FamilyProfile()
        {
            //source=> target
            CreateMap<NewFamilyDTO, Family>();
            CreateMap<Family, FamilyDTO>();
        }
    }
}
