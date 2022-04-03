using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HypeEventType {
    TOY_MOVEMENT
}

public class HypeEvent {
    public HypeEventType type;
    public float hypeAmount { get; }

    HypeEvent(HypeEventType type, float hypeAmount) {
        this.type = type;
        this.hypeAmount = hypeAmount;
    }
}

public class HypeMeter : MonoBehaviour {
    public Text hypeScoreText;
    public float initialHypeScore = 0f;

    private float hypeScore = 0f;

    public void RegisterHypeEvent(HypeEvent hypeEvent) {
        Debug.Log($"Register hype event {hypeEvent.type} of value {hypeEvent.hypeAmount}");

        hypeScore += hypeEvent.hypeAmount;
    }

    void Start() {
        hypeScore = initialHypeScore;
    }

    void Update() {
        hypeScore -= Time.deltaTime;
        hypeScoreText.text = $"Debug: Hype Score {hypeScore}";
    }
}
