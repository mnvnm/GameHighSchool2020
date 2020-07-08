using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWall_Button : MonoBehaviour
{

    public DownWall wall;
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
        if (other.attachedRigidbody.tag == "Player")
        {
            wall.gameObject.SetActive(false);
            Debug.Log("플레이어와 벽다운 버튼이 충돌");
        }

    }
}
