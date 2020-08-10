using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedCube : MonoBehaviour, IPointerDownHandler
{
    private float G_Speed = 8;
    public void OnPointerDown(PointerEventData eventData)
    {
        GameMNG._gameMNG.AddScore();
        Destroy(gameObject);
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        gameObject.transform.position += Vector3.down * G_Speed * Time.deltaTime ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            GameMNG._gameMNG.DamageLife();
            Destroy(gameObject);
        }
    }
}
