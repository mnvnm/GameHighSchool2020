using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float tick = 1;
    GameObject m_bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick > 1)
        {
            GameObject bullet = Instantiate(m_bullet);
            bullet.transform.position = new Vector2(Random.Range(0, 1920), 1200);

            var b = bullet.GetComponent<Bullet>();
            b._Velocity = transform.forward;
            tick = 0;
        }
    }
}
