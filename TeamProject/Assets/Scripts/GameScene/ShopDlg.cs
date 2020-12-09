using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDlg : MonoBehaviour
{
    public Button m_BtnShop;
    public Button m_btnSell;
    public Button m_btnUpgrade;

    public Text m_txtUgradeCost;

    public bool B_Check;

    public Animator m_ani;


    void Start()
    {
        B_Check = false;
        m_ani.SetBool("bSelc", B_Check);

        m_BtnShop.onClick.AddListener(OnClickShop);
        m_btnUpgrade.onClick.AddListener(Upgrade_Hair);
        m_btnSell.onClick.AddListener(Sell_Hair);
    }

    public void OnClickShop()
    {
        if (B_Check)
        {
            B_Check = false;
            m_ani.SetBool("bSelc", B_Check);
        }
        else
        {
            B_Check = true;
            m_ani.SetBool("bSelc", B_Check);
        }
    }
    public void Upgrade_Hair()
    {
        GameMgr.Inst.m_GameScene.m_HairMgr.Upgrade_GetHair();
    }

    public void Sell_Hair()
    {
        GameMgr.Inst.m_GameScene.m_HairMgr.Sell_Hair();
    }
}
