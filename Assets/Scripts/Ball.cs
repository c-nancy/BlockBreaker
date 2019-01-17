using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // params
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] GameStatus status;


    // state
    Vector2 paddleToBallVector;
    bool hasStarted;

    // Cached component references
    AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle.transform.position;
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>();
        status = FindObjectOfType<GameStatus>();
        xPush = UnityEngine.Random.Range(-1, 1);
        yPush = 15f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        else {
            LaunchAgain();
        }
        
	}

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchAgain() {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            status.subtractScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
    


}

