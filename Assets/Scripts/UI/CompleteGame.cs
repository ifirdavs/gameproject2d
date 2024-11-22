using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    private AudioSource finishSound;
    private UIManager uiManager;
    private Transform currentCheckpoint;

    private bool levelCompleted = false;

    private void Awake() {
        uiManager = FindObjectOfType<UIManager>();
    }
    private void Start() {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player" && !levelCompleted) {
            //finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel() {
        if (currentCheckpoint == null) {
            uiManager.GameComplete();
            return;
        }
    }
}