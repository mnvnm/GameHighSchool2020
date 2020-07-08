using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SpawnerOn : MonoBehaviour
{
    public List<GameObject> m_BulletSpawner;
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
            for (int i = 0; i < m_BulletSpawner.Count; i++)
            {
                m_BulletSpawner[i].gameObject.SetActive(true);
            }
            Debug.Log("플레이어와 총알 스포너 Off 충돌");
        }

    }
}