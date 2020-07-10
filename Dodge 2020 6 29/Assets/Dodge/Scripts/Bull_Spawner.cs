using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull_Spawner : MonoBehaviour
{
    public float m_RotationSpeed = 60f;
    public GameObject m_Bullet;

    public float m_shot = 1f;

    public Vector3 m_Velocity;

    void Update()
    {
        //GameObject bullet = GameObject.Instantiate(m_Bullet);
        //bullet.transform.position = transform.position;
        //bullet.transform.rotation = transform.rotation;

        //transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);

        m_shot -= Time.deltaTime;

        if (m_shot <= 0)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            var b = bullet.GetComponent<Bullet>();
            b._Velocity = transform.forward;

            //transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
            m_shot = 1;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //player

        //플레이어 유도
        if (player != null)
        {
            Vector3 attacketPoint = player.transform.position;
            attacketPoint.y = transform.position.y;
            transform.LookAt(attacketPoint);

        }

    }
}
