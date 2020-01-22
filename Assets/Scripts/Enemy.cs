using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private int HP = 10;
    //public Transform weapon;
    //private float delay = 0f;
    public Animator animator;
    private enum Direction
    {
        left,
        right
    }
    private Direction dir;
    //public float swingSpeed;
 
    // Start is called before the first frame update
    void Start()
    {
        //weapon = transform.Find("weapon");
        dir = Direction.left;
    }

    /*
    void Update()
    {
        
        //print(Time.deltaTime);
        delay += Time.deltaTime;
        //if (weapon.localPosition.x > 2.2f && dir == Direction.left)
        if(delay < 0.5f && dir == Direction.left)
        {
            weapon.localPosition = new Vector3(weapon.localPosition.x - 0.03f, weapon.localPosition.y, weapon.localPosition.z);
        }
        //else if (weapon.localPosition.x <= 2.2f && dir == Direction.left)
        else if(delay >= 0.5 && dir == Direction.left)
        {
            dir = Direction.right;
            delay = 0f;
        }
        //if (weapon.localPosition.x < 1.31f && dir == Direction.right)
        if (delay < 0.5f && dir == Direction.right)
        {
            weapon.localPosition = new Vector3(weapon.localPosition.x + 0.03f, weapon.localPosition.y, weapon.localPosition.z);
        }
        //else if (weapon.localPosition.x >= 1.31f && dir == Direction.right)
        else if(delay >= 0.5 && dir == Direction.right)
        {
            dir = Direction.left;
            delay = 0f;
        }

    }
    */
    public void throwAnimationEnded()
    {
        animator.SetBool("Throw", false);
    }
}
