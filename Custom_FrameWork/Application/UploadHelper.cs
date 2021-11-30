using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_FrameWork.Application
{
    public class UploadHelper
    {
        public static bool UploadInRoot(string path, string filename)
        {

            try
            {

                if (path == null || filename == null)
                    return false; 
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool CheckDiroctoryExists(string path)
        {


            return false;
        }
    }
}
