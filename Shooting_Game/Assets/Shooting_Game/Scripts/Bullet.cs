using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 _Velocity;
    public float B_Speed = 2;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = (transform.up * B_Speed);

        //transform.position += Vector3.up * B_Speed * Time.deltaTime;
    }
}
