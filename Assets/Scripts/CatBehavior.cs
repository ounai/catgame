using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour {
    public float speed = 1f;
    public float amplitude = 1f;

    private float time = 0f;
    private Vector3 initialLocation;

    void Start() {
        initialLocation = transform.position;
    }

    void Update() {
        time += Time.deltaTime;

        transform.position = new Vector3(
            initialLocation.x + Mathf.Sin(time * speed) * (time * amplitude),
            initialLocation.y + Mathf.Cos(time * speed) * (time * amplitude),
            initialLocation.z
        );

        transform.Rotate(time / 10f, Mathf.Sqrt(time), 0);
    }
}
