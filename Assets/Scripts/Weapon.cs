using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isEnemyWeapon;
    //public Health health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health collider_health = collision.GetComponentInParent<Health>();
        //Debug.Log(collision.name);
        if (collider_health)
        {
            Debug.Log("Has health");
            if(isEnemyWeapon && !collider_health.isEnemy)
            {
                Debug.Log("enemy damage player");
                collider_health.GetDamage(collision);
            }
            else if(!isEnemyWeapon && collider_health.isEnemy)
            {
                Debug.Log("player damage enemy");
                collider_health.GetDamage(collision);
            }
        }
    }
}
