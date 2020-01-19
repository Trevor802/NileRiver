using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    public KeyCode InputButton;
    public Friction ForcePoint;

    private RigidbodyConstraints2D m_InitConstraints;

    private void Awake()
    {
        if (!ForcePoint)
        {
            ForcePoint = GetComponentInChildren<Friction>();
        }
        m_InitConstraints = GetComponent<Rigidbody2D>().constraints;
    }

    private void Update()
    {
        AddForce();
    }

    private void AddForce()
    {
        var rb = GetComponent<Rigidbody2D>();
        var force = rb.mass * Time.deltaTime * 5000;
        if (Input.GetKeyDown(InputButton))
            ForcePoint.Hold = true;
        if (Input.GetKeyUp(InputButton))
            ForcePoint.Hold = false;
        if (Input.GetKey(InputButton))
        {
            rb.constraints = m_InitConstraints;
            var dir = new Vector2(Input.GetAxis("LeftHandH"), Input.GetAxis("LeftHandV")).normalized;
            rb.AddForceAtPosition(force * dir, ForcePoint.transform.position);
        }
        else if (ForcePoint.Locked)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
}
