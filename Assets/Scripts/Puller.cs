using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    public KeyCode InputButton;
    public char angle1;
    public char angle2;
    public Friction ForcePoint;
    public Transform joint1;
    public Transform joint2;
    public Transform joint3;
    public bool isFoot = false;

    private RigidbodyConstraints2D m_InitConstraints;
    private float a1;
    private float a2;

    private void Awake()
    {
        if (!ForcePoint)
        {
            ForcePoint = GetComponentInChildren<Friction>();
        }
        m_InitConstraints = GetComponent<Rigidbody2D>().constraints;
        var Vec1 = joint2.position - joint1.position;
        var Vec2 = joint3.position - joint2.position;
        if (isFoot)
        {
            a1 = Vector3.Angle(Vec1, new Vector3(1, 0, 0));
            a2 = Vector3.Angle(Vec2, new Vector3(1, 0, 0));
        }
        else
        {
            a1 = Vector3.Angle(Vec1, new Vector3(0, -1, 0));
            a2 = Vector3.Angle(Vec2, new Vector3(0, -1, 0));
        }
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
