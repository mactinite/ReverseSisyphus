using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    public Transform moveTarget;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public LayerMask blockingLayerMask;

    private Vector2  moveInput = Vector2.zero;

    private void Start() {

        moveTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, moveTarget.position, ref velocity, smoothTime);
    }

    public bool Move(Vector2 moveDirection){

        if(Vector3.Distance(transform.position, moveTarget.position) <= 0.1f) {
            if(Mathf.Abs(moveDirection.x) == 1f){
                Vector3 newPosition = moveTarget.position + new Vector3(moveDirection.x, 0f, 0f);

                if(!Physics2D.OverlapPoint(newPosition, blockingLayerMask)){
                    moveTarget.position = newPosition;
                    return true;
                } else {
                    newPosition = moveTarget.position + new Vector3(moveDirection.x / 2, 0f, 0f);
                    transform.position = newPosition ;
                    return false;
                }

            } else if (Mathf.Abs(moveDirection.y) == 1f) {

                Vector3 newPosition = moveTarget.position + new Vector3(0f, moveDirection.y, 0f);

                if(!Physics2D.OverlapPoint(newPosition, blockingLayerMask)){
                    moveTarget.position = newPosition;
                    return true;
                } else {
                    newPosition = moveTarget.position + new Vector3(0f, moveDirection.y / 2, 0f);
                    transform.position = newPosition;
                    return false;
                }
            }
        }

        return true;
    }
}
