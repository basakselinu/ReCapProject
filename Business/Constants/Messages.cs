using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda.";

        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarListed = "Arabalar listelendi.";
        public static string CarNameInValid = "Araba ismi iki harften fazla olmalıdır.";
       
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandListed = "Markalar listelendi.";
       
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorListed = "Renkler listelendi.";
        
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcılar listelendi.";
        public static string UserNameInValid = "Kullanıcı ismi iki harften fazla olmalıdır.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";

        public static string CarImageUploaded = "Araba resmi başarıyla yüklendi.";
        public static string CarImageDeleted = "Araba resmi silindi.";
        public static string CarImageUpdated = "Araba resmi güncellendi.";
        public static string CarImageListed = "Araba resimleri listelendi.";
        internal static string CarImageLimit="En fazla 5 adet araba resmi yükleyebilirsiniz.";
    }
}
