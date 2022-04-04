using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour {

    public GameObject catTail;
    public GameObject catPaw;
    public GameObject hypeMeter;
    public GameObject hypedFelixFace;
    public GameObject boredFelixFace;

    private float rotationAmount;

    private enum RotationDirection { LEFT, RIGHT };
    private RotationDirection tailRotationDirection;
    private RotationDirection pawRotationDirection;

    private void EnsureRotationBounds(ref RotationDirection direction, Transform transform, float min, float max) {
        if (direction == RotationDirection.RIGHT) {
            if (transform.rotation.z >= max) direction = RotationDirection.LEFT;
        } else {
            if (transform.rotation.z <= min) direction = RotationDirection.RIGHT;
        }
    }

    private void RotateTransform(Transform transform, RotationDirection direction, float amount) {
        if (direction == RotationDirection.LEFT) {
            transform.Rotate(0, 0, -amount * Time.deltaTime);
        } else {
            transform.Rotate(0, 0, amount * Time.deltaTime);
        }
    }

    private void MoveRotatableTransform(ref RotationDirection direction, Transform transform, float rotationAmount, float minRotationAngle, float maxRotationAngle) {
        EnsureRotationBounds(ref direction, transform, minRotationAngle, maxRotationAngle);
        RotateTransform(transform, direction, rotationAmount);
    }

    void SetRotationAmount() {
        float currentHype = hypeMeter.GetComponent<HypeMeter>().GetCurrentHype();

        if(currentHype >= 70f) {
            rotationAmount = 200f;
            hypedFelixFace.SetActive(true);
        } else if (currentHype >= 50f) {
            rotationAmount = 70f;
            hypedFelixFace.SetActive(false);
        } else if (currentHype >= 30f) {
            rotationAmount = 35f;
            hypedFelixFace.SetActive(false);
        } else if (currentHype >= 20f) {
            rotationAmount = 20f;
            hypedFelixFace.SetActive(false);
        } else if (currentHype <= 30f) {
            boredFelixFace.SetActive(true);
        }
    }

    void Start() {
        tailRotationDirection = RotationDirection.RIGHT;
        pawRotationDirection = RotationDirection.LEFT;
    }

    void Update() {
        SetRotationAmount();

        MoveRotatableTransform(ref tailRotationDirection, catTail.transform, rotationAmount, -0.5f, 0.174f);
        MoveRotatableTransform(ref pawRotationDirection, catPaw.transform, rotationAmount, -0.4f, 0f);

        Debug.Log($"Hype: {hypeMeter.GetComponent<HypeMeter>().GetCurrentHype()}");
    }
}
