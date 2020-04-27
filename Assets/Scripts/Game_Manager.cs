using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public int triesLeft = 3;

    int totalPins = 10;

    private static Game_Manager instance;
    public static Game_Manager Get()
    {
        return instance;
    }

    public int pinsLeft = 10;

    public Ball_Collisions ballCollision;
    
    public Text numberOfTries;
    public Text numberOfPins;
    public Text[] texts = FindObjectsOfType<Text>();
    
    public Pins_state[] pins;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        pins = FindObjectsOfType<Pins_state>();
        ballCollision = FindObjectOfType<Ball_Collisions>();
        numberOfTries = texts[1];
        numberOfPins = texts[2];
    }

    // Update is called once per frame
    void Update()
    {
        checkPinsLeft();
        checkEndGame();
        numberOfPins.text = "Pins Left:" + pinsLeft.ToString();
        numberOfTries.text = "Tries Left:" + triesLeft.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void checkEndGame()
    {
        if (triesLeft == 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    void checkPinsLeft()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].pinIsUp && pins[i].substractedFromTotalPins)
            {
                pinsLeft -= 1;
                pins[i].substractedFromTotalPins = true;
            }
        }
    }
}
