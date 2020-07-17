using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject m_PlatformSpawner;
    public GameObject[] m_platform;
    public int  m_MinY = -2;
    public int  m_MaxY = 2; 
    public float m_MinYDelay = 3; 
    public float m_MaxYDelay = 5;
    public float m_SpawnDelay = 0;
    public int m_PlatformCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_platform = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            m_platform[i] = GameObject.Instantiate(m_PlatformSpawner);
            m_platform[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_SpawnDelay <= 0)
        {
            m_platform[m_PlatformCount].SetActive(false);
            m_platform[m_PlatformCount].SetActive(true);

            Vector2 spawnPosition = new Vector2(20.48f, Random.Range(m_MinY, m_MaxY));
            m_platform[m_PlatformCount].transform.position = spawnPosition;

            m_PlatformCount = (m_PlatformCount + 1) % 3;

            m_SpawnDelay = Random.Range(m_MinYDelay, m_MaxYDelay);
        }
        m_SpawnDelay -= Time.deltaTime;
    }
}
