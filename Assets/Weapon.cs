using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isEnemyWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.GetComponentInParent<Health>() && isEnemyWeapon)
            collision.GetComponentInParent<Health>().GetDamage(collision);
    }
}
