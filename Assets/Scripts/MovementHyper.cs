using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHyper : MonoBehaviour {
    public float multiplier = 1f;

    private Vector2 lastPosition;

    void Start() {
        lastPosition = transform.position;
    }

    void Update() {
        float moveDistance = (lastPosition - (Vector2) transform.position).magnitude;

        if (moveDistance >= 0.01f) {
            HypeEvent hypeEvent = new HypeEvent(HypeEventType.TOY_MOVEMENT, moveDistance * multiplier);

            FindObjectOfType<HypeMeter>().GetComponent<HypeMeter>().RegisterHypeEvent(hypeEvent);
        }
        
        lastPosition = transform.position;
    }
}
