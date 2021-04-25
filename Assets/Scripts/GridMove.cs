using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GridMove : MonoBehaviour
{
    public Transform moveTarget;
    public float smoothTime = 0.3F;
    public float blockedMoveScalar = .1f;
    public LayerMask blockingLayerMask;

    public UnityEvent OnBlockedMove = new UnityEvent();

    private Vector2 moveInput = Vector2.zero;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {

        moveTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, moveTarget.position, ref velocity, smoothTime);
    }

    public bool Move(Vector2 moveDirection)
    {

        if (Vector3.Distance(transform.position, moveTarget.position) <= 0.1f)
        {
            if (Mathf.Abs(moveDirection.x) == 1f)
            {
                Vector3 newPosition = moveTarget.position + new Vector3(moveDirection.x, 0f, 0f);

                if (!Physics2D.OverlapPoint(newPosition, blockingLayerMask))
                {
                    moveTarget.position = newPosition;
                    return true;
                }
                else
                {
                    newPosition = moveTarget.position + new Vector3(moveDirection.x * blockedMoveScalar, 0f, 0f);
                    transform.position = newPosition;
                    OnBlockedMove.Invoke();
                    return false;
                }

            }
            else if (Mathf.Abs(moveDirection.y) == 1f)
            {

                Vector3 newPosition = moveTarget.position + new Vector3(0f, moveDirection.y, 0f);

                if (!Physics2D.OverlapPoint(newPosition, blockingLayerMask))
                {
                    moveTarget.position = newPosition;
                    return true;
                }
                else
                {
                    newPosition = moveTarget.position + new Vector3(0f, moveDirection.y * blockedMoveScalar, 0f);
                    transform.position = newPosition;
                    OnBlockedMove.Invoke();
                    return false;
                }
            }
        }

        return true;
    }
}
