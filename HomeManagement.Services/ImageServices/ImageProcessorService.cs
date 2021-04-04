using System;
using System.Collections.Generic;
using System.IO;
using BLOGIT.Models;
using BLOGIT.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace BLOGIT.Repository
{
    /// <summary>
    /// Impage uploading service that enables image upload to the server
    /// </summary>
    public class ImageProcessorService : IImageProcessorService
    {
        private readonly IWebHostEnvironment _webHost;
        public ImageProcessorService(IWebHostEnvironment webHosting)
        {
            _webHost = webHosting;
        }

        /// <summary>
        /// Generic method for image uploading that takes an object of type T where T impleemets the IWithPhotoUpload interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ImageUpload<T>(T model) where T : IWithPhotoUpload
        {
            string photoPath = null;

            if (model.Image != null)
            {
                string folderName = Path.Combine(_webHost.WebRootPath, "Images");
                photoPath = Guid.NewGuid().ToString() + "_" + model.Image.FileName;

                string fullPath = Path.Combine(folderName, photoPath);

                using FileStream fs = new FileStream(fullPath, FileMode.Create);
                model.Image.CopyTo(fs);
            }

            return photoPath;
        }
    }
}
