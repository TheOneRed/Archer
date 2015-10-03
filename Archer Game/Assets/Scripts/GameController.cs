using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public int ninjaCounter;
    public GameObject ninja;

    //Public Instancces for Scoreboard
    public Text scoreText;
    public Text livesText;
    public int scoreStart = 0;
    public int livesStart = 5;

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
        livesStart -= newLifeValue;
        UpdateLives();
    }

    public void UpdateLives()
    {
        livesText.text = "Lives: " + livesStart;

        if (livesStart <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GainScore(int newScoreValue)
    {
        scoreStart += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + scoreStart;
    }

}
