using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudClickDlg : MonoBehaviour
{
    public Text m_txtResult;

    public Button m_btnClick;

    void Start()
    {
        m_btnClick.onClick.AddListener(Click);
    }

    public void Initialize()
    {

    }


    public void Click()//클릭 할때 이벤트 함수(클릭마다 들어옴)
    {
        GameMgr.Inst.m_GameScene.m_HairMgr.Click();
    }
    void Update()
    {
        m_txtResult.text = GameMgr.Inst.m_GameScene.m_HairMgr.m_Hair.ToString();
    }
}
