using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelpers
{
    public class GuidHelper
    {
        //Guid ile yüklenecek resimlerin benzersiz bir isimde oluşturulabilmesini sağladık.
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
