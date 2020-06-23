using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    // Config params
    [SerializeField] float screenWidthInWorldUnits = 16f;
    [SerializeField] float minX = 2f;
    [SerializeField] float maxX = 15f;

    void Update() {
        // Mouse position x / screen width gives us a 0-1 number. that number times the
        // number in world units gives us a number 0 - 16, where it maps to the screen.
        float xPos = Input.mousePosition.x / Screen.width * screenWidthInWorldUnits;
        // vec is wherever it is currently
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(xPos, minX, maxX);
        transform.position = paddlePos;
    }
}
