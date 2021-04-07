using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO.ManualMapper
{
    public class Responses
    {
        public static List<FamilyInviteReturnDTO> MapToResponseMsg(Dictionary<string, string> data)
        {
            var response = new List<FamilyInviteReturnDTO>();
            foreach (var item in data)
            {
                response.Add(new FamilyInviteReturnDTO { Email = item.Key, Result = item.Value });
            }

            return response;
        }
    }
}