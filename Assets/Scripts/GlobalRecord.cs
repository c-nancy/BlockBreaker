using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalRecord : MonoBehaviour{

    public int globalScore;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGlobalScore(int score) {
        this.globalScore = score;
    }

    public int GetGlobalScore() {
        return globalScore;
    }
}
