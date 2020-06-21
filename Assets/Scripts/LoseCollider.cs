using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision) {
        SceneManager.LoadScene("GameOverScene");
    }
}
