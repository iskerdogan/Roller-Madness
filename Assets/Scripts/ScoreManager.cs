using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    
    public int score = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTheScore();
    }

    private void UpdateTheScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
