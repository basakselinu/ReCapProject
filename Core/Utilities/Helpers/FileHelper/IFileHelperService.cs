using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    //IFormFile ile projemize dosya ekleyebildik. 
    public interface IFileHelperService
    {
        string Upload(IFormFile formFile, string root);
        void Delete(string filePath);
        string Update(IFormFile formFile, string root,string filePath);
    }
}

