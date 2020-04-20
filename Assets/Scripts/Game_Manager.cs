using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public int triesLeft = 3;

    int totalPins = 10;

    public int pinsLeft = 10;

    public Ball_Collisions ballCollision;
    public Text numberOfTries;
    public Text numberOfPins;

    public Pins_state Pin1;
    public Pins_state Pin2;
    public Pins_state Pin3;
    public Pins_state Pin4;
    public Pins_state Pin5;
    public Pins_state Pin6;
    public Pins_state Pin7;
    public Pins_state Pin8;
    public Pins_state Pin9;
    public Pins_state Pin10;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
        pinsLeft = totalPins;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void checkEndGame()
    {
        if (triesLeft == 0)
        {
            
        }
    }

    void checkPinsLeft()
    {
        if (ballCollision.ballHasCollided)
        {
            if (!Pin1.pinIsUp && !Pin1.substractedFromTotalPins)
            {
                pinsLeft -= 1;
                Pin1.substractedFromTotalPins = true;
            }
            if (!Pin2.pinIsUp && !Pin2.substractedFromTotalPins)
            {
                pinsLeft -= 1;
                Pin2.substractedFromTotalPins = true;
            }
            if (!Pin3.pinIsUp && !Pin3.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin3.substractedFromTotalPins = true;
            }
            if (!Pin4.pinIsUp && !Pin4.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin4.substractedFromTotalPins = true;
            }
            if (!Pin5.pinIsUp && !Pin5.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin5.substractedFromTotalPins = true;
            }
            if (!Pin6.pinIsUp && !Pin6.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin6.substractedFromTotalPins = true;
            }
            if (!Pin7.pinIsUp && !Pin7.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin7.substractedFromTotalPins = true;
            }
            if (!Pin8.pinIsUp && !Pin8.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin8.substractedFromTotalPins = true;
            }
            if (!Pin9.pinIsUp && !Pin9.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin9.substractedFromTotalPins = true;
            }
            if (!Pin10.pinIsUp && !Pin10.substractedFromTotalPins)
            {
                pinsLeft--;
                Pin10.substractedFromTotalPins = true;
            }
        }
    }
}
