using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip clip;
    [SerializeField] Level level;
    [SerializeField] GameStatus status;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountRemainingBlocks();
        status = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject, 0f);
        level.RemoveOneBlock();
        status.AddToScore();
    }
}
