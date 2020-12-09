using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : Singleton<GameMgr>
{
    private GameScene m_gameScene;
    public GameScene m_GameScene { get { return m_gameScene; } }
    public void SetGameScene(GameScene Scene)    {
        m_gameScene = Scene;
    }

    public bool IsInstalled { get; set; }

    public void Initialize()
    {
        IsInstalled = true;
    }
}
