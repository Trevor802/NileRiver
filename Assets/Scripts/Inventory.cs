using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public CircleCollider2D rightHand;
    public CircleCollider2D leftHand;
    public CircleCollider2D rightFoot;
    public CircleCollider2D leftFoot;

    public GameObject rightHandSword;
    public GameObject leftHandSword;
    public GameObject rightFootSword;
    public GameObject leftFootSword;

    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == rightHand)
        {
            rightHandSword.SetActive(true);
            sword.SetActive(false);
        }
        else if(collision == leftHand)
        {
            leftHandSword.SetActive(true);
            sword.SetActive(false);
        }
        else if(collision == rightFoot)
        {
            rightFootSword.SetActive(true);
            sword.SetActive(false);
        }
        else if(collision == leftFoot)
        {
            leftFootSword.SetActive(true);
            sword.SetActive(false);
        }
    }
}
