using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    
    // params
    [SerializeField] int remainingBlocks;
    [SerializeField] int thisLevel;

    // cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void CountRemainingBlocks()
    {
        remainingBlocks++;
    }

    public void SetThisLevel(int thisLevel) {
        this.thisLevel = thisLevel;
    }

    public void RemoveOneBlock()
    {
        remainingBlocks--;
        if (remainingBlocks <= 0)
        {
            if (thisLevel == 2)
            {
                sceneLoader.LoadWinScene();
            }
            else
            {
                sceneLoader.LoadNextScene();
            }
        }
    }
}
