using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    private GridMove gridMove;

    private void Start() {
        gridMove = GetComponent<GridMove>();
    }


    public void Push(Vector2 direction){
        gridMove.Move(direction);
    }
}
