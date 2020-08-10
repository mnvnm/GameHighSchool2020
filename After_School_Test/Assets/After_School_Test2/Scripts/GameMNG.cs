using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public static GameMNG _gameMNG;

    public int Score = 0;
    public int Life = 3;

    private void Awake()
    {
        if(_gameMNG == null)
        {
            _gameMNG = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("점수 : " + Score + " 목숨 : " + Life );

        if (Life <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void AddScore()
    {
        Score += 10;
    }
    public void DamageLife()
    {
        Life--;
    }
}
