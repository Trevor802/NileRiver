using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAvailability : MonoBehaviour
{
    public bool hasWeapon = false;
    public bool weaponBroken = false;

    public GameObject weapon;
    private void Update()
    {
        if(weaponBroken == true)
        {
            weapon.SetActive(false);
            weaponBroken = false;
            hasWeapon = false;
        }
    }
    public bool checkSlotAviliability()
    {
        return hasWeapon;
    }

}
