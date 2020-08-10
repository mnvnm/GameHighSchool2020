using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float Speed = 12;
    public GameManager gameMNG;

    // Update is called once per frame
    void Update()
    {
        //Rigidbody rigidbody = GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        transform.position = new Vector3(xAxis, 0, yAxis) * Speed ;


        if (Input.GetKeyDown(KeyCode.Space)) // 키보드에 스페이스가 눌렸을때
        {
            Debug.Log("누름");
        }
        if (Input.GetKeyUp(KeyCode.Space)) // 키보드에 스페이스가 누르고 뗐을때
        {
            Debug.Log("땜");
        }
        if (Input.GetKey(KeyCode.UpArrow))// 키보드에 스페이스가 눌려져 있을때
        {
            transform.position += Vector3.forward * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.forward * Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.back * Speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.left * Speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.right * Speed);
        }
    }


    public void  Die()
    {
        Debug.Log("Die");
        transform.position = new Vector3(0, 1, 0);
        gameMNG.GameOver();
    }
}
