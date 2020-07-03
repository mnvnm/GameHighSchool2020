using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreUI;
    public Text RestartUI;

    public PlayerController m_PlayerController;
    public List<GameObject> m_BulletList;

    public bool IsPlaying;
    public int Score;

    public float tick = 0;
    // Start is called before the first frame update
    private void Start()
    {
        //GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlaying)
        {
            tick += Time.deltaTime;
            if(tick > 1)
            {
                Score++;
                tick = 0;
            }
            ScoreUI.text = string.Format("Score : {0}", Score);
        }
        //else
        //{
        //    if(Input.GetKeyDown(KeyCode.R))
        //    {
        //        GameStart();
        //    }
        //}
    }

    //void GameStart()
    //{
    //
    //}
}
