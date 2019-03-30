using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    int currentSceneIndex;
    public static bool isExist;
    public GameObject clone;

    // Use this for initialization
    void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (!isExist)
        {
            clone = gameObject;
            isExist = true;
        }

        hasTerminated = false;
        thisSpeed = gameSpeed;
        scoreText.text = currentScore.ToString();
        DontDestroyOnLoad(clone);
    }
	
	// Update is called once per frame
	void Update () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = gameSpeed;
        Terminate();
        scoreText.text = currentScore.ToString();
        if (currentSceneIndex == 0) {
            ResetCurrentScore();
        }
        if (currentScore == 0) {
            scoreText.text = "";
        }
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
        Debug.Log(currentScore);
    }

    public void SubtractScore()
    {
        currentScore -= scorePerRestart;
        Debug.Log(currentScore);
    }

    public void ResetCurrentScore() {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
}
