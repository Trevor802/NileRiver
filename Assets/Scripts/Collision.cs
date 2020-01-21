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
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse click");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.Log(hit.collider.name);
            if(hit.collider)
            {
                if (hit.collider.GetComponentInParent<Health>())
                    hit.collider.GetComponentInParent<Health>().GetDamage(hit.collider);
            }
        }
    }
}
