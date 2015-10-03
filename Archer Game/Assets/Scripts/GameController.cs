using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public int ninjaCounter;
    public GameObject ninja;
    public Text scoreText;
    public Text livesText;
    public int scoreValue = 0;
    public int livesValue = 5;

    // Private Instances
    private PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        this.UpdateScore();
        this.UpdateLives();
        this.NinjaMaker();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // generate ninjas
    private void NinjaMaker()
    {
        for (int count = 0; count < this.ninjaCounter; count++)
        {
            Instantiate(ninja);
        }
    }

    public void LoseLife(int newLifeValue)
    {
        livesValue -= newLifeValue;
        UpdateLives();
    }

    public void UpdateLives()
    {
        livesText.text = "Lives: " + livesValue;

        if (livesValue == 0)
        {
            playerController.kill();
        }
    }

    public void GainScore(int newScoreValue)
    {
        scoreValue += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + scoreValue;
    }

}
