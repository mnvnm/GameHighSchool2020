using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool IsTouch = false;
    public GameObject[] m_Obstacles;
    private void OnEnable()
    {
     foreach(var obstacle in m_Obstacles)
        {
            obstacle.SetActive(false);
            if (Random.Range(0,3) == 0)
            {
                obstacle.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Player")
        {
            GameManager.Instance.OnAddScore();
        }
    }
}
