using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score_Text : MonoBehaviour
{
    public Text scoreText;
    public Game_Manager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your score was: " + gameManager.score;
    }
}
