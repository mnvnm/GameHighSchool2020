using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //_Velocity = transform.forward;
    }
    public Vector3 _Velocity;

    public float Speed = 8;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = (_Velocity * Speed);

        transform.position += transform.forward * Speed * Time.deltaTime;

        tick += Time.deltaTime;

        if (tick > 5)
        {
            Debug.Log("총알 컷");
            Destroy(gameObject);
        }
    }
    private float tick = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;
        if(other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player")
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController_D>();
            player.Die();
            Debug.Log("플레이어와 총알이 충돌");
        }
        else 
        {   
            Destroy(gameObject);
        }

    }
}
