using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.HelperClasses
{
    public static class ImageHelper
    {
        public static byte[] CreatePlaceHolder(this String str)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(str);
            long imageLength = fileInfo.Length;
            using (FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageLength);
            };
            return imageData;
        }
        public static async Task<byte[]> CreateImageFileAsync(this IFormFile file)
        {
            byte[] imageData = null;
            using (var memorystream = new MemoryStream())
            {
                await file.CopyToAsync(memorystream);
                imageData = memorystream.ToArray();
            };
            return imageData;
        }
    }
}
