using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public HairMgr m_HairMgr;
    public HudUI m_HudUI;
    public GameUI m_GameUI;
    public BattleFSM BtlFSM = new BattleFSM();

    private void Start()
    {
        GameMgr.Inst.SetGameScene(this);
    }

    public void Initialize()
    {
        m_HairMgr.Initialize();
        m_HudUI.Initialize();
        m_GameUI.Initialize();
        BtlFSM.Initialize(OnEnter_ReadyState, OnEnter_WaveState, OnEnter_GameState);
    }

    void OnEnter_ReadyState()
    {

    }
    void OnEnter_WaveState()
    {

    }
    void OnEnter_GameState()
    {

    }



}
