using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject m_player;
    public float m_Speed = 6;

    public GameObject m_bullet;
    public float B_Speed = 100;
    public float tick = 0;

    public FixedJoystick fixjoy;

    public Bullet m_BulletPrefab;

    public Transform[] m_FireMuzzles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, m_Speed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= new Vector3(0, m_Speed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position -= new Vector3(m_Speed, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(m_Speed, 0, 0) * Time.deltaTime;

        tick += Time.deltaTime;
        if (tick > 1 && Input.GetKey(KeyCode.Space))
        {
            foreach (var fireMuzzle in m_FireMuzzles)
            {
                var b = GameObject.Instantiate(m_BulletPrefab,fireMuzzle.position, fireMuzzle.rotation);
            }
            tick = 0;
        }


        Vector3 direction = Vector2.up * fixjoy.Vertical + Vector2.right * fixjoy.Horizontal;
        Debug.Log(direction); 
        transform.position += direction * m_Speed * Time.deltaTime;
    }
}
