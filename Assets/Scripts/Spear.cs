using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Rigidbody2D spearHeadRigid;
    public Rigidbody2D spearTailRigid;
    public Transform spearHeadTransform;

    public SpriteRenderer enemySpear;

    public SpriteRenderer throwSpearHead;
    public SpriteRenderer throwSpearTail;

    public Animator animator;

    private float thrust = -25f;
    private Transform originalTransform;
    private Vector3 position;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Throw", true);
        //originalTransform = arrowHeadTransform;
        position = spearHeadTransform.position;
        rotation = spearHeadTransform.rotation;

        //shoots arrow
        spearTailRigid.bodyType = RigidbodyType2D.Dynamic;
        spearTailRigid.gravityScale = 0.5f;

        spearHeadRigid.bodyType = RigidbodyType2D.Dynamic;
        spearHeadRigid.gravityScale = 0.7f;
        spearHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }

    void Update()
    {
        if(animator.GetBool("Throw") == false)
        {
            enemySpear.enabled = false;

            throwSpearHead.enabled = true;
            throwSpearTail.enabled = true;

            spearHeadRigid.bodyType = RigidbodyType2D.Static;
            spearTailRigid.bodyType = RigidbodyType2D.Static;

            spearHeadTransform.position = position;
            spearHeadTransform.rotation = rotation;

            //shoots arrow
            spearTailRigid.bodyType = RigidbodyType2D.Dynamic;
            spearTailRigid.gravityScale = 0.5f;

            spearHeadRigid.bodyType = RigidbodyType2D.Dynamic;
            spearHeadRigid.gravityScale = 0.7f;
            spearHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        }
        else
        {
            enemySpear.enabled = true;

            throwSpearHead.enabled = false;
            throwSpearTail.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Throw", true);
        /*
        spearHeadRigid.bodyType = RigidbodyType2D.Static;
        spearTailRigid.bodyType = RigidbodyType2D.Static;

        spearHeadTransform.position = position;
        spearHeadTransform.rotation = rotation;

        //shoots arrow
        spearTailRigid.bodyType = RigidbodyType2D.Dynamic;
        spearTailRigid.gravityScale = 0.5f;

        spearHeadRigid.bodyType = RigidbodyType2D.Dynamic;
        spearHeadRigid.gravityScale = 0.7f;
        spearHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        */
    }

    public void throwAnimationEnded()
    {
        animator.SetBool("Throw", false);
    }

}
