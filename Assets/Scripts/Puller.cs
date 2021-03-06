﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    public KeyCode InputButton;
    public Friction ForcePoint;
    public char input1;
    public char input2;
    public Transform player;
    public Transform joint1;
    public Transform joint2;
    public Transform joint3;
    public bool isLeft;
    public bool isFoot = false;

    private RigidbodyConstraints2D m_InitConstraints;
    private float a1;
    private float a2;
    private float l1;
    private float l2;
    private Rigidbody2D rb;
    private float force;
    private Vector3 destination;
    private Vector3 localDir;
    private bool InputDelay = false;
    private float InputStartTime;

    private void Awake()
    {
        if (!ForcePoint)
        {
            ForcePoint = GetComponentInChildren<Friction>();
        }
        rb = GetComponent<Rigidbody2D>();
        m_InitConstraints = GetComponent<Rigidbody2D>().constraints;
        force = rb.mass * Time.deltaTime * 3000;
        var Vec1 = joint2.position - joint1.position;
        var Vec2 = joint3.position - joint2.position;
        l1 = Vec1.magnitude;
        l2 = Vec2.magnitude;
    }

    private void Update()
    {
        if (ArduinoProcess.instance.InputAChange())
        {
            InputForce('A');
        }
        else if (ArduinoProcess.instance.InputBChange())
        {
            InputForce('B');
        }
        else if (ArduinoProcess.instance.InputCChange())
        {
            InputForce('C');
        }
        else if (ArduinoProcess.instance.InputDChange())
        {
            InputForce('D');
        }
        else if (ArduinoProcess.instance.InputEChange())
        {
            InputForce('E');
        }
        else if (ArduinoProcess.instance.InputFChange())
        {
            InputForce('F');
        }
        if (InputDelay)
        {
            rb.AddForceAtPosition(force * localDir, ForcePoint.transform.position);
            if (Time.time - InputStartTime >= 1)
            {
                InputDelay = false;
                ForcePoint.Hold = false;
            }
        }
        AddForce();
    }

    private void AddForce()
    {
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

    private void InputForce(char inputChar)
    {
        if (input1 == inputChar || input2 == inputChar)
        {
            ForcePoint.Hold = true;
            InputStartTime = Time.time;
            InputDelay = true;
            rb.constraints = m_InitConstraints;
            var angle1 = ArduinoProcess.instance.GetDegree(input1) * 1.5f;
            var angle2 = ArduinoProcess.instance.GetDegree(input2);
            var alpha = -angle1;
            var beta = alpha + angle2;
            destination = new Vector3(joint1.position.x + l1 * Mathf.Cos(alpha * Mathf.Deg2Rad) + l2 * Mathf.Cos(beta * Mathf.Deg2Rad),
                joint1.position.y + l1 * Mathf.Sin(alpha * Mathf.Deg2Rad) + l2 * Mathf.Sin(beta * Mathf.Deg2Rad), 0);
            localDir = destination - joint1.position;
            if (ForcePoint.Locked)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }                                                                                                                                                                                                                                                                                                   
        }
    }
}
