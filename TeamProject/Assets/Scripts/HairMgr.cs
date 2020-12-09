using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairMgr : MonoBehaviour
{
    public GameObject m_AnimalPrefab;
    private Animals m_Animal;

    public float m_Hair = 0;//현재 가지고 있는 털의 양
    public float m_GetHair = 1;//클릭당 얻을 털의 양
    public float m_Gold = 0;//현재 가지고 있는 재화
    public float m_AutoGold = 1;//일정시간이 지나면 얻을 자동 털 획득량
    public float m_AutoGoldTick = 10;//위에 말한 일정시간
    public float m_AutoGoldTickCount = 0;//일정시간 채워주는 양
    public float m_CriticalGetHair = 2;//크리티컬 때의 기본 털 얻는 양
    public float m_CriticalUp = 0.25f;//크리티컬 업그레이드 할때의 기본 업그레이드 양
    public float m_CriticalGetHairProb = 1;//크리티컬 때의 털 얻는 양

    public float m_UpgradeGetHair_Cost = 20;//GetHair업그레이드 코스트
    public float m_UpgradeCriticalProb_Cost = 20;//CriticalProb 업그레이드 코스트
    public float m_UpgradeCriticalGetHair_Cost = 20;//CriticalGetHair 업그레이드 코스트
    public float m_UpgradeFeverGage_Cost = 20;//클릭당 얻을 피버게이지 업그레이드 코스트
    public float m_UpgradeAutoGold_Cost = 20;//오토골드 업그레이드 코스트
    public float m_UpgradeAutoGoldTick_Cost = 20;//오토골드 얻을 시간 업그레이드 코스트

    public float m_UpgradeGetHair_LV = 0;//GetHair업그레이드 코스트
    public float m_UpgradeCriticalProb_LV = 1;//CriticalProb 업그레이드 코스트
    public float m_UpgradeCriticalGetHair_LV = 0;//CriticalGetHair 업그레이드 코스트
    public float m_UpgradeFeverGage_LV = 1;//클릭당 얻을 피버게이지 업그레이드 코스트
    public float m_UpgradeAutoGold_LV = 1;//오토골드 업그레이드 코스트
    public float m_UpgradeAutoGoldTick_LV = 1;//오토골드 얻을 시간 업그레이드 코스트
    //변수 업그레이드 공식
    // 변수 = 변수 * 레벨
    //ex) m_GetHair = 1 + 3 * LV;
    void Start()
    {
    }

    public void Initialize()
    {

    }

    public void Click()//클릭 할때 이벤트 함수(클릭마다 들어옴)
    {
        if(IsAnimal())
        {
            float a = Random.Range(0.0f, 100.0f);

            if(a <= m_CriticalGetHairProb)
            {
                m_Hair += m_GetHair * Critical();
                m_Animal.Hp -= (int)(m_GetHair * Critical());
            }
            else
            {
                m_Hair += m_GetHair;
                m_Animal.Hp -= (int)m_GetHair;
            }
        }
    }

    //업그레이드의 의한 값들 (공식들)-----
    public float Critical()
    {
        return m_CriticalGetHair + (m_CriticalUp * m_UpgradeCriticalGetHair_LV);
    }

    public float GetHair()
    {
        return 3 * m_UpgradeGetHair_LV + 1;
    }
    //__________________________________
    public void Sell_Hair()//털을 판매할때 들어오는 함수
    {
        if (m_Hair >= 5)
        {
            m_Gold += (int)(m_Hair / 5);
            m_Hair = m_Hair % 5;
        }
    }

    //업그레이드 하는 함수들
    public void Upgrade_CriticalProb()//크리티컬 확률 업그레이드 함수
    {
        if (m_Gold >= m_UpgradeCriticalProb_Cost && m_UpgradeCriticalProb_LV < 8)
        {
            m_UpgradeCriticalProb_LV++;
            m_Gold -= m_UpgradeCriticalProb_Cost;
            m_UpgradeCriticalProb_Cost += (int)(m_UpgradeCriticalProb_Cost / 8);
        }
    }
    public void Upgrade_CriticalGetHair()//크리티컬 GetHair 업그레이드 함수
    {
        if(m_Gold >= m_UpgradeCriticalGetHair_Cost)
        {
            m_UpgradeCriticalGetHair_LV++;
            m_Gold -= m_UpgradeCriticalGetHair_Cost;
            m_UpgradeCriticalGetHair_Cost += (int)(m_UpgradeCriticalGetHair_Cost / 8);
        }
    }

    public void Upgrade_GetHair()
    {
        if(m_Gold >= m_UpgradeGetHair_Cost)//업그레이드(m_GetHair 의 값을 증가)
        {
            m_GetHair = GetHair();
            m_Gold -= m_UpgradeGetHair_Cost;
            m_UpgradeGetHair_Cost += (int)(m_UpgradeGetHair_Cost / 8);
        }
    }

    //업데이트 와 동물 관련
    void Update()
    {
        m_AutoGoldTickCount += Time.deltaTime;

        if(m_AutoGoldTick < m_AutoGoldTickCount)
        {
            m_AutoGoldTickCount = 0;
            m_Gold += m_AutoGold;
        }

        if (IsAnimal())
        {
            if (m_Animal.Hp <= 0 && m_Animal.bIsAlive)
            {
                m_Animal.Death();
                m_Animal.transform.position += new Vector3(-3, 0, 0);
                m_Animal = null;
            }
        }
        else CreateAnimal();
    }
    public bool IsAnimal()
    {
        if (m_Animal) return true;
        else return false;
    }

    public void CreateAnimal()
    {
        if (IsAnimal()) return;

        GameObject go = Instantiate(m_AnimalPrefab);
        go.gameObject.SetActive(true);
        m_Animal = go.GetComponent<Animals>();
        m_Animal.Initialize();
    }
}
