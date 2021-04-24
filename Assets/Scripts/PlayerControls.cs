using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;
    private GridMove gridMove;
    public LayerMask pushableLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        gridMove = GetComponent<GridMove>();
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();

    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    // Update is called once per frame
    public void OnMove(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        if (!gridMove.Move(direction))
        {
            // check the position and apply direction to pushable if there.
            var moveDirection = Mathf.Abs(direction.x) > 0 ? new Vector3(direction.x, 0f, 0f) : new Vector3(0f, direction.y, 0f);
            Vector3 newPosition = gridMove.moveTarget.position + moveDirection;
            var collider = Physics2D.OverlapPoint(newPosition, pushableLayerMask);
            if (collider != null)
            {
                if (collider.TryGetComponent<Pushable>(out var pushable))
                {
                    Debug.Log("Push baby push");
                    pushable.Push(moveDirection);
                }
            }
        }
    }


}
