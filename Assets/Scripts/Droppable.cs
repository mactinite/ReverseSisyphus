using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Droppable : MonoBehaviour
{
    public Sprite filledSprite;
    public SpriteRenderer spriteRenderer;
    public Collider2D collider;
    public UnityEvent OnDrop = new UnityEvent();
    public void Drop()
    {
        spriteRenderer.sprite = filledSprite;
        collider.enabled = false;
        spriteRenderer.sortingOrder = 0;
        OnDrop.Invoke();
    }
}
