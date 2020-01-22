using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public Vector2 LockPosition;
    public bool Locked;
    public bool Hold;
    public Sprite LockSprite;
    public Sprite HoldSprite;

    private SpriteRenderer m_Icon;
    private Color m_InitColor;

    private void Awake()
    {
        m_Icon = GetComponent<SpriteRenderer>();
        m_InitColor = m_Icon.color;
    }

    private float GetLimbAngle(GameObject from, GameObject to)
    {
        Vector2 dir =  to.transform.position - from.transform.position;
        float angle = Vector2.Angle(Vector2.right, dir);
        if (Vector2.Dot(Vector2.up, dir) < 0)
            angle = -angle;
        return angle;
    }

    private void Update()
    {
        if (Hold)
        {
            m_Icon.sprite = HoldSprite;
            SetIconColor(Color.green);
        }
        else if (Locked)
        {
            m_Icon.sprite = LockSprite;
            SetIconColor(Color.red);
        }
        else
        {
            m_Icon.sprite = HoldSprite;
            SetIconColor(m_InitColor);
        }
            
                
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Locked = true;
            LockPosition = transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Locked = false;
        }
    }

    public void SetIconColor(Color i_Color)
    {
        m_Icon.color = i_Color;
    }
}
