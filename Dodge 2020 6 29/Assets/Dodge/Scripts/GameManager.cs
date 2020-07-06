using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreUI;
    public Text RestartUI;

    public PlayerController m_PlayerController;
    public LevelRotate levelR;
    public List<GameObject> m_BulletSpawner;

    public bool IsPlaying;
    public int Score;

    public float tick = 0;
    // Start is called before the first frame update
    private void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlaying)
        {
            tick += Time.deltaTime;
            if(tick > 1)
            {
                Score += 100;
                tick = 0;
            }
            ScoreUI.text = string.Format("Score : {0}", Score);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
            }

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameStart()
    {
        levelR.enabled = true;
        IsPlaying = true;
        Score = 0;
        RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);
        for(int i = 0; i < m_BulletSpawner.Count;i++)
        {
            m_BulletSpawner[i].gameObject.SetActive(true);
        }
    }
    public void GameOver()
    {
        IsPlaying = false;
        RestartUI.gameObject.SetActive(true);
        m_PlayerController.gameObject.SetActive(false);
        for (int i = 0; i < m_BulletSpawner.Count; i++)
        {
            m_BulletSpawner[i].gameObject.SetActive(false);
        }

        Bullet[] bullet = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullet.Length; i++)
        {
            Destroy(bullet[i].gameObject);
        }

        levelR.enabled = false;
        levelR.transform.rotation = Quaternion.identity;

        int topScore = PlayerPrefs.GetInt("TopScore", 0);
        if (topScore < Score)
        {
            topScore = Score;
        }
        PlayerPrefs.SetInt("TopScore", topScore);
        PlayerPrefs.Save();

        RestartUI.text = string.Format("GameOver..\n TopScore : {0}\nRestart : R", topScore);
    }
}
