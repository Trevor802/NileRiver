using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public List<Collider2D> colliders;
    public float invulnerableTime;
    public GameObject gameOver;
    public Dismemberment dismemberment;
    public Rigidbody2D rigid;

    public BoxCollider2D rightUpperArm;
    public BoxCollider2D leftUpperArm;
    public BoxCollider2D rightUpperLeg;
    public BoxCollider2D leftUpperLeg;
    
    public float health;
    public bool isEnemy;
    [SerializeField] private bool isDead;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        //health = 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (health <= 0f && !isEnemy)
        {
            health = 0;
            Dead = true;
            Dying();
        }
    }
    public void GetDamage(Collider2D i_collider)
    {
        if (timer > 0f)
            return;
        bool colliderNotContained = true;
        foreach(Collider2D collider in colliders)
        {
            if(i_collider == collider)
            {
                Debug.Log(collider.name);
                colliderNotContained = false;
            }
        }
        if (colliderNotContained)
            return;

        float dmg = 0;


        if(i_collider.GetType() == typeof(PolygonCollider2D))
        {
            dmg = 30;
            if (i_collider.CompareTag("Head"))
            {
                dmg = 10000;
            }
            health -= dmg;
            if(health <= 0)
            {
                Debug.Log("Enemy dead");
                //if (isEnemy)
                //{
                //    if (rigid)
                //    {
                //        rigid.bodyType = RigidbodyType2D.Dynamic;
                //    }
                //}
                //if (i_collider == rightUpperArm)
                //{
                //    dismemberment.rightArmCut = true;
                //}
                //else if (i_collider == leftUpperArm)
                //{
                //    dismemberment.leftArmCut = true;
                //}
                //else if (i_collider == rightUpperLeg)
                //{
                //    dismemberment.rightLegCut = true;
                //}
                //else if (i_collider == leftUpperLeg)
                //{
                //    dismemberment.leftLegCut = true;
                //}
            }
        }
        //else if(i_collider.GetType() == typeof(CircleCollider2D))
        //{
        //    dmg = 10000;
        //    //dismemberment.headCut = true;
        //    health -= dmg;
        //}
        //health -= dmg;
        timer = invulnerableTime;
        //Debug.Log("Player get " + dmg + " damage");
        
    }

    public bool Dead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
        }
    }

    void Dying()
    {
        gameOver.GetComponent<UIFadeIO>().StartFadeIn();
        Debug.Log("Game Over");
    }
}
