﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 100;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0.5f, 0);

        // GameObject player = GameObject.FindGameObjectWithTag("Player");


        //if (player != null)
        //transform.LookAt(player.transform);


    }
}
