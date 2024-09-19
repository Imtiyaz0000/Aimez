using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public GameObject audioObject;
    public GameObject scoreManager;

    public void HandleHit()
    {

        scoreManager.GetComponent<ScoreManager>().IncrementScore(1);

        AudioSource audioSource = audioObject.GetComponent<AudioSource>();
        GameObject newAudio = Instantiate(audioObject);
        Destroy(newAudio, audioSource.clip.length);
        Destroy(gameObject);
    }
}
