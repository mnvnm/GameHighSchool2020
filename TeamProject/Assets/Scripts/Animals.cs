using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour//여기에선 동물들의 체력을 관리
{
    public int Hp;
    public int MaxHp = 1000;
    public bool bIsAlive = true;

    SpriteRenderer m_SprRenderer;

    void Start()
    {
        m_SprRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize()
    {
        Hp = MaxHp;
        bIsAlive = true;
    }

    public void Death()
    {
        StartCoroutine(Enum_DeathEffect());
        bIsAlive = false;
    }

    IEnumerator Enum_DeathEffect()
    {
        Color kColor = m_SprRenderer.color;
        while (kColor.a > 0)
        {
            kColor.a -= Time.deltaTime;
            m_SprRenderer.color = kColor;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(this.gameObject);
        yield return null;
    }

    void Update()
    {
    }
}
