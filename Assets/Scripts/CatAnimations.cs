using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour
{

    public GameObject catTail;
    public GameObject catPaw;
    public GameObject hypeMeter;

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
        //Rotation amount code here
    }

    // Update is called once per frame
    void Update(){
        SetRotationAmount();
        MoveTail();
        MovePaw();
        Debug.Log(hypeMeter.GetComponent<HypeMeter>().GetCurrentHype());
    }
}
