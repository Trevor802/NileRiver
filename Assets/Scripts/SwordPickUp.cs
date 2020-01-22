using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUp : MonoBehaviour
{
    public CircleCollider2D rightHand;
    public CircleCollider2D leftHand;
    public CircleCollider2D rightFoot;
    public CircleCollider2D leftFoot;

    public SlotAvailability rightHandSlot;
    public SlotAvailability leftHandSlot;
    public SlotAvailability rightFootSlot;
    public SlotAvailability leftFootSlot;

    public GameObject rightHandSword;
    public GameObject leftHandSword;
    public GameObject rightFootSword;
    public GameObject leftFootSword;

    public GameObject sword;

    public WeaponSound weaponSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        weaponSound.PlayWeaponPickUpSound();
        //print("on enter");
        if(collision == rightHand && rightHandSlot.hasWeapon == false)
        {
            rightHandSword.SetActive(true);
            sword.SetActive(false);
            rightHandSlot.hasWeapon = true;
        }
        else if(collision == leftHand && leftHandSlot.hasWeapon == false)
        {
            leftHandSword.SetActive(true);
            sword.SetActive(false);
            leftHandSlot.hasWeapon = true;
        }
        else if(collision == rightFoot && rightFootSlot.hasWeapon == false)
        {
            rightFootSword.SetActive(true);
            sword.SetActive(false);
            rightFootSlot.hasWeapon = true;
        }
        else if(collision == leftFoot && leftFootSlot.hasWeapon == false)
        {
            leftFootSword.SetActive(true);
            sword.SetActive(false);
            leftFootSlot.hasWeapon = true;
        }
    }
}
