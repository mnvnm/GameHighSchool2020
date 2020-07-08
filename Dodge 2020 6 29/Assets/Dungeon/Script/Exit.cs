using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public int Score;

    public float tick = 0;

    public GameManager_Dungeon gameMNG;
    // Start is called before the first frame update
    void Start()
    {
        gameMNG.GameStart();
    }

    // Update is called once per frame
    void Update()
    {

        tick += Time.deltaTime;
        if (tick > 1)
        {
            Score ++;
            tick = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.tag == "Player")
        {
            gameMNG.GameWin();
        }

    }
    
}
