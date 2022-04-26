using Microsoft.AspNetCore.Http;
using SkijanjeLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Helper
{
    public class FileHelper : IFileHelper
    {
        public IFormFile ByteArrayToFile(byte[] array)
        {
            throw new NotImplementedException();
        }

       public byte[] FileToByteArray(IFormFile file)
        {
               
               if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();

                    return fileBytes;                
                    }
                }
               else
            {
                return new byte[0];
            }
            
        }

    }
}
