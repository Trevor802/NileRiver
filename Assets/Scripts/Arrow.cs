using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D arrowHeadRigid;
    public Rigidbody2D arrowTailRigid;
    public Transform arrowHeadTransform;

    private float thrust = -25f;
    private Transform originalTransform;
    private Vector3 position;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        //originalTransform = arrowHeadTransform;
        position = arrowHeadTransform.position;
        rotation = arrowHeadTransform.rotation;

        //shoots arrow
        arrowTailRigid.bodyType = RigidbodyType2D.Dynamic;
        arrowTailRigid.gravityScale = 0.5f;

        arrowHeadRigid.bodyType = RigidbodyType2D.Dynamic;
        arrowHeadRigid.gravityScale = 0.7f;
        arrowHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        arrowHeadRigid.bodyType = RigidbodyType2D.Static;
        arrowTailRigid.bodyType = RigidbodyType2D.Static;

        arrowHeadTransform.position = position;
        arrowHeadTransform.rotation = rotation;

        //shoots arrow
        arrowTailRigid.bodyType = RigidbodyType2D.Dynamic;
        arrowTailRigid.gravityScale = 0.5f;

        arrowHeadRigid.bodyType = RigidbodyType2D.Dynamic;
        arrowHeadRigid.gravityScale = 0.7f;
        arrowHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }

}
