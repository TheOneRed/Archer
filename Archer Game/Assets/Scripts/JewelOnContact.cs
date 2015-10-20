using UnityEngine;
using System.Collections;

public class JewelOnContact : MonoBehaviour
{

    //Public Instances
    public int AddScore;
	public int LoseScore;

    //Private Instances
    private GameController gameController; //To reference GameController script

    void Start()
    {
		// Finding GameController game object to access methods in GameController script 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }


    }
	
	//When jewel comes into contact with other colliders
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameController.pickUpJewel();
            gameController.GainScore(AddScore); //reference to GameController to gain point for collecting the jewel
            Destroy(gameObject);
        }

		if (other.tag == "Arrow") 
		{
			gameController.breakJewel(); //reference to gameController to play sound. 
			gameController.GainScore(LoseScore); //reference to GameController to lose points for breaking the jewel
			Destroy(gameObject);
		}
	}


}
