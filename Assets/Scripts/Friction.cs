using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public Vector2 LockPosition;
    public bool Locked;
    public bool Hold;

    private SpriteRenderer m_Icon;
    private Color m_InitColor;

    private void Awake()
    {
        m_Icon = GetComponent<SpriteRenderer>();
        m_InitColor = m_Icon.color;
    }

    private void Update()
    {
        if (Hold)
            SetIconColor(Color.green);
        else if (Locked)
            SetIconColor(Color.red);
        else
            SetIconColor(m_InitColor);
                
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
