using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDraggable : MonoBehaviour {

    Vector2 mousePos;
    bool isPicked;

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonUp(0)){
            isPicked = false;
        }
        if(isPicked == true){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    void OnMouseDown(){
        isPicked = true;
    }

}
