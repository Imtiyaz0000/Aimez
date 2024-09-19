using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float duration = 60f;
    private float timeRemaining;
    private int totalScore = 0;
    private int totalDummies;
    public int maxDummies = 10;

    public GameObject dummy;
    public Vector3 dummyPosition;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    private bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        totalDummies = maxDummies;
        timeRemaining = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
            if (timeRemaining < 0)
            {
                DestroyAllDummies();
                playing = false;
                Instantiate(dummy, dummyPosition, Quaternion.Euler(0f, -90f, 0)).GetComponent<Dummy>().scoreManager = gameObject;
            }
            if (totalDummies == 0)
            {
                if (timeRemaining > 2f)
                {
                    Invoke("Respawn", 2f);
                }
                
                totalDummies = -1;
            }
        }
    }

    public void IncrementScore(int amount)
    {
        if (!playing)
        {
            playing = true;
            totalScore = -1;
            timeRemaining = duration;
            
            Respawn();
        }
        totalDummies -= 1;
        totalScore += amount;
        scoreText.text = "Score: " + totalScore.ToString();
    }

    public void Respawn()
    {
        for (int i = 0; i < maxDummies; i++)
        {
            Instantiate(dummy, new Vector3(Random.Range(-5, 14), 0.5f, Random.Range(-49, -17)), Quaternion.Euler(0f, 0f, 0f)).GetComponent<Dummy>().scoreManager = gameObject;
        }
        totalDummies = maxDummies;
    }

    private void DestroyAllDummies()
    {
        Dummy[] dummies = FindObjectsOfType<Dummy>();
        foreach (Dummy dummy in dummies)
        {
            Destroy(dummy.gameObject);
        }
    }
}
