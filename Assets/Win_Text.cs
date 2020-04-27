using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Text : MonoBehaviour
{
    public Game_Manager gameManager;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.pinsLeft == 0)
        {
            winText.text = "YOU WIN!";
        }
        if (gameManager.triesLeft == 0 && gameManager.pinsLeft >0)
        {
            winText.text = "YOU LOSE!";
        }
    }
}
