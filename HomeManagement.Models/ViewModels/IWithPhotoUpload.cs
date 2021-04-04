using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGIT.Models.ViewModels
{
    /// <summary>
    ///  Any class requiring photo upload services implements this interface.
    /// </summary>
    public interface IWithPhotoUpload
    {
        public IFormFile Image { get; set; }
    }
}
