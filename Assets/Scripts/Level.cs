using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    // serialied for debugging purposes
    [SerializeField] int breakableBlocks = 0;

    // cache reference
    SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks() {
        breakableBlocks++;
    }

    public void RemoveBlock() {
        breakableBlocks--;
        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
