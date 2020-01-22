using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    public AudioSource weaponAudio;
    public AudioClip weaponPickUpSound;
    public AudioClip weaponHitSound;

    public void PlayWeaponPickUpSound()
    {
        weaponAudio.PlayOneShot(weaponPickUpSound);
    }

    public void PlayWeaponHitSound()
    {
        weaponAudio.PlayOneShot(weaponHitSound);
    }
}
