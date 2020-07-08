using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.tag == "Player" && other.attachedRigidbody.tag != null)
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController_D>();
            player.Die();
            Debug.Log("플레이어와 트랩이 충돌");
        }

    }
}
