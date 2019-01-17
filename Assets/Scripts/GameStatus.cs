using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {


    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;
    float thisSpeed;
    [SerializeField] int scorePerBlock;
    [SerializeField] int scorePerRestart;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    bool hasTerminated;
    [SerializeField] int currentScore;

    // Use this for initialization
    void Start () {
        hasTerminated = false;
        thisSpeed = gameSpeed;
        scoreText.text = currentScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
        Terminate();
        scoreText.text = currentScore.ToString();
    }

    private void Terminate()
    {
        if (!hasTerminated)
        {
            if (Input.GetMouseButtonDown(2))
            {
                hasTerminated = true;
                gameSpeed = 0f;
            }
        }
        else if (Input.GetMouseButtonDown(2))
        {
            hasTerminated = false;
            gameSpeed = thisSpeed;
        }

    }

    public void AddToScore()
    {
        currentScore += scorePerBlock;
    }

    public void subtractScore()
    {
        currentScore -= scorePerRestart;
    }
}
