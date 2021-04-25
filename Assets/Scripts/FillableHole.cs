using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillableHole : MonoBehaviour
{
    public Collider2D collider;
    public bool filled;
    public LayerMask fillsWithLayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && ((1 << other.gameObject.layer) & fillsWithLayer) != 0)
        {
            //It matched one
            if (other.TryGetComponent<Droppable>(out var droppable))
            {
                StartCoroutine("Fill", droppable);
            }
        }

    }

    public IEnumerator Fill(Droppable droppable)
    {
        yield return new WaitForSeconds(0.5f);
        droppable.Drop();
        filled = true;
        collider.enabled = false;
    }
}
