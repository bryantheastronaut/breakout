using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    // config params
    [SerializeField] AudioClip blockBreak;
    [SerializeField] GameObject blockSparklesVFX;

    [SerializeField] Sprite[] hitSprites;

    // state
    [SerializeField] int timesHit;

    // cached ref
    Level level;

    private void Start() {
        CountBreakableBlocks();
        timesHit = 0;
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (CompareTag("Breakable")) {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (CompareTag("Breakable")) {
            HandleHit();
        }
    }

    private void HandleHit() {
        timesHit++;
        int maxHealth = hitSprites.Length + 1;
        if (timesHit >= maxHealth) {
            PlayBlockHitSound();
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = Mathf.Clamp(timesHit - 1, 0, hitSprites.Length - 1);
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError(name + ": Block sprite is missing from array");
        }
    }

    private void DestroyBlock() {
        level.RemoveBlock();
        FindObjectOfType<GameSession>().IncrementPlayerScore();
        Destroy(gameObject, 0.05f);
        OnTriggerSparklesVFX();
    }

    private void OnTriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void PlayBlockHitSound() {
        AudioSource.PlayClipAtPoint(blockBreak, Camera.main.transform.position, 0.25f);
    }
}
