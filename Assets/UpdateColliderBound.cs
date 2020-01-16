using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider2D))]
public class UpdateColliderBound : MonoBehaviour
{
    private void Awake()
    {
        runInEditMode = true;
    }

    private void Update()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        var collider = GetComponent<BoxCollider2D>();
        collider.offset = new Vector2(0, 0);
        collider.size = new Vector3(
            spriteRender.bounds.size.x / transform.lossyScale.x,
            spriteRender.bounds.size.y / transform.lossyScale.y,
            spriteRender.bounds.size.z / transform.lossyScale.z);
    }
}
