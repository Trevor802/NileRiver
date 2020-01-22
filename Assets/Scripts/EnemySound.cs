using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource enemyAudio;
    public AudioClip enemySoundHurt;
    public AudioClip enemySoundDie;

    public void playHurtSound()
    {
        enemyAudio.PlayOneShot(enemySoundHurt);
    }
    public void playDeadSound()
    {
        enemyAudio.PlayOneShot(enemySoundDie);
    }
}
