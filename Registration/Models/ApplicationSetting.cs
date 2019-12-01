using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Models
{
    public class ApplicationSetting
    {
        public string JWT_Secret { get; set; }
        public string Clinte_URL { get; set; }
    }
}
