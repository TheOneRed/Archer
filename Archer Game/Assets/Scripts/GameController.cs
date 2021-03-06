﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public int ninjaCounter;
    public GameObject ninja;
    public Text scoreText;
    public Text livesText;
	public Text gameOverText;
	public Text finalScoreText;
	public Text restartText;
    public int scoreValue = 0;
    public int livesValue = 5;
	

    // Private Instances
    private PlayerController playerController;
	private bool gameOver;
	private bool restart;
    private AudioSource[] audioSources; // an array of AudioSources
    private AudioSource theme, jewel, jewelBreak, heart, heartBreak, gameOverSound;

    // Use this for initialization
    void Start()
    {
        this.audioSources = this.GetComponents<AudioSource>();
        this.theme = this.audioSources[0];
        this.jewel = this.audioSources[1];
        this.jewelBreak = this.audioSources[2];
        this.heart = this.audioSources[3];
        this.heartBreak = this.audioSources[4];
        this.gameOverSound = this.audioSources[5];
        gameOver = false;
		restart = false;
		this.gameOverText.enabled = false;
		this.finalScoreText.enabled = false;
		this.restartText.enabled = false;
        this.UpdateScore();
        this.UpdateLives();
        this.NinjaMaker();

        // Finding Player Controller game object to access methods in PlayerController script 
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
		if (playerControllerObject != null)
		{
			playerController = playerControllerObject.GetComponent<PlayerController>();
		}
    }

    // Pree "R" to reset
    void Update()
    {
		if (restart) 
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
    }

    // generate ninjas
    private void NinjaMaker()
    {
        for (int count = 0; count < this.ninjaCounter; count++)
        {
            Instantiate(ninja);
        }
    }

	// When player kills a ninja or collects a jewel
	public void GainScore(int newScoreValue)
	{
		scoreValue += newScoreValue;
		UpdateScore();
	}

	// Updates score value from above
	public void UpdateScore()
	{
		scoreText.text = "Score: " + scoreValue;
	}

	// When player collides with a ninja
    public void LoseLife(int newLifeValue)
    {
        livesValue -= newLifeValue;
        UpdateLives();
    }

	// Updates lives value from above
    public void UpdateLives()
    {
        livesText.text = "Lives: " + livesValue;

        if (livesValue == 0) 
		{
			playerController.kill (); // Reference to PlayerController to destroy player game object
			this.gameOverSound.Play (); //Sound when you hit zero lives value
			this.GameOver ();
		}
    }

	// When lives value hits zero
	private void GameOver()
	{
		gameOver = true;
		this.scoreText.enabled = false;
		this.livesText.enabled = false;
		this.gameOverText.enabled = true;
		this.finalScoreText.enabled = true;
		this.finalScoreText.text = "Final Score: " + this.scoreValue;

		//Meassge to press "R" to play again
		if (gameOver)
		{
			this.restartText.enabled = true;
			this.restartText.text = "Press 'R' to play again";
			restart = true;
		}
	}

    //SOUND METHODS

    public void pickUpJewel()
    {
        this.jewel.Play();
    }

    public void breakJewel()
    {
        this.jewelBreak.Play();
    }

    public void pickUpHeart()
    {
        this.heart.Play();
    }
    
    public void breakHeart()
    {
        this.heartBreak.Play();
    }

    public void youLose()
    {
        this.gameOverSound.Play();
    }


    

}
