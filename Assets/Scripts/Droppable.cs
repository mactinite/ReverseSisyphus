using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour
{
    public Sprite filledSprite;
    public SpriteRenderer spriteRenderer;
    public Collider2D collider;

    public void Drop()
    {
        spriteRenderer.sprite = filledSprite;
        collider.enabled = false;

    }
}
