using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalRecord : MonoBehaviour {

    public int globalScore;
    [SerializeField] TextMeshProUGUI scoreText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = globalScore.ToString();
		
	}

    public void setGlobalScore(int score) {
        this.globalScore = score;
    }
}
