using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int blockValue = 88;
    [SerializeField] TextMeshProUGUI scoreString;

    // game state
    [SerializeField] int playerScore = 0;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1) {
            // IMMEDIATELY SET IT AS INACTIVE. if other scripts depend on it
            // then it could cause issues.
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        scoreString.text = playerScore.ToString();
    }

    private void Update() {
        Time.timeScale = gameSpeed;

    }

    public void IncrementPlayerScore() {
        playerScore += blockValue;
        scoreString.text = playerScore.ToString();
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}
