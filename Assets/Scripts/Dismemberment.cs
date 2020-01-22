using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dismemberment : MonoBehaviour
{
    public bool headCut;
    public bool rightArmCut;
    public bool leftArmCut;
    public bool rightLegCut;
    public bool leftLegCut;

    public GameObject rightArm;
    //public Rigidbody2D rightArm_rigid;
    public GameObject rightArm_hand;
    private bool rightArm_flew;

    public GameObject leftArm;
    //public Rigidbody2D leftArm_rigid;
    public GameObject leftArm_hand;
    private bool leftArm_flew;

    public GameObject rightLeg;
    //public Rigidbody2D rightLeg_rigid;
    public GameObject rightLeg_foot;
    private bool rightLeg_flew;

    public GameObject leftLeg;
    //public Rigidbody2D leftLeg_rigid;
    public GameObject leftLeg_foot;
    private bool leftLeg_flew;

    public GameObject head;
    //public Rigidbody2D headRigid;
    //public Rigidbody2D head_rigid;
    private bool head_flew;


    private Quaternion targetRotation;
    private float duration = 0f;
    private float thrust = 3f;

    void Start()
    {
        //rightLeg_rigid.IsSleeping();
        //Debug.Log(head.GetComponent<Rigidbody2D>());
    }
    void Update()
    {
        if (headCut == true && head_flew == false)
        {
            if (head.GetComponent<Rigidbody2D>())
            {
                head.transform.parent = null;

                head.GetComponent<HingeJoint2D>().enabled = false;

                head.GetComponent<Rigidbody2D>().gravityScale = 0.7f;

                head.GetComponent<Rigidbody2D>().AddForce(head.transform.up * thrust, ForceMode2D.Impulse);

                head_flew = true;
            }
            else
            {
                head.transform.parent = null;

                Rigidbody2D head_rigid = head.AddComponent<Rigidbody2D>();
                head_rigid.gravityScale = 0.7f;

                head_rigid.simulated = true;
                head_rigid.AddForce(head.transform.up * thrust, ForceMode2D.Impulse);

                head_flew = true;
            }
        }

        if (rightArmCut == true && rightArm_flew == false)
        {
            if (rightArm.GetComponent<Rigidbody2D>())
            {
                rightArm.transform.parent = null;

                rightArm.GetComponent<HingeJoint2D>().enabled = false;

                rightArm.GetComponent<Rigidbody2D>().gravityScale = 0.7f;

                rightArm.GetComponent<Rigidbody2D>().AddForce(head.transform.up * thrust, ForceMode2D.Impulse);

                rightArm_flew = true;
            }
            else
            {
                rightArm.transform.parent = null;

                Rigidbody2D rightArm_rigid = rightArm.AddComponent<Rigidbody2D>();
                rightArm_rigid.gravityScale = 0.7f;

                rightArm_rigid.simulated = true;
                rightArm_rigid.AddForce(rightArm.transform.up * thrust, ForceMode2D.Impulse);
                //rightArm_hand.SetActive(false);

                rightArm_flew = true;
            }
        }

        if (leftArmCut == true && leftArm_flew == false)
        {
            if (leftArm.GetComponent<Rigidbody2D>())
            {
                leftArm.transform.parent = null;

                leftArm.GetComponent<HingeJoint2D>().enabled = false;

                leftArm.GetComponent<Rigidbody2D>().gravityScale = 0.7f;

                leftArm.GetComponent<Rigidbody2D>().AddForce(head.transform.up * thrust, ForceMode2D.Impulse);

                leftArm_flew = true;
            }
            else
            {
                leftArm.transform.parent = null;

                Rigidbody2D leftArm_rigid = leftArm.AddComponent<Rigidbody2D>();
                leftArm_rigid.gravityScale = 0.7f;

                leftArm_rigid.simulated = true;
                leftArm_rigid.AddForce(leftArm.transform.up * thrust, ForceMode2D.Impulse);
                //leftArm_hand.SetActive(false);

                leftArm_flew = true;
            } 
        }

        if(rightLegCut == true && rightLeg_flew == false)
        {
            if (rightLeg.GetComponent<Rigidbody2D>())
            {
                rightLeg.transform.parent = null;

                rightLeg.GetComponent<HingeJoint2D>().enabled = false;

                rightLeg.GetComponent<Rigidbody2D>().gravityScale = 0.7f;

                rightLeg.GetComponent<Rigidbody2D>().AddForce(head.transform.up * thrust, ForceMode2D.Impulse);

                rightLeg_flew = true;
            }
            else
            {
                rightLeg.transform.parent = null;

                Rigidbody2D rightLeg_rigid = rightLeg.AddComponent<Rigidbody2D>();
                rightLeg_rigid.gravityScale = 0.7f;

                rightLeg_rigid.simulated = true;
                rightLeg_rigid.AddForce(rightLeg.transform.up * thrust, ForceMode2D.Impulse);
                //rightLeg_foot.SetActive(false);

                rightLeg_flew = true;
            }
        }
        
        if(leftLegCut == true && leftLeg_flew == false)
        {
            if (leftLeg.GetComponent<Rigidbody2D>())
            {
                leftLeg.transform.parent = null;

                leftLeg.GetComponent<HingeJoint2D>().enabled = false;

                leftLeg.GetComponent<Rigidbody2D>().gravityScale = 0.7f;

                leftLeg.GetComponent<Rigidbody2D>().AddForce(head.transform.up * thrust, ForceMode2D.Impulse);

                leftLeg_flew = true;
            }
            else
            {
                leftLeg.transform.parent = null;

                Rigidbody2D leftLeg_rigid = leftLeg.AddComponent<Rigidbody2D>();
                leftLeg_rigid.gravityScale = 0.7f;

                leftLeg_rigid.simulated = true;
                leftLeg_rigid.AddForce(leftLeg.transform.up * thrust, ForceMode2D.Impulse);
                //leftLeg_foot.SetActive(false);

                leftLeg_flew = true;
            }
        }
        
    }
}
