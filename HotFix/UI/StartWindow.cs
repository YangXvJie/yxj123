using UnityEngine.UI;
using LitJson;
using UnityEngine;
using System;
using System.Collections.Generic;
using HotFix.Common.Utils;

namespace HotFix
{
    /// <summary>
    /// 游戏初始动画界面
    /// </summary>
    class StartWindow : Window
    {
        /// <summary>
        /// 开始游戏按钮
        /// </summary>
        public Button startGame;
        private Text text;

        public static Action<string> setText;

        public override void Awake(object param1 = null, object param2 = null, object param3 = null)
        {
            startGame = m_Transform.Find("StartGame").GetComponent<Button>();
            startGame.interactable = true;
            text = m_Transform.Find("StartGame/Text").GetComponent<Text>();
            Debug.Log("开始游戏拉");
            setText = setTextData;
            AddButtonClickListener(startGame, () =>
            {
                Debug.Log(RFrameWork.instance.token);
                StartWindow.setText("------正在获取马匹信息------");
                UserInfoManager.MyHorseList.Clear();
                UserInfoManager.MyHorseList = new Dictionary<int, HorseData>();
                HorseData[] list = new HorseData[1] { new HorseData("101", "conde", 0, 100) }; ;
                int index = 1;
                foreach (HorseData item in list)
                {
                    int id = int.Parse(item.id);
                    Debug.Log(id + "   " + item.code);
                    UserInfoManager.MyHorseList.Add(index, item);
                    index++;
                }
                UserInfoManager.NowHorseList.Clear();
                UserInfoManager.NowHorseList = new Dictionary<int, HorseData>(UserInfoManager.MyHorseList);
                Debug.Log("进入游戏");
                // if (UserInfoManager.noHorse)
                //   return;
                if (UserInfoManager.Sex == 0)
                {
                    UIManager.instance.PopUpWnd(FilesName.SELECTPLAYERPANEL, true, false);
                }
                else
                {
                    GameMapManager.instance.LoadScene(ConStr.MAINSCENE, FilesName.MAINPANEL, HouseManager.LoadMainScene);
                }
                UIManager.instance.CloseWnd(FilesName.STARTPANEL);
                //WebRequestManager.instance.AsyncLoadUnityWebRequest(WebRequestUtils.checkUserUrl, WebRequestFuncitons.CheckHorseNum, true, "{}", RFrameWork.instance.token);
                startGame.interactable = false;
                text.text = "------开始加载------";
            });
            }

        private void setTextData(string obj)
        {
            text.text = obj;
        }
    }
}
