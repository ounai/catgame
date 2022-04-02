using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeMeter : MonoBehaviour
{

    private float hypeScore = 50;
    public Text hypeScoreText;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        hypeScore -= 1 * Time.deltaTime;
        hypeScoreText.text = "Debug: Hype Score " + hypeScore;


    }
}
