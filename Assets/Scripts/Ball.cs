using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;


    // state
    Vector2 paddleToBallVec;
    bool launched = false;

    void Start() {
        paddleToBallVec = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!launched) {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick() {
        if (Input.GetMouseButtonDown(0)) {
            launched = true;
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
    }
}
