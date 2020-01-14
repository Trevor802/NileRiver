using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Camera thisCam;

    private void Start()
    {
        thisCam = GetComponent<Camera>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit.collider.name);
            
        }
    }
}
