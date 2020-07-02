using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotationSpawner : MonoBehaviour
{ 
    // Start is called before the first frame update
    public GameObject m_bullet;
    public float B_Speed = 100;
    public float tick = 0;

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick > 0.25)
        {
            GameObject bullet = GameObject.Instantiate(m_bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            tick = 0;
        }
        transform.Rotate(0, B_Speed * Time.deltaTime, 0);

        // GameObject player = GameObject.FindGameObjectWithTag("Player");


        //if (player != null)
        //transform.LookAt(player.transform);


    }
}
