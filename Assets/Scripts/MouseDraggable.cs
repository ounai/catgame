using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDraggable : MonoBehaviour {
    private Vector2 mousePos;
    private bool isPicked;

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            isPicked = false;
        }

        if (isPicked){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    void OnMouseDown(){
        isPicked = true;
    }
}
