﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public void Start()
    {
        m_ScoreUI.text = string.Format("SCORE : {0}", m_Score);
    }
    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool IsGameOver = false;
    public GameObject m_GameOverUI;
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Score = 0;

    public void OnPlayerDead()
    {
        IsGameOver = true;
        m_GameOverUI.SetActive(true);
    }
    public void OnAddScore()
    {
        m_Score += 10;
        m_ScoreUI.text = string.Format("SCORE : {0}" , m_Score);
    }
    void Update()
    {

    }
}
