using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject RightLeg;
    public GameObject LeftLeg;
    public GameObject LeftHand;
    public GameObject RightHand;

    public float MaxLegRotationAngle = 60;
    public float MaxHandRange = 1;
    public float MaxFeetRange = 1;

    private float m_DefaultLeftLegAngle;
    private float m_DefaultRightLegAngle;
    private float m_DefaultLeftArmAngle;
    private float m_DefaultRightArmAngle;
    private Vector3 m_DefaultLeftHandPos;
    private Vector3 m_DefaultRightHandPos;
    private Vector3 m_DefaultLeftFeetPos;
    private Vector3 m_DefaultRightFeetPos;

    private const float m_MinAxisValue = -1f;
    private const float m_MaxAxisValue = 1f;
    private const float m_AxisAmpReciprocal = 1 / (m_MaxAxisValue - m_MinAxisValue);
    // Start is called before the first frame update
    void Start()
    {
        m_DefaultLeftLegAngle = LeftLeg.transform.localEulerAngles.z;
        m_DefaultRightLegAngle = RightLeg.transform.localEulerAngles.z;
        m_DefaultLeftArmAngle = LeftHand.transform.localEulerAngles.z;
        m_DefaultRightArmAngle = RightHand.transform.localEulerAngles.z;
        m_DefaultLeftFeetPos = LeftLeg.transform.localPosition;
        m_DefaultRightFeetPos = RightLeg.transform.localPosition;
        m_DefaultLeftHandPos = LeftHand.transform.localPosition;
        m_DefaultRightHandPos = RightHand.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float leftLegPect = (Input.GetAxis("LeftLeg") - m_MinAxisValue) * m_AxisAmpReciprocal;
        float rightLegPect = (Input.GetAxis("RightLeg") - m_MinAxisValue) * m_AxisAmpReciprocal;
        //LeftLeg.transform.localEulerAngles = new Vector3(0, 0, m_DefaultLeftLegAngle - leftLegPect * MaxLegRotationAngle);
        //RightLeg.transform.localEulerAngles = new Vector3(0, 0, m_DefaultRightLegAngle + rightLegPect * MaxLegRotationAngle);
        LeftHand.transform.localEulerAngles = new Vector3(0, 0, m_DefaultLeftArmAngle + Input.GetAxis("LeftLeg") * m_AxisAmpReciprocal * MaxLegRotationAngle);
        RightHand.transform.localEulerAngles = new Vector3(0, 0, m_DefaultRightArmAngle - Input.GetAxis("RightLeg") * m_AxisAmpReciprocal * MaxLegRotationAngle);
        //LeftLeg.transform.localPosition = m_DefaultLeftFeetPos + new Vector3(0, leftLegPect * MaxFeetRange);
        //RightLeg.transform.localPosition = m_DefaultRightFeetPos + new Vector3(0, rightLegPect * MaxFeetRange);

        //LeftHand.transform.localPosition = new Vector3(
        //    m_DefaultLeftHandPos.x + ((Input.GetAxis("LeftHandH") - m_MinAxisValue) * m_AxisAmpReciprocal) * MaxHandRange,
        //    m_DefaultLeftHandPos.y + ((Input.GetAxis("LeftHandV")) * m_AxisAmpReciprocal) * MaxHandRange);
        //RightHand.transform.localPosition = new Vector3(
        //    m_DefaultRightHandPos.x + (Input.GetAxis("RightHandH") + m_MinAxisValue) * m_AxisAmpReciprocal * MaxHandRange,
        //    m_DefaultRightHandPos.y + ((Input.GetAxis("RightHandV")) * m_AxisAmpReciprocal) * MaxHandRange);
        LeftLeg.transform.localPosition = new Vector3(
            m_DefaultLeftFeetPos.x + (Input.GetAxis("LeftHandH") * m_AxisAmpReciprocal * MaxFeetRange),
            m_DefaultLeftFeetPos.y + ((Input.GetAxis("LeftHandV") - m_MinAxisValue) * m_AxisAmpReciprocal * MaxFeetRange));
        RightLeg.transform.localPosition = new Vector3(
            m_DefaultRightFeetPos.x + (Input.GetAxis("RightHandH") * m_AxisAmpReciprocal * MaxFeetRange),
            m_DefaultRightFeetPos.y + ((Input.GetAxis("RightHandV") - m_MinAxisValue) * m_AxisAmpReciprocal * MaxFeetRange));
    }
}
