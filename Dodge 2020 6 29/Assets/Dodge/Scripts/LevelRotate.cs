using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 0.5f;
    public GameManager gameMNG;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, Speed * Time.deltaTime, 0);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if(gameMNG.IsPlaying == false)
        {
            transform.Rotate(0, 0, 0);
        }


        //if (player != null)
            //transform.LookAt(player.transform);


    }
}
