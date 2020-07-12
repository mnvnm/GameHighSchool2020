using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager_Dungeon : MonoBehaviour
{
    public Text ScoreUI;
    public Text RestartUI;
    public Image Minimap;
    public bool Minimap_visible;

    public PlayerController_D m_PlayerController;
    //public LevelRotate levelR;

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
        if(Input.GetKey(KeyCode.M))
        {
            Minimap_visible = !Minimap_visible;
        }

        Minimap.gameObject.SetActive(Minimap_visible);
    }

    public void GameStart()
    {
        //levelR.enabled = true;
        IsPlaying = true;
        Score_tick = 0;
        RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);

        SetActivAllGameObject(typeof(BulletSpawner), true);
        SetActivAllGameObject(typeof(BulletRotationSpawner), true);
        SetActivAllGameObject(typeof(Bullet), true);

    }
    public void GameWin()
    {
        IsPlaying = false;
        RestartUI.gameObject.SetActive(true);
        //m_PlayerController.gameObject.SetActive(false);

        SetActivAllGameObject(typeof(BulletSpawner), false);
        SetActivAllGameObject(typeof(BulletRotationSpawner), false);
        SetActivAllGameObject(typeof(Bullet), false);

        int num1 = PlayerPrefs.GetInt("1st",999);
        int num2 = PlayerPrefs.GetInt("2nd",999);
        int num3 = PlayerPrefs.GetInt("3rd",999);

        if(Score_tick < num1)
        {
            num3 = num2;
            num2 = num1;
            num1 = Score_tick;
        }
        else if(Score_tick < num2)
        {
            num3 = num2;
            num2 = Score_tick;
        }
        else if(Score_tick < num3)
        {
            num3 = Score_tick;
        }

        PlayerPrefs.SetInt("1st", num1);
        PlayerPrefs.SetInt("2nd", num2);
        PlayerPrefs.SetInt("3rd", num3);
        PlayerPrefs.Save();

        RestartUI.text = string.Format("GameWin!!\n 1st : {0} \n 2nd : {1} \n 3rd : {2}\nRestart : R", num1,num2,num3);
    }

    public void SetActivAllGameObject(Type type, bool isActivity)
    {
        var objects = Resources.FindObjectsOfTypeAll(type);
        foreach(var obj in objects)
        {
            var gonj = (MonoBehaviour)obj;
            gonj.gameObject.SetActive(isActivity);
        }
    }

    //public void SetDisactivAllGameObject(Type type)
    //{
    //    SetActivAllGameObject(type, false);
    //}
    //
    //public void SetDisactivAllBulletSpawner()
    //{
    //    SetDisactivAllGameObject(typeof(BulletSpawner));
    //}
}
