using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace HotFix
{
    class ShareWindow:Window
    {
        public void ShareBtn()
        {
            Window SharePanel = UIManager.instance.PopUpWnd(FilesName.SHAREPANEL, true, false);
        }
    }
}
