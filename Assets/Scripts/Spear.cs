using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public GameObject spearHead;
    //public GameObject Enemy;

    public Rigidbody2D spearHeadRigid;
    public Rigidbody2D spearTailRigid;
    public Transform spearHeadTransform;

    public SpriteRenderer enemySpear;
    public BoxCollider2D enemySpearCollider;

    public SpriteRenderer throwSpearHead;
    public SpriteRenderer throwSpearTail;

    public Animator animator;

    private float thrust = 35f;
    private Transform originalTransform;
    private Vector3 position;
    private Quaternion rotation;
    private bool throwed;
    // Start is called before the first frame update
    void Start()
    {
        throwed = false;
        animator.SetBool("Throw", true);
        spearHead.transform.parent = null;
        position = spearHeadTransform.position;
        rotation = spearHeadTransform.rotation;
        spearHead.GetComponent<PolygonCollider2D>().enabled = false;
        throwSpearHead.enabled = false;
        throwSpearTail.enabled = false;
        enemySpearCollider.enabled = true;
        /*
        //originalTransform = arrowHeadTransform;

        //shoots arrow
        spearTailRigid.bodyType = RigidbodyType2D.Dynamic;
        spearTailRigid.gravityScale = 0.5f;

        spearHeadRigid.bodyType = RigidbodyType2D.Dynamic;
        spearHeadRigid.gravityScale = 0.7f;
        spearHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        */
    }

    void Update()
    {
        if(animator.GetBool("Throw") == false && throwed == false)
        {
            enemySpearCollider.enabled = false;
            throwed = true;
            enemySpear.enabled = false;

            throwSpearHead.enabled = true;
            throwSpearTail.enabled = true;

            spearHeadRigid.bodyType = RigidbodyType2D.Static;
            spearTailRigid.bodyType = RigidbodyType2D.Static;

            spearHeadTransform.position = position;
            spearHeadTransform.rotation = rotation;

            

            //shoots arrow
            spearTailRigid.bodyType = RigidbodyType2D.Dynamic;
            spearTailRigid.gravityScale = 0.4f;

            spearHeadRigid.bodyType = RigidbodyType2D.Dynamic;
            spearHeadRigid.gravityScale = 0.8f;
            spearHeadRigid.AddForce(transform.right * thrust, ForceMode2D.Impulse);

            spearHead.GetComponent<PolygonCollider2D>().enabled = true;
        }
        else if(animator.GetBool("Throw") == true && throwed == true)
        {
            enemySpearCollider.enabled = true;
            enemySpear.enabled = true;
            throwed = false;
            spearHead.GetComponent<PolygonCollider2D>().enabled = false;
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
