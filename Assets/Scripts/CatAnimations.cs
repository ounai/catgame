using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour
{

    public GameObject catTail;
    public GameObject catPaw;
    public GameObject hypeMeter;
    public GameObject hypedFelixFace;
    public GameObject boredFelixFace;

    private bool rotateTailRight;
    private bool rotatePawRight;

    private float rotationAmount;

    // Start is called before the first frame update
    void Start(){
        rotateTailRight = true;
        rotatePawRight = true;
    }

    void MoveTail(){
        //Debug.Log(catTail.transform.rotation.z);

        if(catTail.transform.rotation.z <= -0.5){
            rotateTailRight = false;
        }
        if(catTail.transform.rotation.z >= 0.174){
            rotateTailRight = true;
        }

        if(rotateTailRight){
            catTail.transform.Rotate(0, 0, -rotationAmount * Time.deltaTime);
        } 
        else {
            catTail.transform.Rotate(0, 0, rotationAmount * Time.deltaTime);
        }
    }

    void MovePaw(){
        Debug.Log(catPaw.transform.rotation.z);

        if(catPaw.transform.rotation.z <= -0.4){
            rotatePawRight = false;
        }
        if(catPaw.transform.rotation.z >= 0){
            rotatePawRight = true;
        }

        if(rotatePawRight){
            catPaw.transform.Rotate(0, 0, -rotationAmount * Time.deltaTime);
        } 
        else {
            catPaw.transform.Rotate(0, 0, rotationAmount * Time.deltaTime);
        }
    }

    void SetRotationAmount(){
        float currentHype = hypeMeter.GetComponent<HypeMeter>().GetCurrentHype();
        if(currentHype >= 70f){
            rotationAmount = 200f;
            hypedFelixFace.SetActive(true);
        } else if (currentHype >= 50f){
            rotationAmount = 70f;
            hypedFelixFace.SetActive(false);
        } else if (currentHype >= 30f){
            rotationAmount = 35f;
            hypedFelixFace.SetActive(false);
        } else if (currentHype >= 20f){
            rotationAmount = 20f;
            hypedFelixFace.SetActive(false);
        } else if (currentHype <= 30f){
            boredFelixFace.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update(){
        SetRotationAmount();
        MoveTail();
        MovePaw();
        Debug.Log(hypeMeter.GetComponent<HypeMeter>().GetCurrentHype());
    }
}
