using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float Speed = 8;
    public GameManager gameMNG;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        float Fire = Input.GetAxis("Fire1");

        //rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * Speed) ;

        if (Fire != 0) Die();

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
            Debug.Log("앞");
            transform.position += Vector3.forward * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.forward * Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("뒤");
            transform.position += Vector3.back * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.back * Speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("왼");
            transform.position += Vector3.left * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.left * Speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("오");
            transform.position += Vector3.right * Speed * Time.deltaTime;
            //rigidbody.AddForce(Vector3.right * Speed);
        }

        if (Input.GetKeyDown(KeyCode.F)) Die();

    }


    public void  Die()
    {
        Debug.Log("Die");
        transform.position = new Vector3(0, 1, 0);
        gameMNG.GameOver();
    }
}
