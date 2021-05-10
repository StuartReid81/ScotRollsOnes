using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyBuilderSite.Services.Helpers
{
    public static class DateTimeHelpers
    {
        public static string ToMomentString(this DateTimeOffset d)
        {
            return d.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
