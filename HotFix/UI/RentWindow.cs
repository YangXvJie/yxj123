using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W.GameFrameWork.ExcelTool;

namespace HotFix
{
    class RentWindow : Window
    {
        public void RentPanel()
        {
            Window rentPanels = UIManager.instance.PopUpWnd(FilesName.RENTPANEL, true, false);
        }
        
    }
}
