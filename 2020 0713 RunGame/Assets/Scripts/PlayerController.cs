using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_player;

    public AudioSource m_AudioSource;
    public AudioClip m_Jump_S;
    public AudioClip m_Die_S;

    public bool isground = false;
    public bool isdead = false;
    public int jumpCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (isdead) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            isground = !isground;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            isdead = !isdead;
        if (Input.GetKey(KeyCode.A))
        {
            m_player.position += new Vector2(-3, 0) * Time.deltaTime;
            transform.localScale = new Vector2(-3, 3);
        }
           
        if (Input.GetKey(KeyCode.D))
        {
            m_player.position += new Vector2(3, 0) * Time.deltaTime;
            transform.localScale = new Vector2(3, 3);

        }


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            m_player.velocity = Vector2.zero;
            m_player.AddForce(Vector2.up * 450);
            jumpCount++;
            m_AudioSource.clip = m_Jump_S;
            m_AudioSource.Play();
        }

        m_Animator.SetBool("IsDead", isdead);
        m_Animator.SetBool("IsGround", isground);
        GameManager.Instance.OnAddScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            jumpCount = 0;
            isground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isground = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone" && !isdead)
        {
            isdead = true;
            m_Animator.SetBool("IsDead", isdead);
            m_AudioSource.clip = m_Die_S;
            m_AudioSource.Play();
            FindObjectOfType<PlatformSpawner>().enabled = false;
            GameManager.Instance.OnPlayerDead();
        }
    }

}
