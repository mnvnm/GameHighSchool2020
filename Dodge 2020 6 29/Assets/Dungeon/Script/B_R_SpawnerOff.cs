using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_R_SpawnerOff : MonoBehaviour
{
    public GameManager_Dungeon gameMNG_D;
    // Start is called before the first frame update
    void Start()
    {

        gameMNG_D = FindObjectOfType<GameManager_Dungeon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player" )
        {
            gameMNG_D.SetActivAllGameObject(typeof(BulletRotationSpawner), false);
            Debug.Log("플레이어와 총알 로테이션 스포너 Off 충돌");
        }

    }
}
