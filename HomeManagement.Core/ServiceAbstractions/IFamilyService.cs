using HomeManagement.DTO;
using HomeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface IFamilyService
    {
        Task<Response<Family>> Add(NewFamilyDTO model);

        Task<Response<FamilyDTO>> GetFamily(string Id);

        Task<Response<List<FamilyInviteReturnDTO>>> InviteUser(FamilyMembersInviteDTO model, IUrlHelper url, string requestScheme);
    }
}
