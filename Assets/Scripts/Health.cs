using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public List<Collider2D> colliders;
    public float invulnerableTime;
    public GameObject gameOver;
    public Dismemberment dismemberment;
    public Rigidbody2D rigid;

    public PolygonCollider2D rightUpperArm;
    public PolygonCollider2D leftUpperArm;
    public PolygonCollider2D rightUpperLeg;
    public PolygonCollider2D leftUpperLeg;

    public EnemySound enemySound;
    public WeaponSound weaponSound;

    public LayerMask deadLayer;
    
    public float health;
    public GameObject healthBar;
    public bool isEnemy;
    public bool isDead;
    private float timer;
    private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
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
                //Debug.Log(collider.name);
                colliderNotContained = false;
            }
        }
        if (colliderNotContained)
            return;

        float dmg = 0;


        if(i_collider.GetType() == typeof(PolygonCollider2D))
        {
            weaponSound.PlayWeaponHitSound();
            dmg = 30;
            if (i_collider.CompareTag("Head"))
            {
                dismemberment.headCut = true;
                dmg = 10000;
            }
            Debug.Log("Hit!");
            health -= dmg;
            if (this.CompareTag("Player"))
                healthBar.GetComponentInChildren<Slider>().value = health / maxHealth;
            if (isEnemy && health > 0)
            {
                enemySound.playHurtSound();
            }
            if (health <= 0)
            {
                //Debug.Log("Enemy dead");
                if (isEnemy && !isDead)
                {
                    enemySound.playDeadSound();
                    GetComponent<Animator>().enabled = false;
                    Debug.Log("---------------------------------");
                    foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
                    {
                        collider.gameObject.layer = 15;
                    }
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<WinFailEvent>().EnemyKilledEvt();
                    if (rigid)
                    {
                        rigid.bodyType = RigidbodyType2D.Dynamic;
                    }
                }
                else if(!isEnemy && isDead)
                {
                    StartCoroutine("PlayGameOver");
                    //GameObject.FindGameObjectWithTag("GameManager").GetComponent<WinFailEvent>().GameOverScreen();
                }

                if (i_collider == rightUpperArm)
                {
                    dismemberment.rightArmCut = true;
                }
                else if (i_collider == leftUpperArm)
                {
                    dismemberment.leftArmCut = true;
                }
                else if (i_collider == rightUpperLeg)
                {
                    dismemberment.rightLegCut = true;
                }
                else if (i_collider == leftUpperLeg)
                {
                    dismemberment.leftLegCut = true;
                }
                isDead = true;
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
        //gameOver.GetComponent<UIFadeIO>().StartFadeIn();
        //Debug.Log("Game Over");
    }

    IEnumerator PlayGameOver()
    {
        Debug.Log("Game over ing...");
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<WinFailEvent>().GameOverScreen();
    }
}
