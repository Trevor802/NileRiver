using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int HP = 10;
    private Transform weapon;
    private enum Direction
    {
        left,
        right
    }
    private Direction dir;
    public float swingSpeed;
 
    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.Find("weapon");
        dir = Direction.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon.localPosition.x > -4.87f && dir == Direction.left)
        {
            weapon.localPosition = new Vector3(weapon.localPosition.x - 0.03f, weapon.localPosition.y, weapon.localPosition.z);
        }
        else if (weapon.localPosition.x <= -4.87f && dir == Direction.left)
        {
            dir = Direction.right;
        }
        if (weapon.localPosition.x < - 3.89f && dir == Direction.right)
        {
            weapon.localPosition = new Vector3(weapon.localPosition.x + 0.03f, weapon.localPosition.y, weapon.localPosition.z);
        }
        else if (weapon.localPosition.x >= -3.89f && dir == Direction.right)
        {
            dir = Direction.left;
        }

    }
}
