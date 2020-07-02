using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float Speed = 8;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;

        tick += Time.deltaTime;

        if (tick > 5)
        {
            Debug.Log("총알 컷");
            Destroy(gameObject);
        }
        Debug.Log(tick);
    }
    private float tick = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.tag == "Player" && other.attachedRigidbody.tag != null)
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController>();
            player.Die();
            Debug.Log("플레이어와 총알이 충돌");
        }
    }
}
