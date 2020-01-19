using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject m_Player;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        Camera.main.transform.position += new Vector3(
            m_Player.transform.position.x - Camera.main.transform.position.x,
            0, 0);
    }
}
