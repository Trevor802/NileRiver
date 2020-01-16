using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public List<Collider2D> colliders;
    public float invulnerableTime;
    public GameObject gameOver;
    
    [SerializeField] private float health;
    [SerializeField] private bool isDead;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        health = 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
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


        if(i_collider.GetType() == typeof(BoxCollider2D))
        {
            dmg = 10;
        }
        else if(i_collider.GetType() == typeof(CircleCollider2D))
        {
            dmg = 10000;
        }
        health -= dmg;
        timer = invulnerableTime;
        Debug.Log("Player get " + dmg + " damage");
        if(health <= 0f)
        {
            health = 0;
            Dead = true;
            Dying();
        }
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
