using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers.GuidHelpers;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelperService
    {
        public string Upload(IFormFile formFile, string root)
        {
            //Yüklenecek dosyanın seçilip seçilmediğini burada kontrol ettik.(gereksiz kaynak tüketimini engelledik)
            if (formFile != null)
            {
                //Var olan bir klasör yoksa dosyaların kayıt edilebileceği yeni dizinin oluşturulabilmesini sağladık.
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                // GUID ile yeni dosya adı 
                string fileExtension = Path.GetExtension(formFile.FileName);//Dosyanın uzantısını aldık.
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + fileExtension;

                //Business katmanında oluşturduk
                //string filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images", newFileName);//Tam dosya yolu oluşturduk.

                //FileStream ile okuma, yazma işlemini yaptık.
                using (var fileStream = File.Create(root + filePath))
                {
                    formFile.CopyTo(fileStream);//dosyanın kopyalanacağı yeri belirttik.
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
        public void Delete(string filePath)
        {
            //Dosyanın olup olmadığını kontrol ettik
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile formFile, string root, string filePath)
        {
            //Dosya var olduğunda silip güncel versyonunu tekrar eklemiş olduk.
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(formFile, root);
        }
    }
}
//Yüklenen resim hem Web api içerisine hem de oluşturduğumuz images dosyası içerisine eklenmiş oldu.
//Bunun önüne geçebilmek için fileStream.Flush(); kullandık.