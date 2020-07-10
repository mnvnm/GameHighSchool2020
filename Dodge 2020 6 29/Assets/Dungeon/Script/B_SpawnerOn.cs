using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SpawnerOn : MonoBehaviour
{
    public List<GameObject> m_BulletSpawner;
    public GameManager_Dungeon gameMNG_D;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        gameMNG_D = FindObjectOfType<GameManager_Dungeon>();
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player" )
        {
            gameMNG_D.SetActivAllGameObject(typeof(BulletSpawner), true);
            Debug.Log("플레이어와 총알 스포너 On 충돌");
       }

    }
}