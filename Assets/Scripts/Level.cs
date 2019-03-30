using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    
    // params
    [SerializeField] int remainingBlocks;
    [SerializeField] int thisLevel;

    // cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        thisLevel = SceneManager.GetActiveScene().buildIndex;
    }


    public void CountRemainingBlocks()
    {
        remainingBlocks++;
    }

    public void RemoveOneBlock()
    {
        remainingBlocks--;
        if (remainingBlocks <= 0)
        {
            if (thisLevel == SceneManager.sceneCountInBuildSettings - 3)
            {
                Debug.Log("win");
                sceneLoader.LoadWinScene();
            }
            else
            {
                sceneLoader.LoadNextScene();
            }
        }
    }
}
