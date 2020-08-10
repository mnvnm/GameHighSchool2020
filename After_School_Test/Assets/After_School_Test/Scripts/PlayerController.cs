using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Particle;
    private float Speed = 8;
    private float R_Speed = 100;
    private bool attack = false;
    private float a_tick = 0;
    private float p_tick = 0;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        transform.position += (transform.forward * yAxis + transform.right * xAxis) * Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -R_Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, R_Speed * Time.deltaTime, 0);
        }

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += Vector3.forward * Speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += Vector3.back * Speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position += Vector3.left * Speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += Vector3.right * Speed * Time.deltaTime;
        //}
        //
        a_tick += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            attack = !attack;
        if (attack)
            {
             Ray ray = new Ray();
             ray.origin = transform.position;
             ray.direction = transform.forward;
            if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("1", "2"), QueryTriggerInteraction.Collide) && a_tick > 1)
             {
                GameObject.Instantiate(Particle, hit.point, Quaternion.identity);

                Debug.Log(hit.collider.name);
                a_tick = 0;
                p_tick = 1;
                
             }
             Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.blue);
        
            if(p_tick > 0)
            {
                p_tick -= Time.deltaTime;
                if(p_tick <= 0)
                    Destroy(Particle);
            }
        }

    }
}
