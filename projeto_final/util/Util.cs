using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.util
{
    public static class Util
    {

        public static bool ValidarDouble(string str)
        {
            try
            {
                Convert.ToDouble(str);
                return true;
            } catch {
                return false;
            }
        }

        public static bool ValidarInt(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            } catch { 
                return false;
            }
        }
    }
}
