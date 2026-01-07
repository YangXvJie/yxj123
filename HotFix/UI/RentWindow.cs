using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using W.GameFrameWork.ExcelTool;

namespace HotFix
{
    class RentWindow : Window
    {
        private Button returnBtn;
        public override void Awake(object param1 = null, object param2 = null, object param3 = null)
        {
            GatAllComponent();
            AddAllBtnListener();
        }

        private void AddAllBtnListener()
        {
            AddButtonClickListener(returnBtn, () => {UIManager.instance.CloseWnd(this); });
        }

        private void GatAllComponent()
        {
            returnBtn =m_Transform.Find("BackImg/CloseBtn").GetComponent<Button>();
        }

        public void RentPanel()
        {
            Window rentPanels = UIManager.instance.PopUpWnd(FilesName.RENTPANEL, true, false);
        }
        
    }
}
