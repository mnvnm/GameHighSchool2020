using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Dungeon : MonoBehaviour
{
    public Text ScoreUI;
    public Text RestartUI;

    public PlayerController_D m_PlayerController;
    //public LevelRotate levelR;
    public List<GameObject> m_BulletSpawner;
    public List<GameObject> m_BulletRotationSpawner;

    public bool IsPlaying;
    public int Score_tick;

    public float tick = 0;
    // Start is called before the first frame update
    private void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying)
        {
            tick += Time.deltaTime;
            if (tick > 1)
            {
                Score_tick += 1;
                tick = 0;
            }
            ScoreUI.text = string.Format("Time : {0}", Score_tick);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameStart()
    {
        //levelR.enabled = true;
        IsPlaying = true;
        Score_tick = 0;
        RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);
        for (int i = 0; i < m_BulletSpawner.Count; i++)
        {
            m_BulletSpawner[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < m_BulletRotationSpawner.Count; i++)
        {
            m_BulletRotationSpawner[i].gameObject.SetActive(true);
        }

    }
    public void GameWin()
    {
        IsPlaying = false;
        RestartUI.gameObject.SetActive(true);
        //m_PlayerController.gameObject.SetActive(false);
        for (int i = 0; i < m_BulletSpawner.Count; i++)
        {
            m_BulletSpawner[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < m_BulletRotationSpawner.Count; i++)
        {
            m_BulletRotationSpawner[i].gameObject.SetActive(false);
        }

        Bullet[] bullet = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullet.Length; i++)
        {
            Destroy(bullet[i].gameObject);
        }

        int topScore = PlayerPrefs.GetInt("TopScore", 0);
        if (topScore > Score_tick)
        {
            topScore = Score_tick;
        }
        PlayerPrefs.SetInt("TopScore", topScore);
        PlayerPrefs.Save();

        RestartUI.text = string.Format("GameWin!!\n TopScore : {0}\nRestart : R", topScore);
    }
}
